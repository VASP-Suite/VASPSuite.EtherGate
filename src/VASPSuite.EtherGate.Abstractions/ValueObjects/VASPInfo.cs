using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    [StructLayout(LayoutKind.Auto)]
    public readonly struct VASPInfo
    {
        public VASPInfo(
            Channels channels,
            VASPCode vaspCode,
            MessageKey messageKey,
            SigningKey signingKey,
            TransportKey transportKey)
        {
            Channels = channels;
            VASPCode = vaspCode;
            MessageKey = messageKey;
            SigningKey = signingKey;
            TransportKey = transportKey;
        }

        
        public Channels Channels { get; }
        
        public VASPCode VASPCode { get; }
        
        public MessageKey MessageKey { get; }
        
        public SigningKey SigningKey { get; }
        
        public TransportKey TransportKey { get; }
    }
}