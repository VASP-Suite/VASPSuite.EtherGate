using System.Collections.Generic;
using JetBrains.Annotations;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct VASPId
    {
        private readonly ByteArray<Digest> _value;

        
        public VASPId(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private VASPId(
            ByteArray<Digest> value)
        {
            _value = value;
        }

        
        public bool Equals(
            VASPId other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is VASPId other && Equals(other);
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
            VASPId vaspId)
        {
            return ByteArray<Digest>.IsEmpty(vaspId._value);
        }
        
        public static VASPId Parse(
            string value)
        {
            return new VASPId(ByteArray<Digest>.Parse(value));
        }

        public static bool operator ==(
            VASPId left,
            VASPId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            VASPId left,
            VASPId right)
        {
            return !left.Equals(right);
        }
        
        public static implicit operator byte[](
            VASPId vaspId)
        {
            return vaspId._value.ToBytes();
        }
        
        
        internal class Digest : ByteArrayDigest
        {
            public override bool HasHexPrefix
                => false;

            public override int Length
                => 6;

            public override string RegexPattern
                => @"^[0-9a-f]{12}$";
        }
    }
}