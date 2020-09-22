using System;
using System.Globalization;
using System.Linq;
using NProcess.Memory;
using NProcess.Module;

namespace NProcess.Extension
{
    public static class ModuleExtensions
    {
        public static IntPtr FindPattern(this IModule module, Pattern pattern)
        {
            byte[] knownBytes = pattern.Content.Split(' ').Select(x => x == "??" ? (byte)0 : byte.Parse(x, NumberStyles.HexNumber)).ToArray();
            string[] mask = pattern.Content.Split(' ').Select(x => x == "??" ? "?" : "x").ToArray();

            byte[] dump = module.Process.Memory.Read(module.Address, module.Size);
            for (int i = 0; i < dump.Length; i++)
            {
                if (dump[i] == knownBytes[0])
                {
                    var region = new byte[mask.Length];
                    for (int j = 0; j < region.Length; j++)
                    {
                        region[j] = dump[i + j];
                    }

                    if (IsPatternMatching(knownBytes, region, mask))
                    {
                        return new IntPtr(module.Address.ToInt32() + i + pattern.Offset);
                    }

                    i += knownBytes.Length - knownBytes.Length / 2;
                }
            }

            return IntPtr.Zero;
        }

        private static bool IsPatternMatching(byte[] knownBytes, byte[] region, string[] mask)
        {
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == "?")
                {
                    continue;
                }

                if (knownBytes[i] == region[i])
                {
                    continue;
                }

                return false;
            }

            return true;
        }
    }
}