using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;


namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class VASPIndexClient : SmartContractClient, IVASPIndexClient
    {
        public VASPIndexClient(
            Address address,
            IWeb3 web3)
            : base(address, web3)
        {
            
        }
        
        
        public async Task<VASPCode> GetVASPCodeAsync(
            Address vaspContractAddress,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var callResult = await CallWithSimpleResultAsync
            (
                new GetVASPCodeByAddressCall { VASPAddress = vaspContractAddress },
                minimalConfirmationLevel
            );

            return new VASPCode(callResult);
        }


        public Task<IBlockchainOperation> CreateVASPContractAsync(
            VASPCode vaspCode,
            Address owner,
            Channels channels,
            TransportKey transportKey,
            MessageKey messageKey,
            SigningKey signingKey)
        {
            throw new NotImplementedException();
        }

        public async Task<Address> GetVASPContractAddressAsync(
            VASPCode vaspCode,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var callResult = await CallWithSimpleResultAsync
            (
                new GetVASPAddressByCodeCall { VASPCode = vaspCode },
                minimalConfirmationLevel
            );

            return Address.Parse(callResult);
        }


        #region Call definitions
        
        [Function("getVASPAddressByCode", "address")]
        public class GetVASPAddressByCodeCall : CallDefinition<GetVASPAddressByCodeCall, string>
        {
            public GetVASPAddressByCodeCall()
            {
                VASPCode = Array.Empty<byte>();
            }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            // ReSharper disable once RedundantArgumentDefaultValue
            [Parameter("bytes4", "vaspCode", 1)]
            public byte[] VASPCode { get; set; }
        }
        
        [Function("getVASPCodeByAddress", "bytes4")]
        public class GetVASPCodeByAddressCall : CallDefinition<GetVASPCodeByAddressCall, byte[]>
        {
            public GetVASPCodeByAddressCall()
            {
                VASPAddress = string.Empty;
            }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            // ReSharper disable once RedundantArgumentDefaultValue
            [Parameter("address", "vaspAddress", 1)]
            public string VASPAddress { get; set; }
        }
        
        #endregion
    }
}