﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NProcess.Extension;

namespace NProcess.Memory
{
    public abstract class MemoryBase : IMemory
    {
        private readonly Dictionary<Pointer, IntPtr> cachedPointers = new Dictionary<Pointer, IntPtr>();
        
        public T Read<T>(IntPtr address)
        {
            byte[] bytes = Read(address, Marshal.SizeOf<T>());
            TypeCode code = Type.GetTypeCode(typeof(T));

            object value = default;
            switch (code)
            {
                case TypeCode.Object:
                    if (typeof(IntPtr) == typeof(T))
                    {
                        switch (bytes.Length)
                        {
                            case 1:
                                value= new IntPtr(BitConverter.ToInt32(new byte[] { bytes[0], 0, 0, 0}, 0));
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
                    break;
                case TypeCode.Int32:
                    value = BitConverter.ToInt32(bytes, 0);
                    break;
                case TypeCode.Int64:
                    value = BitConverter.ToInt64(bytes, 0);
                    break;
            }

            return value == default ? default : (T)value;
        }

        public T Read<T>(Pointer pointer)
        {
            if (pointer.Offsets.Length == 0)
            {
                return Read<T>(pointer.Address);
            }

            IntPtr address = cachedPointers.GetValueOrDefault(pointer);
            if (address == default)
            {
                address = Read<IntPtr>(pointer.Address);
                for (int i = 0; i < pointer.Offsets.Length - 1; i++)
                {
                    address = Read<IntPtr>(address + pointer.Offsets[i]);
                }

                cachedPointers[pointer] = address;
            }

            return Read<T>(address + pointer.Offsets.Last());
        }

        public abstract byte[] Read(IntPtr address, int length);
    }
}