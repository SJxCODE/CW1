using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATM
{
    class sendsms
    {
        public static bool SendSMS(string num, string msg)
        {
            try
            {

                string userName = "amisvora";
                string Key = "98E40A10-E589-F100-A75E-6429713BD0D0";
                string Number = num;
                string Message = msg;

                //  attempt to send message

                ATM.SMSRespondsData _Data = ATM.ClickSendSMS.SendSms(userName, Key, Number, Message, "", "");

                // load result
                string ResultTo = _Data.SMSTo;
                string ResultMessageId = _Data.Message;
                int ResultCode = _Data.RespondsCode;
                string ResultErrorText = _Data.RespondsText;

                // check result
                if (ResultCode == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;  
            } 

        }
    }
}
