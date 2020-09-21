﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NProcess.Extension;

namespace NProcess.Memory
{
    public abstract class MemoryBase : IMemory
    {
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

        public T Read<T>(IntPtr address, params byte[] offsets)
        {
            if (offsets == null || offsets.Length == 0)
            {
                return Read<T>(address);
            }
            
            IntPtr read = Read<IntPtr>(address);
            for (int i = 0; i < offsets.Length - 1; i++)
            {
                read = Read<IntPtr>(read + offsets[i]);
            }
            
            return Read<T>(read + offsets.Last());
        }

        public abstract byte[] Read(IntPtr address, int length);
    }
}