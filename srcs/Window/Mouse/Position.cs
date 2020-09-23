namespace NProcess.Window.Mouse
{
    /// <summary>
    /// Represent a position X/Y
    /// </summary>
    public readonly struct Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}