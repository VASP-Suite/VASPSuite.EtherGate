using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct SigningKey : IEquatable<SigningKey>
    {
        private readonly ByteArray<Digest> _value;

        
        public SigningKey(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
            _value.ThrowIfFirstByteIsInvalid();
        }
        
        private SigningKey(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            SigningKey other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is SigningKey other && Equals(other);
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
            SigningKey signingKey)
        {
            return ByteArray<Digest>.IsEmpty(signingKey._value);
        }
        
        public static SigningKey Parse(
            string value)
        {
            return new SigningKey(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            SigningKey left,
            SigningKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            SigningKey left,
            SigningKey right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            SigningKey signingKey)
        {
            return signingKey._value.ToBytes();
        }
        
        
        internal class Digest : CompressedPublicKeyDigest
        {
            
        }
    }
}