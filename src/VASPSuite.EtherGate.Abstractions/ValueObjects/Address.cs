using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Nethereum.Util;
using VASPSuite.EtherGate.Support;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct Address : IEquatable<Address>
    {
        private readonly ByteArray<Digest> _value;
        
        
        public Address(
            IEnumerable<byte> value)
        {
            _value = new ByteArray<Digest>(value);
        }
        
        private Address(
            ByteArray<Digest> value)
        {
            _value = value;
        }
        
        
        public bool Equals(
            Address other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is Address other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        
        public override string ToString()
        {
            return ToString(true);
        }

        public string ToString(
            bool addChecksum)
        {
            var addressString = _value.ToString();

            return addChecksum
                 ? addressString.ConvertToEthereumChecksumAddress()
                 : addressString;
        }
        
        public static bool IsEmpty(
            Address address)
        {
            return ByteArray<Digest>.IsEmpty(address._value);
        }

        public static Address Parse(
            string value)
        {
            return new Address(ByteArray<Digest>.Parse(value));
        }

        public static implicit operator string(
            Address address)
        {
            return address.ToString();
        }

        public static bool operator ==(
            Address left,
            Address right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            Address left,
            Address right)
        {
            return !left.Equals(right);
        }


        internal class Digest : ByteArrayDigest
        {
            public override bool HasHexPrefix
                => true;

            public override int Length
                => 20;

            public override string RegexPattern
                => @"^0x[0-9a-fA-F]{40}$";
        }
    }
}