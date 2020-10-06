using System.Threading.Tasks;
using JetBrains.Annotations;

// ReSharper disable once CheckNamespace
namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public static class VASPDirectoryClientExtensions
    {
        private static bool VASPIsRegistered(
            VASPCredentialsRefAndHash vaspCredentialsRefAndHash)
        {
            var (@ref, hash) = vaspCredentialsRefAndHash;
            
            return !(VASPCredentialsRef.IsEmpty(@ref) && VASPCredentialsHash.IsEmpty(hash));
        }
        
        public static async Task<bool> VASPIsRegisteredAsync(
            this IVASPDirectoryClient vaspDirectory,
            VASPId vaspId,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var refAndHash = await vaspDirectory.GetCredentialsRefAndHashAsync(vaspId, minimalConfirmationLevel);
            
            return VASPIsRegistered(refAndHash); 
        }

        public static async Task<(bool VASPIsRegistered, VASPCredentialsRefAndHash VASPCredentialsRefAndHash)> TryGetCredentialsRefAndHashAsync(
            this IVASPDirectoryClient vaspDirectory,
            VASPId vaspId,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var refAndHash = await vaspDirectory.GetCredentialsRefAndHashAsync(vaspId, minimalConfirmationLevel);
            var vaspIsRegistered = VASPIsRegistered(refAndHash);

            return (vaspIsRegistered, refAndHash);
        }
        
        public static async Task<(bool VASPIsRegistered, string Credentials)> TryGetCredentialsAsync(
            this IVASPDirectoryClient vaspDirectory,
            VASPId vaspId,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var (vaspIsRegistered, (@ref, _)) =
                await vaspDirectory.TryGetCredentialsRefAndHashAsync(vaspId, minimalConfirmationLevel);
            
            var credentials =
                vaspIsRegistered ? await vaspDirectory.GetCredentialsAsync(vaspId, @ref, minimalConfirmationLevel) : string.Empty;

            return (vaspIsRegistered, credentials);
        }
    }
}