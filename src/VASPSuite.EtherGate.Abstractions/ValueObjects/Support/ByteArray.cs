using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Nethereum.Hex.HexConvertors.Extensions;

namespace VASPSuite.EtherGate.Support
{
    internal readonly struct ByteArray<T> : IEquatable<ByteArray<T>>
        where T : ByteArrayDigest, new()
    {
        // ReSharper disable StaticMemberInGenericType
        private static readonly T Digest = new T();
        private static readonly ImmutableArray<byte> EmptyValue = ImmutableArray.Create(new byte[Digest.Length]);
        private static readonly Regex Regex = new Regex(Digest.RegexPattern, RegexOptions.Singleline & RegexOptions.Compiled);
        // ReSharper restore StaticMemberInGenericType
        
        
        private readonly ImmutableArray<byte> _value;
        private readonly bool _valueIsSet;


        public ByteArray(
            IEnumerable<byte> value)
        {
            _value = value.ToImmutableArray();
            _valueIsSet = true;

            if (_value.Length != Digest.Length)
            {
                throw new ArgumentException($"Should contain exactly {Digest.Length} bytes.", nameof(value));
            }
        }


        public byte this[int index]
            => Value[index];
        
        private ImmutableArray<byte> Value
            => _valueIsSet ? _value : EmptyValue;

        public bool Equals(
            ByteArray<T> other)
        {
            return Value.SequenceEqual(other.Value);
        }

        public override bool Equals(
            object? obj)
        {
            return obj is ByteArray<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public byte[] ToBytes()
        {
            return Value.ToArray();
        }
        
        public override string ToString()
        {
            var hexStringBuilder = Digest.HasHexPrefix 
                ? new StringBuilder("0x", Digest.Length * 2 + 2)
                : new StringBuilder(Digest.Length * 2);
            
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < Digest.Length; i++)
            {
                hexStringBuilder.Append(_value[i].ToString("X2"));
            }

            return hexStringBuilder.ToString();
        }

        public static bool IsEmpty(
            ByteArray<T> byteArray)
        {
            return byteArray._value.SequenceEqual(EmptyValue);
        }

        public static ByteArray<T> Parse(
            string value)
        {
            if (!Regex.IsMatch(value))
            {
                throw new ArgumentException($"Should match following pattern: {Digest.RegexPattern}.", nameof(value));
            }
            
            return new ByteArray<T>(value.HexToByteArray());
        }
    }
}