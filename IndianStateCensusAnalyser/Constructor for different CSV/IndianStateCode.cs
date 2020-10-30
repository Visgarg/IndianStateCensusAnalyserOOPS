using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.Constructor_for_different_CSV
{
    public class IndianStateCode
    {
        public string stateName;
        public string stateCode;
        public int tin;
        public int serialNumber;
        
        /// <summary>
        /// Constructor for Indian State code class
        /// </summary>
        /// <param name="stateName"></param>
        /// <param name="stateCode"></param>
        /// <param name="tin"></param>
        /// <param name="serialNumber"></param>
        public IndianStateCode( string serialNumber,string stateName,  string tin,string stateCode)
        {
            this.stateName = stateName;
            this.stateCode = stateCode;
            this.tin = Convert.ToInt32(tin);
            this.serialNumber = Convert.ToInt32(serialNumber);
        }
    }
    

}
