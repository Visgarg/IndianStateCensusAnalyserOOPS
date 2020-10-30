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
        [Test]
        /// <summary>
        /// checking the program for incorrect file name which do not exist
        /// </summary>
        public void GivenWrongIndianCensusDataFile_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
           var customException= Assert.Throws<CensusAnalyserException>(()=>censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,wrongIndiaStateCensusData,indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND,customException.etype );
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect file type which do not exist
        /// </summary>
        public void GivenWrongIndianCensusDataType_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,indiaStateCensusDataText, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect delimiter is passed
        /// </summary>
        public void GivenIncorrectDelimiterForCensusData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,delimiterIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, customException.etype);
        }
        [Test]
        /// <summary>
        /// checking the program for incorrect header is passed
        /// </summary>
        public void GivenIncorrectHeaderForCensusData_WhenReadedShouldReturnCustomException()
        {
            //census Analyser Class is Called and parameters are passed like country, indian state census data which is csv file and header file.
            //add
            var customException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(CensusAnalyser.Country.INDIA,wrongIndiaStateCensusData, indianStateCensusHeaders));
            //total no of rows excluding header are 29 in indian state census data.
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, customException.etype);
        }
    }
}