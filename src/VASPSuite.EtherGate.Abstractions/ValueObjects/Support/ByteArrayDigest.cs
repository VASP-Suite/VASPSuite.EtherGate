namespace VASPSuite.EtherGate.Support
{
    internal abstract class ByteArrayDigest
    {
        public abstract bool HasHexPrefix { get; }
        
        public abstract int Length { get; }
        
        public abstract string RegexPattern { get; }
    }
}