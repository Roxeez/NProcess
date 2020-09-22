using System;
using NProcess.Interop.Enum;

namespace NProcess.Window.Keyboard
{
    /// <summary>
    ///     Keyboard used to send keys to window
    /// </summary>
    public interface IKeyboard
    {
        /// <summary>
        ///     Press and release a key
        /// </summary>
        /// <param name="key">Key to press</param>
        void PressKey(Key key);

        /// <summary>
        ///     Hold a key until Release is called
        /// </summary>
        /// <param name="key">Key to hold</param>
        void HoldKey(Key key);

        /// <summary>
        ///     Hold a key during defined time
        /// </summary>
        /// <param name="key">Key to hold</param>
        /// <param name="time">Time to old</param>
        void HoldKey(Key key, TimeSpan time);

        /// <summary>
        ///     Release hold key
        /// </summary>
        /// <param name="key">Key to release</param>
        void ReleaseKey(Key key);
    }
}