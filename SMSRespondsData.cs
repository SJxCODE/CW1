using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class SMSRespondsData : RespondsData
    {
        string _SMSTo = "";
        /// <summary>
        /// get or set only Destination number.
        /// </summary>
        public string SMSTo
        {
            set { _SMSTo = value; }
            get { return _SMSTo; }
        }

        string _Message = "";
        /// <summary>
        /// get or set message text
        /// </summary>
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
    }
}
