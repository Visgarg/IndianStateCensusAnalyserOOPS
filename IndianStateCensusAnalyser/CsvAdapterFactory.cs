using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace IndianStateCensusAnalyser
{
    /// <summary>
    /// Checking for the matching country as per enum in censusAnalyser
    /// </summary>
    public class CsvAdapterFactory
    {
        /// <summary>
        /// method for checking specific country and passing it to next class or throwing exception
        /// </summary>
        /// <param name="country">checked here</param>
        /// <param name="csvFilePath">contains file path</param>
        /// <param name="dataHeaders">contains data header</param>
        /// <returns> dictionary which will be returned after containing the all the elements of the data file as values.</returns>
        public Dictionary<string,CensusDTO> LoadCsvData(CensusAnalyser.Country country, string csvFilePath,string dataHeaders)
        {
            switch(country)
            {
                //if country is india, csv file and data header are passed to indianCensusAdapter class and loadCensusData method
                case CensusAnalyser.Country.INDIA:
                    return new IndianCensusAdapter().LoadCensusData(csvFilePath, dataHeaders);
               //custom exception is thrown.
                default:
                    throw new CensusAnalyserException("No such Country", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
            }
        }
    }
}
