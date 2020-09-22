using System.Runtime.InteropServices;

namespace NProcess.Extension
{
    public static class ArrayExtensions
    {
        public static int GetMarshalSize<T>(this T[] array)
        {
            return Marshal.SizeOf<T>() * array.Length;
        }
    }
}