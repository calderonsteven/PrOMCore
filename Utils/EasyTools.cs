using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using PrOMCore.Windows.Interop;
using PrOMCore.Utils;

namespace PrOMCore.Utils
{
    /// <summary>
    /// Provide generic functions for multiple functionlatity
    /// </summary>
    public class PrOMTools
    {
        public static bool IsNumeric(string text)
        {
            try
            {

                Decimal.Parse(text);
                return true;
            }
            catch
            { }
            return false;

        }


        /// <summary>
        /// Returns the total days trascurred in current year
        /// </summary>
        /// <param name="date">Date for reference</param>
        /// <returns>total days transcurred in this year</returns>
        public static int DaysBetweenDateAndNow(DateTime date)
        {
            DateTime dateTimeCurrentYear = new DateTime(DateTime.Now.Year - 1, 12, 31);
            TimeSpan iimeSpanTranscurred;
            iimeSpanTranscurred = date - dateTimeCurrentYear;
            return (Math.Abs(iimeSpanTranscurred.Days));
        }


        /// <summary>
        /// Obtiene La ruta actual del aplicativo!
        /// </summary>
        public static string ApplicationDirectory
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            }
        }

        public static void SetLocalTime(DateTime newLocalTime)
        {
            PrOMCore.Windows.Interop.SYSTEMTIME sYSTEMTIME;
            sYSTEMTIME = new PrOMCore.Windows.Interop.SYSTEMTIME();
            sYSTEMTIME.wYear = (ushort)newLocalTime.Year;
            sYSTEMTIME.wMonth = (ushort)newLocalTime.Month;
            sYSTEMTIME.wDay = (ushort)newLocalTime.Day;
            sYSTEMTIME.wHour = (ushort)newLocalTime.Hour;
            sYSTEMTIME.wMinute = (ushort)newLocalTime.Minute;
            sYSTEMTIME.wSecond = (ushort)newLocalTime.Second;
            Native.SetLocalTime(ref sYSTEMTIME);
        }

    }

}
