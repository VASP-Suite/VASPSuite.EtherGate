using System.Threading.Tasks;
using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public interface IVASPIndexClient : ISmartContractClient
    {
        Task<IBlockchainOperation> CreateVASPContractAsync(
            Address from,
            VASPCode vaspCode,
            Address owner,
            Channels channels,
            TransportKey transportKey,
            MessageKey messageKey, 
            SigningKey signingKey,
            ConfirmationLevel minimalConfirmationLevel = default);
        
        Task<Address> GetVASPContractAddressAsync(
            VASPCode vaspCode,
            ConfirmationLevel minimalConfirmationLevel = default);

        Task<VASPCode> GetVASPCodeAsync(
            Address vaspContractAddress,
            ConfirmationLevel minimalConfirmationLevel = default);
    }
}