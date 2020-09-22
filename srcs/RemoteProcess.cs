﻿using System;
 using System.Diagnostics;
using NProcess.Interop;
using NProcess.Interop.Enum;
using NProcess.Memory;
 using NProcess.Memory.Remote;

 namespace NProcess
{
    /// <summary>
    /// Class used when you need to interact with a remote process
    /// </summary>
    public sealed class RemoteProcess : ProcessBase
    {
        private readonly IntPtr handle;
        public RemoteProcess(Process process) : base(process)
        {
            handle = Kernel32.OpenProcess(ProcessAccess.All, false, process.Id);
            
            MemoryReader = new RemoteMemoryReader(handle);
            MemoryWriter = new RemoteMemoryWriter(handle);
        }

        public override IMemoryReader MemoryReader { get; }
        public override IMemoryWriter MemoryWriter { get; }

        public override void Dispose()
        {
            Kernel32.CloseHandle(handle);
        }
    }
}