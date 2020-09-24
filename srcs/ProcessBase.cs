using System;
using System.Collections.Generic;
using System.Diagnostics;
using NProcess.Extension;
using NProcess.Interop;
using NProcess.Interop.Enum;
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

            Handle = Kernel32.OpenProcess(ProcessAccess.All, false, process.Id);

            Module = GetModule(process.MainModule?.ModuleName);
            Window = GetWindow(process.MainWindowTitle);
        }

        public int Id => process.Id;
        public string Name => process.ProcessName;
        public IntPtr Handle { get; }
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

        public abstract IMemory Memory { get; }

        public virtual void Dispose()
        {
            foreach (IWindow window in Windows)
            {
                window.Dispose();
            }
            
            Kernel32.CloseHandle(Handle);
        }

        public bool Equals(IProcess other)
        {
            return other != null && other.Id == Id && other.Handle == Handle;
        }
    }
}