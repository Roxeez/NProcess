using System.Drawing;
using NProcess.Interop.Struct;

namespace NProcess.Extension
{
    public static class RectExtensions
    {
        public static Rectangle ToRectangle(this Rect rect)
        {
            return new Rectangle
            {
                X = rect.Left,
                Y = rect.Top,
                Width = rect.Right - rect.Left + 1,
                Height = rect.Bottom - rect.Top + 1
            };
        }

        public static Point ToPoint(this Rectangle rectangle)
        {
            return new Point(rectangle.X, rectangle.Y);
        }

        public static Size ToSize(this Rectangle rectangle)
        {
            return new Size(rectangle.Width, rectangle.Height);
        }
    }
}