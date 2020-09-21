﻿using System;
using System.Linq;

namespace NProcess.Memory
{
    /// <summary>
    /// Represent a pointer
    /// </summary>
    public sealed class Pointer : IEquatable<Pointer>
    {
        /// <summary>
        /// Base address of the pointer
        /// </summary>
        public IntPtr Address { get; }
        
        /// <summary>
        /// Offsets off the pointer
        /// </summary>
        public byte[] Offsets { get; }

        /// <summary>
        /// Create a new pointer
        /// </summary>
        /// <param name="address">Base address of the pointer</param>
        /// <param name="offsets">Offsets of the pointers</param>
        public Pointer(IntPtr address, params byte[] offsets)
        {
            Address = address;
            Offsets = offsets ?? Array.Empty<byte>();
        }

        public bool Equals(Pointer other)
        {
            return other != null && other.Address == Address && Offsets.SequenceEqual(other.Offsets);
        }
        
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((Pointer) obj);
        }
        
        public override int GetHashCode()
        {
            return Address.GetHashCode() + Offsets.Sum(x => x.GetHashCode());
        }

        public static bool operator ==(Pointer left, Pointer right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pointer left, Pointer right)
        {
            return !Equals(left, right);
        }
    }
}