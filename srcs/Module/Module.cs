﻿using System;
 using System.Collections.Generic;
 using System.Diagnostics;
 using System.Globalization;
using System.Linq;
 using System.Runtime.InteropServices;
 using NProcess.Extension;
 using NProcess.Memory;

 namespace NProcess.Module
{
    public sealed class Module : IModule
    {
        private readonly Dictionary<Pattern, IntPtr> cachedPatterns;
        
        public Module(IProcess process, string name, IntPtr address, int size)
        {
            Process = process;
            Name = name;
            Address = address;
            Size = size;
            
            cachedPatterns = new Dictionary<Pattern, IntPtr>();
        }
        
        public string Name { get; }
        public IntPtr Address { get; }
        public int Size { get; }
        public IProcess Process { get; }
        
        public T ReadMemory<T>(IntPtr address)
        {
            Type type = typeof(T);
            byte[] bytes = Process.MemoryReader.Read(address, Marshal.SizeOf<T>());
            
            object value = default;
            if (type == typeof(IntPtr))
            {
                switch (bytes.Length)
                {
                    case 1:
                        value = new IntPtr(BitConverter.ToInt32(new byte[] { bytes[0], 0, 0, 0}, 0));
                        break;
                    case 2:
                        value = new IntPtr(BitConverter.ToInt32(new byte[] { bytes[0], bytes[1], 0, 0 }, 0));
                        break;
                    case 4:
                        value = new IntPtr(BitConverter.ToInt32(bytes, 0));
                        break;
                    case 8:
                        value = new IntPtr(BitConverter.ToInt64(bytes, 0));
                        break;
                }
            }
            else if (type == typeof(int))
            {
                value = BitConverter.ToInt32(bytes, 0);
            }
            else if (type == typeof(long))
            {
                value = BitConverter.ToInt64(bytes, 0);
            }

            return value == default ? default : (T)value;
        }

        public void WriteMemory<T>(IntPtr address, T value)
        {
            throw new NotImplementedException();
        }

        public IntPtr GetPointer(IntPtr address, params byte[] offsets)
        {
            IntPtr read = ReadMemory<IntPtr>(address);
            for (int i = 0; i < offsets.Length - 1; i++)
            {
                read = ReadMemory<IntPtr>(new IntPtr(read.ToInt32() + offsets[i]));
            }

            return read + offsets.Last();
        }

        public IntPtr GetPointer(Pattern pattern, params byte[] offsets)
        {
            IntPtr output = cachedPatterns.GetValueOrDefault(pattern);
            if (output == IntPtr.Zero)
            {
                output = this.Find(pattern);
                if (output == IntPtr.Zero)
                {
                    return IntPtr.Zero;
                }

                cachedPatterns[pattern] = output;
            }

            IntPtr address = ReadMemory<IntPtr>(output);
            if (address == IntPtr.Zero)
            {
                return address;
            }

            return GetPointer(ReadMemory<IntPtr>(address), offsets);
        }
    }
}