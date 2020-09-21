﻿using System;
using System.Globalization;
using System.Linq;

namespace NProcess.Module
{
    public sealed class Module : IModule
    {
        private readonly IProcess process;
        
        public Module(IProcess process, string name, IntPtr address, int size)
        {
            this.process = process;
            
            Name = name;
            Address = address;
            Size = size;
        }
        
        public string Name { get; }
        public IntPtr Address { get; }
        public int Size { get; }

        public IntPtr FindPattern(string pattern, int offset = 0)
        {
            byte[] knownBytes = pattern.Split(' ').Select(x => x == "??" ? (byte)0 : byte.Parse(x, NumberStyles.HexNumber)).ToArray();
            string[] mask = pattern.Split(' ').Select(x => x == "??" ? "?" : "x").ToArray();

            byte[] dump = process.Memory.Read(Address, Size);
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
                        return new IntPtr((int)Address + i + offset);
                    }
                
                    i += knownBytes.Length - (knownBytes.Length / 2);
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