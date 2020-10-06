using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct TransportKey : IEquatable<TransportKey>
    {
        private readonly ByteArray<Digest> _value;

        
        public TransportKey(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
            _value.ThrowIfFirstByteIsInvalid();
        }
        
        private TransportKey(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            TransportKey other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is TransportKey other && Equals(other);
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
            TransportKey transportKey)
        {
            return ByteArray<Digest>.IsEmpty(transportKey._value);
        }
        
        public static TransportKey Parse(
            string value)
        {
            return new TransportKey(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            TransportKey left,
            TransportKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            TransportKey left,
            TransportKey right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            TransportKey transportKey)
        {
            return transportKey._value.ToBytes();
        }
        
        
        internal class Digest : CompressedPublicKeyDigest
        {
            
        }
    }
}