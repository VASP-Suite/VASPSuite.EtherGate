using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct Channels : IEquatable<Channels>
    {
        private readonly ByteArray<Digest> _value;

        
        public Channels(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private Channels(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            Channels other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is Channels other && Equals(other);
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
            Channels channels)
        {
            return ByteArray<Digest>.IsEmpty(channels._value);
        }
        
        public static Channels Parse(
            string value)
        {
            return new Channels(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            Channels left,
            Channels right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            Channels left,
            Channels right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            Channels channels)
        {
            return channels._value.ToBytes();
        }
        
        
        internal class Digest : ByteArrayDigest
        {
            public override bool HasHexPrefix
                => true;

            public override int Length
                => 4;

            public override string RegexPattern
                => @"^0x[0-9a-f]{8}$";
        }
    }
}