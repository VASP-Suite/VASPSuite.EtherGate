using System.Linq;
using Cryptography.ECDSA;

namespace VASPSuite.EtherGate.BehaviorTests.Support
{
    internal static class VASPKeysPairValidator
    {
        public static bool IsValid(
            // ReSharper disable once ParameterTypeCanBeEnumerable.Global
            byte[] publicKey,
            byte[] privateKey)
        {
            return Secp256K1Manager
                .GetPublicKey(privateKey, true)
                .SequenceEqual(publicKey);
        }
    }
}