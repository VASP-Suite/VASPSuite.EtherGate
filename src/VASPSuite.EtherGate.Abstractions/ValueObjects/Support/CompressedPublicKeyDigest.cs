namespace VASPSuite.EtherGate.Support
{
    internal abstract class CompressedPublicKeyDigest : ByteArrayDigest
    {
        public override bool HasHexPrefix
            => true;

        public override int Length
            => 33;

        public override string RegexPattern
            => @"^0x0[2|3][0-9a-f]{64}$";
    }
}