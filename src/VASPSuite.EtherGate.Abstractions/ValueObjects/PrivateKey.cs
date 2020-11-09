using System;
using System.Collections.Generic;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    public readonly struct PrivateKey : IEquatable<PrivateKey>
    {
        private readonly ByteArray<Digest> _value;
        
        
        public PrivateKey(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private PrivateKey(
            ByteArray<Digest> value)
        {
            _value = value;
        }
        
        
        public bool Equals(
            PrivateKey other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is PrivateKey other && Equals(other);
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
            PrivateKey privateKey)
        {
            return ByteArray<Digest>.IsEmpty(privateKey._value);
        }
        
        public static PrivateKey Parse(
            string value)
        {
            return new PrivateKey(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            PrivateKey left,
            PrivateKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            PrivateKey left,
            PrivateKey right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            PrivateKey privateKey)
        {
            return privateKey._value.ToBytes();
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