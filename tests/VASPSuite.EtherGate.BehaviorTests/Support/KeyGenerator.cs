using System;

namespace VASPSuite.EtherGate.BehaviorTests.Support
{
    internal static class KeyGenerator
    {
        private static readonly Random Random = new Random();
        
        
        public static MessageKey GenerateMessageKey()
        {
            return new MessageKey(GenerateRandomKeyBytes());
        }

        public static SigningKey GenerateSigningKey()
        {
            return new SigningKey(GenerateRandomKeyBytes());
        }
        
        public static TransportKey GenerateTransportKey()
        {
            return new TransportKey(GenerateRandomKeyBytes());
        }

        private static byte[] GenerateRandomKeyBytes()
        {
            var bytes = new byte[33];

            Random.NextBytes(bytes);

            if (Random.Next() % 2 != 0)
            {
                bytes[0] = 0x02;
            }
            else
            {
                bytes[0] = 0x03;
            }
            
            return bytes;
        }
    }
}