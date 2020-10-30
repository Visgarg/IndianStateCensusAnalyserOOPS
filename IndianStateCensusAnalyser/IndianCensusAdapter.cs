using IndianStateCensusAnalyser.Constructor_for_different_CSV;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace IndianStateCensusAnalyser
{
    /// <summary>
    /// Class inherited from Census Adapter
    /// </summary>
    public class IndianCensusAdapter:CensusAdapter
    {
        //used to read data from censusAdapter class
        string[] censusData;
        //used to make a dictionary and return to csvAdapterFactory class
        Dictionary<string, CensusDTO> dataMap;

        /// <summary>
        /// Converts the data into dictionary and returns the dictionary
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns></returns>
        public Dictionary<string,CensusDTO> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            //initializing dictionary
            dataMap = new Dictionary<string, CensusDTO>();
            //reading the data from getCensusData method of censusAdapter class
            censusData = GetCensusData(csvFilePath, dataHeaders);
            //reads each element in array, representing each line and checks for comma as a delimiter
            //if comma is present, elements are splitted and stored in another array
            //array elements are passed to be added in dictionary of census data type.
            //censusdata.skip(1) is a linq query which skips 1st row, i.e. headers.
            foreach(string data in censusData.Skip(1))
            {
                if(!data.Contains(","))
                {
                    throw new CensusAnalyserException("File contains wrong Delimiter", CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER);
                }
                string[] column = data.Split(",");
                //checks for different type of csv files
                if(csvFilePath.Contains("IndiaStateCode.csv"))
                {
                    dataMap.Add(column[1], new CensusDTO(new IndianStateCode(column[0], column[1], column[2], column[3])));
                }
                if(csvFilePath.Contains("IndiaStateCensusData.csv"))
                {
                    dataMap.Add(column[1], new CensusDTO(new IndianStateCensusData(column[0], column[1], column[2], column[3])));
                } 
            }
            //returns dictionary containing data
            return dataMap.ToDictionary(p=>p.Key,p=>p.Value);
        }
    }
}
