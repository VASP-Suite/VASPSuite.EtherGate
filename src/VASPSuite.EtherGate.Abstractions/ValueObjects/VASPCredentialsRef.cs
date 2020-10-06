using System;
using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct VASPCredentialsRef : IEquatable<VASPCredentialsRef>
    {
        private readonly string _value;

        public VASPCredentialsRef(
            string value)
        {
            _value = value;
        }

        
        public bool Equals(
            VASPCredentialsRef other)
        {
            return _value == other._value;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is VASPCredentialsRef other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }
        
        public override string ToString()
        {
            return _value;
        }

        public static bool IsEmpty(
            VASPCredentialsRef vaspCredentialsRef)
        {
            return string.IsNullOrEmpty(vaspCredentialsRef._value);
        }
        
        public static bool operator ==(
            VASPCredentialsRef left,
            VASPCredentialsRef right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(
            VASPCredentialsRef left,
            VASPCredentialsRef right)
        {
            return !left.Equals(right);
        }
    }
}