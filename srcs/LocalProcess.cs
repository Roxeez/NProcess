﻿using System.Diagnostics;
using NProcess.Memory;
 using NProcess.Memory.Local;

 namespace NProcess
{
    /// <summary>
    /// Class used when you need to interact with local process (ex: injected .dll)
    /// </summary>
    public sealed class LocalProcess : ProcessBase
    {
        public LocalProcess() : base(Process.GetCurrentProcess())
        {
            MemoryReader = new LocalMemoryReader();
            MemoryWriter = new LocalMemoryWriter();
        }

        public override IMemoryReader MemoryReader { get; }
        public override IMemoryWriter MemoryWriter { get; }

        public override void Dispose()
        {
            
        }
    }
}