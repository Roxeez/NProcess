namespace NProcess.Window.Mouse
{
    /// <summary>
    ///     Mouse used to click in window
    /// </summary>
    public interface IMouse
    {
        /// <summary>
        ///     Perform a left click at selected position
        /// </summary>
        /// <param name="x">X position where you want to click</param>
        /// <param name="y">Y position where you want to click</param>
        void LeftClick(int x, int y);

        /// <summary>
        ///     Perform a right click at selected position
        /// </summary>
        /// <param name="x">X position where you want to click</param>
        /// <param name="y">Y position where you want to click</param>
        void RightClick(int x, int y);

        /// <summary>
        ///     Perform a middle click at selected position
        /// </summary>
        /// <param name="x">X position where you want to click</param>
        /// <param name="y">Y position where you want to click</param>
        void MiddleClick(int x, int y);
    }
}