using System.Collections.Generic;
using System.Diagnostics;
using NProcess.Extension;
using NProcess.Memory;
using NProcess.Module;
using NProcess.Window;

namespace NProcess
{
    public abstract class ProcessBase : IProcess
    {
        private readonly Dictionary<string, IModule> modules;
        private readonly Process process;
        private readonly List<IWindow> windows;

        protected ProcessBase(Process process)
        {
            this.process = Process.GetCurrentProcess();

            modules = process.GetModules(this);
            windows = process.GetWindows(this);

            Module = GetModule(process.MainModule?.ModuleName);
            Window = GetWindow(process.MainWindowTitle);
        }

        public int Id => process.Id;
        public string Name => process.ProcessName;
        public IEnumerable<IModule> Modules => modules.Values;
        public IEnumerable<IWindow> Windows => windows;
        public IModule Module { get; }
        public IWindow Window { get; }

        public IModule GetModule(string name)
        {
            return modules.GetValueOrDefault(name);
        }

        public IWindow GetWindow(string name)
        {
            return windows.Find(x => x.Title == name);
        }

        public abstract IMemoryReader MemoryReader { get; }
        public abstract IMemoryWriter MemoryWriter { get; }

        public abstract void Dispose();
    }
}