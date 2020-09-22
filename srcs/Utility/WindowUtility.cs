using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using NProcess.Interop;

namespace NProcess.Utility
{
    internal static class WindowUtility
    {
        public static IEnumerable<IntPtr> GetWindows(Process process)
        {
            var windows = new List<IntPtr>();
            User32.EnumWindows(delegate(IntPtr hWnd, IntPtr lParam)
            {
                User32.GetWindowThreadProcessId(hWnd, out int processId);
                if (processId == process.Id)
                {
                    windows.Add(hWnd);
                }

                return true;
            }, IntPtr.Zero);
            return windows;
        }
        

        public static string GetWindowTitle(IntPtr hWnd)
        {
            int size = User32.GetWindowTextLength(hWnd);
            if (size == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder(size + 1);
            User32.GetWindowText(hWnd, sb, sb.Capacity);
            return sb.ToString();
        }
    }
}