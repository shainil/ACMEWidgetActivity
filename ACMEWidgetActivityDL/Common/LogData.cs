using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ACMEWidgetActivityDL.Common
{
    public static class LogData
    {
        public static void LogRequestResponse(string reqInfo, string resInfo, string reqType)
        {
            string filePath = @".\Data Log\RequestResponse.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("---------------------------------------------------");
                    writer.WriteLine();
                    writer.WriteLine("Request Type: " + reqType);
                    writer.WriteLine();
                    writer.WriteLine("Request");
                    writer.WriteLine(DateTime.Now.ToString());
                    writer.WriteLine(reqInfo);

                    writer.WriteLine();
                    writer.WriteLine("Response");
                    writer.WriteLine(DateTime.Now.ToString());
                    writer.WriteLine(resInfo);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void LogException(string exceptionInfo)
        {
            string filePath = @".\Data Log\Exceptions.txt";
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("---------------------------------------------------");           
                    writer.WriteLine(DateTime.Now.ToString());
                    writer.WriteLine("Exception: " + exceptionInfo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
