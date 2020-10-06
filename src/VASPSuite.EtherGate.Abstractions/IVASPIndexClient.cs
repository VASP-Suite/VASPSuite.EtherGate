using System.Threading.Tasks;
using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public interface IVASPIndexClient
    {
        Task<Address> GetVASPContractAddressAsync(
            VASPCode vaspCode,
            ConfirmationLevel minimalConfirmationLevel = default);

        Task<VASPCode> GetVASPCodeAsync(
            Address vaspContractAddress,
            ConfirmationLevel minimalConfirmationLevel = default);
    }
}