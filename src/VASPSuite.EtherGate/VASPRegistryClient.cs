using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Multiformats.Hash;
using Multiformats.Hash.Algorithms;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using VASPSuite.EtherGate.Strategies;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public abstract class VASPRegistryClient : SmartContractClient, IVASPRegistryClient
    {
        protected VASPRegistryClient(
            Address address,
            IEstimateGasPriceStrategy estimateGasPriceStrategy,
            IWeb3 web3)
            : base(address, estimateGasPriceStrategy, web3)
        {
        }
        
        
        public virtual async Task<VASPCredentialsRefAndHash> GetCredentialsRefAndHashAsync(
            VASPId vaspId,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var callResult = await CallWithComplexResultAsync
            (
                new GetCredentialsRefCall { VASPId = vaspId },
                minimalConfirmationLevel
            );

            return new VASPCredentialsRefAndHash
            (
                new VASPCredentialsHash(callResult.CredentialsHashBytes),
                new VASPCredentialsRef(callResult.CredentialsRefString)
            );
        }

        public Task<bool> ValidateCredentialsAsync(
            string credentials,
            VASPCredentialsHash credentialsHash)
        {
            return CallWithSimpleResultAsync
            (
                new ValidateCredentialsCall
                {
                    CredentialsHash = credentialsHash,
                    Credentials = credentials
                }
            );
        }
        
        
        public abstract Task<string> GetCredentialsAsync(
            VASPId vaspId,
            VASPCredentialsRef vaspCredentialsRef,
            ConfirmationLevel minimalConfirmationLevel = default);


        public static bool ValidateCredentialsOffline(
            string credentials,
            VASPCredentialsHash credentialsHash)
        {
            return Multihash
                .Sum<KECCAK_256>(Encoding.UTF8.GetBytes(credentials)).Digest
                .SequenceEqual((byte[]) credentialsHash);
        }
        
        
        #region Call definitions
        
        [Function("getCredentialsRef", typeof(Result))]
        public class GetCredentialsRefCall : CallDefinition<GetCredentialsRefCall, GetCredentialsRefCall.Result>
        {
            public GetCredentialsRefCall()
            {
                VASPId = Array.Empty<byte>();
            }
            
            // ReSharper disable once RedundantArgumentDefaultValue
            [Parameter("bytes6", "vaspId", 1)]
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            public byte[] VASPId { get; set; }
            
            
            [FunctionOutput]
            public class Result : IFunctionOutputDTO 
            {
                public Result()
                {
                    CredentialsHashBytes = Array.Empty<byte>();
                    CredentialsRefString = "0x";
                }
                
                [Parameter("bytes32", "credentialsHash", 2)]
                [UsedImplicitly(ImplicitUseKindFlags.Assign)]
                public byte[] CredentialsHashBytes { get; set; }
                
                // ReSharper disable once RedundantArgumentDefaultValue
                [Parameter("string", "credentialsRef", 1)]
                [UsedImplicitly(ImplicitUseKindFlags.Assign)]
                public string CredentialsRefString { get; set; }
            }
        }
        
        [Function("validateCredentials", "bool")]
        public class ValidateCredentialsCall : CallDefinition<ValidateCredentialsCall, bool>
        {
            public ValidateCredentialsCall()
            {
                CredentialsHash = Array.Empty<byte>();
                Credentials = string.Empty;
            }
            
            // ReSharper disable once RedundantArgumentDefaultValue
            [Parameter("string", "credentials", 1)]
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            public string Credentials { get; set; }
            
            [Parameter("bytes32", "credentialsHash", 2)]
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            public byte[] CredentialsHash { get; set; }
        }
        
        #endregion
    }
}