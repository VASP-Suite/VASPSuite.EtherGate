using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public readonly struct VASPCredentialsRefAndHash
    {
        public VASPCredentialsRefAndHash(
            VASPCredentialsHash hash,
            VASPCredentialsRef @ref)
        {
            Hash = hash;
            Ref = @ref;
        }

        
        public VASPCredentialsHash Hash { get; }
        
        public VASPCredentialsRef Ref { get; }
        
        
        public void Deconstruct(
            out VASPCredentialsRef @ref,
            out VASPCredentialsHash hash)
        {
            hash = Hash;
            @ref = Ref;
        }
    }
}