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
    }
}