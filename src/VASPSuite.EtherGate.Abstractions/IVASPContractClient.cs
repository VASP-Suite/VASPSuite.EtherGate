using System.Threading.Tasks;
using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public interface IVASPContractClient : ISmartContractClient
    {
        Task<Channels> GetChannelsAsync(
            ConfirmationLevel minimalConfirmationLevel = default);
   
        Task<TransportKey> GetTransportKeyAsync(
            ConfirmationLevel minimalConfirmationLevel = default);

        Task<MessageKey> GetMessageKeyAsync(
            ConfirmationLevel minimalConfirmationLevel = default);

        Task<SigningKey> GetSigningKeyAsync(
            ConfirmationLevel minimalConfirmationLevel = default);

        Task<VASPCode> GetVASPCodeAsync(
            ConfirmationLevel minimalConfirmationLevel = default);
        
        Task<VASPInfo> GetVASPInfoAsync(
            ConfirmationLevel minimalConfirmationLevel = default);
    }
}