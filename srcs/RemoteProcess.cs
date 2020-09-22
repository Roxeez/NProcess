using System;
using System.Diagnostics;
using NProcess.Interop;
using NProcess.Interop.Enum;
using NProcess.Memory;

namespace NProcess
{
    /// <summary>
    ///     Class used when you need to interact with a remote process
    /// </summary>
    public sealed class RemoteProcess : ProcessBase
    {
        private readonly IntPtr handle;

        public RemoteProcess(Process process) : base(process)
        {
            handle = Kernel32.OpenProcess(ProcessAccess.All, false, process.Id);

            Memory = new RemoteMemory(handle);
        }

        public override IMemory Memory { get; }

        public override void Dispose()
        {
            Kernel32.CloseHandle(handle);
        }
    }
}