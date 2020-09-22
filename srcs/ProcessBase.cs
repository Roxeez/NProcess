﻿using System.Collections.Generic;
using System.Diagnostics;
using NProcess.Extension;
using NProcess.Memory;
using NProcess.Module;

namespace NProcess
{
    public abstract class ProcessBase : IProcess
    {
        private readonly Process process;
        private readonly Dictionary<string, IModule> modules;

        protected ProcessBase(Process process)
        {
            this.process = Process.GetCurrentProcess();
            modules = process.GetModules(this);

            MainModule = process.MainModule?.ToModule(this);
        }

        public int Id => process.Id;
        public string Name => process.ProcessName;
        public IModule MainModule { get; }
        public IModule this[string name] => modules.GetValueOrDefault(name);
        public abstract IMemoryReader MemoryReader { get; }
        public abstract IMemoryWriter MemoryWriter { get; }

        public abstract void Dispose();
    }
}