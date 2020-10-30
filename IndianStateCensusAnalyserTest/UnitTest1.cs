using NUnit.Framework;
using IndianStateCensusAnalyser;
using System.Collections.Generic;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string wrongIndiaStateCensusData = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\WrongIndiaStateCensusData.csv";
        static string wrongIndiaStateCode = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\WrongIndiaStateCode.csv";
        static string indiaStateCensusData = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\IndiaStateCensusData.csv";
        static string indiaStateCode = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\WrongIndiaStateCode.csv";
        static string delimiterIndiaStateCensusData = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndiaStateCode= @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\DelimiterIndiaStateCode.csv";
        static string indiaStateCodeText = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\IndiaStateCode.txt";
        static string indiaStateCensusDataText = @"C:\Users\vishu\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVfiles\IndiaStateCensusDAta.txt";
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        /// <summary>
        /// Set up will always run, when any test case is checked.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();

        }
        /// <summary>
        /// Test Case 1.1
        /// Getting the count of data in IndiaStateCensusData
        /// </summary>

        [Test]
        public void GivenIndianCensusDataFile_WhenReturnShouldReturnCensusDataCount()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            totalRecord = censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA, indiaStateCensusData, indianStateCensusHeaders);
            //assert
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(29, totalRecord.Count);
        }
       
    }
}