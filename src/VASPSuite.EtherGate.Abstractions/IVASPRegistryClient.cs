using System.Threading.Tasks;
using JetBrains.Annotations;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public interface IVASPRegistryClient
    {
        Task<string> GetCredentialsAsync(
            VASPId vaspId,
            VASPCredentialsRef vaspCredentialsRef,
            ConfirmationLevel minimalConfirmationLevel = default);
        
        Task<VASPCredentialsRefAndHash> GetCredentialsRefAndHashAsync(
            VASPId vaspId,
            ConfirmationLevel minimalConfirmationLevel = default);

        Task<bool> ValidateCredentialsAsync(
            string credentials,
            VASPCredentialsHash credentialsHash);
    }
}