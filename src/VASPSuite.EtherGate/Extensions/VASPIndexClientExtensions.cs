using System.Threading.Tasks;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public static class VASPIndexClientExtensions
    {
        public static async Task<(bool VASPIsRegistered, VASPCode VASPCode)> TryGetVASPCodeAsync(
            this IVASPIndexClient vaspIndex,
            Address vaspContractAddress,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var vaspCode = await vaspIndex.GetVASPCodeAsync(vaspContractAddress, minimalConfirmationLevel);
            var vaspIsRegistered = !VASPCode.IsEmpty(vaspCode);

            return (vaspIsRegistered, vaspCode);
        }
        
        public static async Task<(bool VASPIsRegistered, Address VASPContractAddress)> TryGetVASPContractAddressAsync(
            this IVASPIndexClient vaspIndex,
            VASPCode vaspCode,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var vaspContractAddress = await vaspIndex.GetVASPContractAddressAsync(vaspCode, minimalConfirmationLevel);
            var vaspIsRegistered = !Address.IsEmpty(vaspContractAddress);
            
            return (vaspIsRegistered, vaspContractAddress);
        }

        public static async Task<bool> VASPIsRegisteredAsync(
            this IVASPIndexClient vaspIndex,
            Address vaspContractAddress,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var vaspCode = await vaspIndex.GetVASPCodeAsync(vaspContractAddress, minimalConfirmationLevel);
            
            return !VASPCode.IsEmpty(vaspCode);
        }
        
        public static async Task<bool> VASPIsRegisteredAsync(
            this IVASPIndexClient vaspIndex,
            VASPCode vaspCode,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var vaspContractAddress = await vaspIndex.GetVASPContractAddressAsync(vaspCode, minimalConfirmationLevel);
            
            return !Address.IsEmpty(vaspContractAddress);
        }
    }
}