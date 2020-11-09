namespace VASPSuite.EtherGate
{
    public interface IVASPKeysGenerator
    {
        (MessageKey, PrivateKey) GenerateMessageKey();
        
        (SigningKey, PrivateKey) GenerateSigningKey();
        
        (TransportKey, PrivateKey) GenerateTransportKey();
    }
}