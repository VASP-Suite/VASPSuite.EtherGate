using System;
using System.Globalization;
using System.Numerics;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct ConfirmationLevel : IComparable<ConfirmationLevel>, IEquatable<ConfirmationLevel>
    {
        public static ConfirmationLevel Zero => default;

        private readonly int _value;

        
        public ConfirmationLevel(
            int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Should be greater than zero.", nameof(value));
            }
            
            _value = value;
        }


        public int CompareTo(
            ConfirmationLevel other)
        {
            return _value.CompareTo(other._value);
        }
        
        public bool Equals(
            ConfirmationLevel other)
        {
            return _value == other._value;
        }

        public override bool Equals(
            object? obj)
        {
            return obj is ConfirmationLevel other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public static ConfirmationLevel Parse(
            string value)
        {
            return new ConfirmationLevel(int.Parse(value, CultureInfo.InvariantCulture));
        }
        
        public static bool operator <(
            ConfirmationLevel left,
            ConfirmationLevel right) 
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(
            ConfirmationLevel left,
            ConfirmationLevel right) 
        {
            return left.CompareTo(right) <= 0;
        }
        
        public static bool operator >(
            ConfirmationLevel left,
            ConfirmationLevel right) 
        {
            return left.CompareTo(right) > 0;
        }
        
        public static bool operator >=(
            ConfirmationLevel left,
            ConfirmationLevel right) 
        {
            return left.CompareTo(right) >= 0;
        }
        
        public static bool operator ==(
            ConfirmationLevel left,
            ConfirmationLevel right) 
        {
            return left.Equals(right);
        }
        
        public static bool operator !=(
            ConfirmationLevel left,
            ConfirmationLevel right) 
        {
            return !left.Equals(right);
        }
        
        public static implicit operator BigInteger(
            ConfirmationLevel value)
        {
            return value._value;
        }
    }
}