using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace IndianStateCensusAnalyser
{
    /// <summary>
    /// Defining abstract class to be inherited by IndianCensusAdapter
    /// </summary>
    public abstract class CensusAdapter
    {
        /// <summary>
        /// protected method to be return by the inherited class to check for exception cases and return the data after reading from file
        /// </summary>
        /// <param name="csvFilePath"></param>
        /// <param name="dataHeaders"></param>
        /// <returns>data in form of array</returns>
        protected string[] GetCensusData(string csvFilePath, string dataHeaders)
        {
            //used to return array
            string[] censusData;
            //checks for the existence of the file path, and if not, returns custom exception
            if(!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException("File not found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);

            }
            //checks for the existence of csv extension, and if not, returns custom exception
            if(Path.GetExtension(csvFilePath)!=".csv")
            {
                throw new CensusAnalyserException("Invalid File type", CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);

            }
            //file.readalllines(path) reads all the data in form of array containing each lines.
            censusData = File.ReadAllLines(csvFilePath);
            //if header of the file do not matched with the given header, exception is returned
            //censusDAta is array hence compared with 1st element
            if(censusData[0]!= dataHeaders)
            {
                throw new CensusAnalyserException("Incorrect header in Data", CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            //returns array
            return censusData;

        }
    }
}
