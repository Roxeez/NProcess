using System;
using System.Collections.Generic;
using NProcess.Memory;
using NProcess.Module;
using NProcess.Window;

namespace NProcess
{
    /// <summary>
    ///     Represent a process
    /// </summary>
    public interface IProcess : IDisposable
    {
        /// <summary>
        ///     Id of process
        /// </summary>
        int Id { get; }

        /// <summary>
        ///     Name of process
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Contains all modules of process
        /// </summary>
        IEnumerable<IModule> Modules { get; }

        /// <summary>
        ///     Contains all windows of process
        /// </summary>
        IEnumerable<IWindow> Windows { get; }

        /// <summary>
        ///     Main module of process
        /// </summary>
        IModule Module { get; }

        /// <summary>
        ///     Main window of process
        /// </summary>
        IWindow Window { get; }

        /// <summary>
        ///     Memory of this process
        /// </summary>
        IMemory Memory { get; }
        

        /// <summary>
        ///     Get module by name
        /// </summary>
        /// <param name="name">Module name</param>
        /// <returns>Module found or null if none</returns>
        IModule GetModule(string name);

        /// <summary>
        ///     Get window by name
        /// </summary>
        /// <param name="name">Window name</param>
        /// <returns>Window found or null if none</returns>
        IWindow GetWindow(string name);
    }
}