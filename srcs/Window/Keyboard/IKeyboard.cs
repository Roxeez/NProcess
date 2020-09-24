using System;

namespace NProcess.Window.Keyboard
{
    /// <summary>
    ///     Keyboard used to send keys to window
    /// </summary>
    public interface IKeyboard : IDisposable
    {
        /// <summary>
        ///     Press and release a key
        /// </summary>
        /// <param name="key">Key to press</param>
        void Send(Key key);

        /// <summary>
        ///     Hold a key until Release is called
        /// </summary>
        /// <param name="key">Key to hold</param>
        void Hold(Key key);

        /// <summary>
        ///     Hold a key during defined time
        /// </summary>
        /// <param name="key">Key to hold</param>
        /// <param name="time">Time to old</param>
        void Hold(Key key, TimeSpan time);

        /// <summary>
        ///     Release hold key
        /// </summary>
        /// <param name="key">Key to release</param>
        void Release(Key key);
    }
}