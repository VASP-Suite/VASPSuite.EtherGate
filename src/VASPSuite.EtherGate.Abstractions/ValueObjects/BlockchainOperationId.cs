using System;
using System.Collections.Generic;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    public readonly struct BlockchainOperationId : IEquatable<BlockchainOperationId>
    {
        private readonly ByteArray<Digest> _value;
        
        
        public BlockchainOperationId(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private BlockchainOperationId(
            ByteArray<Digest> value)
        {
            _value = value;
        }
        
        public bool Equals(
            BlockchainOperationId other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is BlockchainOperationId other && Equals(other);
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
            BlockchainOperationId operationId)
        {
            return ByteArray<Digest>.IsEmpty(operationId._value);
        }
        
        public static BlockchainOperationId Parse(
            string value)
        {
            return new BlockchainOperationId(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            BlockchainOperationId left,
            BlockchainOperationId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            BlockchainOperationId left,
            BlockchainOperationId right)
        {
            return !left.Equals(right);
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