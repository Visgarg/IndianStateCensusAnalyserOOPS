using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyser
    {
        /// <summary>
        /// Declaring enum to choose between countries
        /// purpose of the enum is to standardize the process for different countries without change in methods of classes
        /// </summary>
        public enum Country
        {
            INDIA,US
        }
        //Declaring dictionary which will be returned after containing the all the elements of the data file as values.

        public Dictionary<string, CensusDTO> dataMap;
        /// <summary>
        /// Passing the values to csv adapter factory where country is checked
        /// </summary>
        /// <param name="country"> country between india and us</param>
        /// <param name="csvFilePath">csv file path is passed</param>
        /// <param name="dataHeaders">data header of particular csv file is passed</param>
        /// <returns></returns>
        public Dictionary<string,CensusDTO> LoadCensusData(Country country,string csvFilePath, string dataHeaders)
        {
            dataMap = new CsvAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
        
    }
}
