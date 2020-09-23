using System;
using System.Drawing;

namespace NProcess.Window.Mouse
{
    /// <summary>
    /// Mouse used to click in window
    /// </summary>
    public interface IMouse
    {
        /// <summary>
        /// Perform a left click at selected position
        /// </summary>
        /// <param name="position">Position where you want to click</param>
        void LeftClick(Position position);
        
        /// <summary>
        /// Perform a right click at selected position
        /// </summary>
        /// <param name="position">Position where you want to click</param>
        void RightClick(Position position);
        
        /// <summary>
        /// Perform a middle click at selected position
        /// </summary>
        /// <param name="position">Position where you want to click</param>
        void MiddleClick(Position position);
    }
}