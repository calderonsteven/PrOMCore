using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing;

namespace PrOMCore.Windows.Interop
{
    public struct SYSTEMTIME
    {
       /* public short wYear;
        public short wMonth;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        * */

        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }

    /// <summary>
    /// Windows style
    /// </summary>
    public enum WS
    {
        BORDER = 0x00800000,
        CAPTION = 0x00C00000,
        DLGFRAME = 0x00400000
        
    }

    /// <summary>
    /// Window field offsets for GetWindowLong()
    /// </summary>
    public enum GWL
    {
        STYLE = -16
    }

    /// <summary>
    /// Flags for SetWindowPos API
    /// </summary>
    public enum SWP
    {
        NOACTIVATE = 0x0010
    }

    public class Native
    {
        [DllImport("coredll.dll")]
        public static extern int SetWindowText(IntPtr MessageWindow, string Title);
        [DllImport("coredll.dll", EntryPoint = "WindowFromPoint")]
        public extern static IntPtr WindowFromPointYX(int y, int x);
        [DllImport("Coredll.dll")]
        public static extern bool MoveWindow(IntPtr hwnd, int x, int y, int nwidth, int nHeight, bool brepaint);
        [DllImport("Coredll.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("Coredll.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("Coredll.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hwnd, int hwnd2, int x, int y, int cx, int cy, int uFlags);
        [DllImport("Coredll.dll")]
        public static extern bool DestroyWindow(IntPtr hWnd);
        
        
        /// <summary>
        /// Establecer fecha y hora.
        /// </summary>
        /// <param name="SysTime"></param>
        /// <returns></returns>
        [DllImport("Coredll.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME SysTime);

        /*public static void ShowSipButton(bool Visible, bool RamboMode){
             IntPtr windowH = FindWindow("MS_SIPBUTTON", "MS_SIPBUTTON");
             if (Visible)
                 MoveWindow(windowH, 204, 295, 36, 24, false);
             else if(RamboMode)                            
                 DestroyWindow(windowH);
             else
                 MoveWindow(windowH, 0, 0, 0, 0, false);
         }*/
    }
}
