using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using VASPSuite.EtherGate.Extensions;
using VASPSuite.EtherGate.Strategies;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class VASPDirectoryClient : VASPRegistryClient, IVASPDirectoryClient
    {
        private static Regex _vaspCredentialsRefRegex = new Regex(@"^0x[0-9a-f]{64}$", RegexOptions.Singleline & RegexOptions.Compiled);
        
        public VASPDirectoryClient(
            Address address,
            IEstimateGasPriceStrategy estimateGasPriceStrategy,
            IWeb3 web3)
            : base(address, estimateGasPriceStrategy, web3)
        {
        }
        
        public override async Task<VASPCredentialsRefAndHash> GetCredentialsRefAndHashAsync(
            VASPId vaspId,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var vaspCredentialsRefAndHash = await base.GetCredentialsRefAndHashAsync(vaspId, minimalConfirmationLevel);
            var (@ref, hash) = vaspCredentialsRefAndHash;
            
            if (VASPCredentialsRef.IsEmpty(@ref) != VASPCredentialsHash.IsEmpty(hash))
            {
                throw new Exception("Smart contract returned an unexpected combination of VASP credentials reference and hash.");
            }

            return vaspCredentialsRefAndHash;
        }
        
        public override async Task<string> GetCredentialsAsync(
            VASPId vaspId,
            VASPCredentialsRef vaspCredentialsRef,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var vaspCredentialsRefString = vaspCredentialsRef.ToString();
            
            if (!_vaspCredentialsRefRegex.IsMatch(vaspCredentialsRefString))
            {
                throw new FormatException("Specified VASP credentials ref is not properly formatted to be used with a VASP directory.");
            }
            
            var credentialsInsertedEventHandler = Web3.Eth.GetEvent<CredentialsInsertedEvent>(ContractAddress);
            var credentialsInsertedEventFilter = credentialsInsertedEventHandler.CreateFilterInput
            (
                firstIndexedParameterValue: (byte[]) vaspId,
                secondIndexedParameterValue: vaspCredentialsRefString.HexToByteArray(),
                fromBlock: BlockParameter.CreateEarliest(),
                toBlock: await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            ); 
  
            var latestCredentials = (await credentialsInsertedEventHandler.GetAllChanges(credentialsInsertedEventFilter))
                .OrderBy(x => x.Log.BlockNumber)
                .Select(x => x.Event.Credentials)
                .LastOrDefault() ?? string.Empty;

            return latestCredentials;
        }
        
        #region Events definitions
        
        [Event("CredentialsInserted")]
        public class CredentialsInsertedEvent : IEventDTO
        {
            [UsedImplicitly]
            [Parameter("bytes6", "vaspId", 1, true )]
            public byte[] VASPId { get; set; }
                = Array.Empty<byte>();
            
            [UsedImplicitly]
            [Parameter("bytes32", "credentialsRef", 2, true )]
            public byte[] CredentialsRef { get; set; }
                = Array.Empty<byte>();

            [UsedImplicitly]
            [Parameter("bytes32", "credentialsHash", 3, true)]
            public byte[] CredentialsHash { get; set; }
                = Array.Empty<byte>();
            
            [UsedImplicitly(ImplicitUseKindFlags.Assign)]
            [Parameter("string", "credentials", 4, false )]
            public string Credentials { get; set; }
                = string.Empty;
        }
        
        #endregion
    }
}