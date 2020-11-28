using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM
{
    public class RespondsData
    {
        string _UserName = "";
        /// <summary>
        /// Get username.
        /// </summary>
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }

        string _Key = "";
        /// <summary>
        /// get user key.
        /// </summary>
        public string Key
        {
            get { return _Key; }
            set { _Key = value; }
        }

        int _RespondsCode = 0;
        /// <summary>
        /// Get the Message Responds Code
        /// </summary>
        public int RespondsCode
        {
            get { return _RespondsCode; }
            set { _RespondsCode = value; }
        }

        string _RespondsText = "";
        /// <summary>
        /// Get the Message Responds Text
        /// </summary>
        public string RespondsText
        {
            get { return _RespondsText; }
            set { _RespondsText = value; }
        }

        string _SenderID = "";
        /// <summary>
        /// get or set Sender id
        /// </summary>
        public string SenderID
        {
            get { return _SenderID; }
            set { _SenderID = value; }
        }
    }
}
