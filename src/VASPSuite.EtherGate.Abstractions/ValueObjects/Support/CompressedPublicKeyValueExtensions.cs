using System;

namespace VASPSuite.EtherGate.Support
{
    internal static class CompressedPublicKeyValueExtensions
    {
        // ReSharper disable ParameterOnlyUsedForPreconditionCheck.Global
        public static void ThrowIfFirstByteIsInvalid<T>(
                this ByteArray<T> value)
            where T : CompressedPublicKeyDigest, new()
        {
            if (value[0] != 0x02 && value[0] != 0x03)
            {
                throw new ArgumentException
                (
                    "First byte of should should be either 0x02, or 0x03.",
                    nameof(value)
                );
            }
        }
        // ReSharper restore ParameterOnlyUsedForPreconditionCheck.Global
    }
}