using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using NProcess.Extension;
using NProcess.Interop;
using NProcess.Interop.Struct;

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

        public static Rectangle GetWindowRect(IntPtr handle)
        {
            if (!User32.GetWindowRect(handle, out Rect rect))
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            return rect.ToRectangle();
        }
    }
}