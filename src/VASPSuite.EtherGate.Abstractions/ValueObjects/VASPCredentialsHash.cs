using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct VASPCredentialsHash : IEquatable<VASPCredentialsHash>
    {
        private readonly ByteArray<Digest> _value;

        
        public VASPCredentialsHash(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private VASPCredentialsHash(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            VASPCredentialsHash other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is VASPCredentialsHash other && Equals(other);
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
            VASPCredentialsHash vaspCredentialsHash)
        {
            return ByteArray<Digest>.IsEmpty(vaspCredentialsHash._value);
        }
        
        public static VASPCredentialsHash Parse(
            string value)
        {
            return new VASPCredentialsHash(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            VASPCredentialsHash left,
            VASPCredentialsHash right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            VASPCredentialsHash left,
            VASPCredentialsHash right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            VASPCredentialsHash vaspCredentialsHash)
        {
            return vaspCredentialsHash._value.ToBytes();
        }
        
        
        internal class Digest : ByteArrayDigest
        {
            public override bool HasHexPrefix
                => true;

            public override int Length
                => 32;

            public override string RegexPattern
                => @"^0x[0-9a-f]{64}$";
        }
    }
}