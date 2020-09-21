﻿using System.Diagnostics;
using NProcess.Interop;
using NProcess.Interop.Enum;
using NProcess.Memory;

namespace NProcess
{
    /// <summary>
    /// Class used when you need to interact with a remote process
    /// </summary>
    public sealed class RemoteProcess : ProcessBase
    {
        public RemoteProcess(Process process) : base(process)
        {
            Memory = new RemoteMemory(Kernel32.OpenProcess(ProcessAccess.All, false, process.Id));
        }

        public override IMemory Memory { get; }
    }
}