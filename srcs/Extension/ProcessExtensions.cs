using System;
using System.Collections.Generic;
using System.Diagnostics;
using NProcess.Module;
using NProcess.Utility;
using NProcess.Window;

namespace NProcess.Extension
{
    internal static class ProcessExtensions
    {
        public static Dictionary<string, IModule> GetModules(this Process process, IProcess typedProcess)
        {
            var modules = new Dictionary<string, IModule>();
            for (int i = 0; i < process.Modules.Count; i++)
            {
                ProcessModule module = process.Modules[i];

                modules[module.ModuleName] = new MemoryModule(typedProcess, module.ModuleName, module.BaseAddress, module.ModuleMemorySize);
            }

            return modules;
        }

        public static List<IWindow> GetWindows(this Process process, IProcess typedProcess)
        {
            var output = new List<IWindow>();
            IEnumerable<IntPtr> windows = WindowUtility.GetWindows(process);
            foreach (IntPtr handle in windows)
            {
                string title = WindowUtility.GetWindowTitle(handle);
                if (string.IsNullOrEmpty(title))
                {
                    continue;
                }

                output.Add(new ProcessWindow(typedProcess, handle));
            }

            return output;
        }
    }
}