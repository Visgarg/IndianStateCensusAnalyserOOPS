﻿using IndianStateCensusAnalyser.Constructor_for_different_CSV;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public long population;
        public long area;
        public long density;
        public string state;
        public string stateCode;
        public int tin;

        /// <summary>
        /// Constructor for CensusDTO with indianstateCensusData as a parameter
        /// </summary>
        /// <param name="indianStateCensusData"></param>
        public CensusDTO(IndianStateCensusData indianStateCensusData)
        {
            this.state= indianStateCensusData.state;
            this.population = indianStateCensusData.population;
            this.area = indianStateCensusData.area;
            this.density = indianStateCensusData.density;
        }
        /// <summary>
        /// Constructor for censusDTO with indianstateCode as a parameter
        /// </summary>
        /// <param name="indianStateCode"></param>
        public CensusDTO(IndianStateCode indianStateCode)
        {
            this.serialNumber = indianStateCode.serialNumber;
            this.stateName = indianStateCode.stateName;
            this.stateCode = indianStateCode.stateCode;
            this.tin = indianStateCode.tin;
        }


    }
}
