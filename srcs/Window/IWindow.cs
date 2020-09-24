using System;
using System.Drawing;
using NProcess.Window.Keyboard;
using NProcess.Window.Mouse;

namespace NProcess.Window
{
    /// <summary>
    ///     Represent a process window
    /// </summary>
    public interface IWindow : IDisposable, IEquatable<IWindow>
    {
        /// <summary>
        ///     Title of this window
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     Check if this window is main window of process
        /// </summary>
        bool IsMainWindow { get; }
        
        /// <summary>
        /// Handle of the window
        /// </summary>
        IntPtr Handle { get; }
        
        /// <summary>
        /// Process owning this window
        /// </summary>
        IProcess Process { get; }
        
        /// <summary>
        /// Position of the window
        /// </summary>
        Point Position { get; }
        
        /// <summary>
        /// Size of the window
        /// </summary>
        Size Size { get; }

        /// <summary>
        ///     Defined if this window is focused or not (foreground)
        /// </summary>
        bool IsFocused { get; }

        /// <summary>
        ///     Keyboard object attached to this window
        /// </summary>
        IKeyboard Keyboard { get; }

        /// <summary>
        ///     Mouse object attached to this window
        /// </summary>
        IMouse Mouse { get; }

        /// <summary>
        ///     Bring window to front
        /// </summary>
        void Focus();

        /// <summary>
        ///     Hide window
        /// </summary>
        void Hide();

        /// <summary>
        ///     Show window
        /// </summary>
        void Show();

        /// <summary>
        ///     Minimize window
        /// </summary>
        void Minimize();

        /// <summary>
        ///     Maximize window (take all screen space)
        /// </summary>
        void Maximize();

        /// <summary>
        ///     Restore window
        ///     Ex: if window was minimized window will be at the same position where it was before being minimized
        /// </summary>
        void Restore();

        /// <summary>
        /// Close window
        /// </summary>
        void Close();

        /// <summary>
        /// Resize window
        /// </summary>
        /// <param name="width">Width of window</param>
        /// <param name="height">Height of window</param>
        void Resize(int width, int height);
        
        /// <summary>
        /// Move window
        /// </summary>
        /// <param name="x">X position of window</param>
        /// <param name="y">Y position of window</param>
        void Move(int x, int y);
    }
}