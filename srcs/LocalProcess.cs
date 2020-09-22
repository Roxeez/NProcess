using System.Diagnostics;
using NProcess.Memory;

namespace NProcess
{
    /// <summary>
    ///     Class used when you need to interact with local process (ex: injected .dll)
    /// </summary>
    public sealed class LocalProcess : ProcessBase
    {
        public LocalProcess() : base(Process.GetCurrentProcess())
        {
            Memory = new LocalMemory(Process.GetCurrentProcess().Handle);
        }
        
        public override IMemory Memory { get; }

        public override void Dispose()
        {
        }
    }
}