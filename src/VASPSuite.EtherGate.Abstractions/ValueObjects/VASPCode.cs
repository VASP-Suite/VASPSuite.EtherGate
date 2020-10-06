using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct VASPCode : IEquatable<VASPCode>
    {
        private readonly ByteArray<Digest> _value;

        
        public VASPCode(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private VASPCode(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            VASPCode other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is VASPCode other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public static bool IsEmpty(
            VASPCode vaspCode)
        {
            return ByteArray<Digest>.IsEmpty(vaspCode._value);
        }
        
        public static VASPCode Parse(
            string value)
        {
            return new VASPCode(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            VASPCode left,
            VASPCode right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            VASPCode left,
            VASPCode right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            VASPCode vaspCode)
        {
            return vaspCode._value.ToBytes();
        }
        
        
        internal class Digest : ByteArrayDigest
        {
            public override bool HasHexPrefix
                => false;

            public override int Length
                => 4;

            public override string RegexPattern
                => @"^[0-9a-f]{8}$";
        }
    }
}