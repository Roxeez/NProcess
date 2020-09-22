using NProcess.Window.Keyboard;

namespace NProcess.Window
{
    /// <summary>
    ///     Represent a process window
    /// </summary>
    public interface IWindow
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
        ///     Defined if this window is focused or not (foreground)
        /// </summary>
        bool IsFocused { get; }

        /// <summary>
        ///     Keyboard object attached to this window
        /// </summary>
        IKeyboard Keyboard { get; }

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
    }
}