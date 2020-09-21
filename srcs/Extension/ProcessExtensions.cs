using System;
using System.Collections.Generic;
using System.Diagnostics;
using NProcess.Module;

namespace NProcess.Extension
{
    public static class ProcessExtensions
    {
        internal static Dictionary<string, IModule> GetModules(this Process process, IProcess typedProcess)
        {
            var modules = new Dictionary<string, IModule>();
            for (int i = 0; i < process.Modules.Count; i++)
            {
                ProcessModule module = process.Modules[i];

                modules[module.ModuleName] = module.ToModule(typedProcess);
            }

            return modules;
        }

        internal static Module.Module ToModule(this ProcessModule module, IProcess process)
        {
            return new Module.Module(process, module.ModuleName, module.BaseAddress, module.ModuleMemorySize);
        }

        /// <summary>
        /// Find a pattern in process main module
        /// </summary>
        /// <param name="process">Process used</param>
        /// <param name="pattern">Pattern to find (ex: A1 8B 3E ?? ?? ?? ?? F1 47)</param>
        /// <param name="offset">Offset of the pattern</param>
        /// <returns>Address found or IntPtr.Zero if not found</returns>
        public static IntPtr FindPattern(this IProcess process, string pattern, int offset = 0)
        {
            return process.MainModule?.FindPattern(pattern, offset) ?? IntPtr.Zero;
        }
    }
}