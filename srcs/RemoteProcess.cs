using System.Diagnostics;
using NProcess.Memory;

namespace NProcess
{
    /// <summary>
    ///     Class used when you need to interact with a remote process
    /// </summary>
    public sealed class RemoteProcess : ProcessBase
    {
        public RemoteProcess(Process process) : base(process)
        {
            Memory = new RemoteMemory(Handle);
        }

        public override IMemory Memory { get; }
    }
}