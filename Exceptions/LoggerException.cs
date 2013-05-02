using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace PrOMCore.Exceptions
{
    public class LoggerException
    {

        public static void PublishException(Exception exceptionToPublish)
        {
            System.IO.StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(PrOMCore.Utils.PrOMTools.ApplicationDirectory + "\\log.txt", true);
                streamWriter.Write("\r\n" + "PrOMLogException at:" + DateTime.Now.ToString("yyyyMMdd:hhmmss") + "\r\n");
                streamWriter.Write(exceptionToPublish.Message + "\r\n");
                streamWriter.Write(exceptionToPublish.StackTrace);

                if (exceptionToPublish.InnerException != null)
                {
                    streamWriter.Write(exceptionToPublish.InnerException.Message + "\r\n");
                    streamWriter.Write(exceptionToPublish.InnerException.StackTrace);
                }

            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        public static void PublishException(Exception exceptionToPublish, bool throwAgain )
        {
            PublishException(exceptionToPublish);
            if (throwAgain)
            {
                throw exceptionToPublish;
            }
        }

    }
}
