using Cryptography.ECDSA;

namespace VASPSuite.EtherGate
{
    public sealed class VASPKeysGenerator : IVASPKeysGenerator
    {
        public (MessageKey, PrivateKey) GenerateMessageKey()
        {
            var (publicKey, privateKey) = GenerateKeyPair();
            
            return (new MessageKey(publicKey), new PrivateKey(privateKey));
        }

        public (SigningKey, PrivateKey) GenerateSigningKey()
        {
            var (publicKey, privateKey) = GenerateKeyPair();

            return (new SigningKey(publicKey), new PrivateKey(privateKey));
        }

        public (TransportKey, PrivateKey) GenerateTransportKey()
        {
            var (publicKey, privateKey) = GenerateKeyPair();
            
            return (new TransportKey(publicKey), new PrivateKey(privateKey));
        }

        private (byte[], byte[]) GenerateKeyPair()
        {
            var privateKey = Secp256K1Manager.GenerateRandomKey();
            var publicKey = Secp256K1Manager.GetPublicKey(privateKey, compressed: true);

            return (publicKey, privateKey);
        }
    }
}