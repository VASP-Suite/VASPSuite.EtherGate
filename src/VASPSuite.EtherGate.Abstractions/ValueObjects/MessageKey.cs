using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct MessageKey : IEquatable<MessageKey>
    {
        private readonly ByteArray<Digest> _value;

        
        public MessageKey(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
            _value.ThrowIfFirstByteIsInvalid();
        }
        
        private MessageKey(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            MessageKey other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is MessageKey other && Equals(other);
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
            MessageKey messageKey)
        {
            return ByteArray<Digest>.IsEmpty(messageKey._value);
        }
        
        public static MessageKey Parse(
            string value)
        {
            return new MessageKey(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            MessageKey left,
            MessageKey right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            MessageKey left,
            MessageKey right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            MessageKey messageKey)
        {
            return messageKey._value.ToBytes();
        }
        
        
        internal class Digest : CompressedPublicKeyDigest
        {
            
        }
    }
}