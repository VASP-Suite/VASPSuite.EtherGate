using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using VASPSuite.EtherGate.Strategies;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class VASPIndexClient : SmartContractClient, IVASPIndexClient
    {
        public VASPIndexClient(
            Address address,
            IEstimateGasPriceStrategy estimateGasPriceStrategy,
            IWeb3 web3)
            : base(address, estimateGasPriceStrategy, web3)
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


        public async Task<IBlockchainOperation> CreateVASPContractAsync(
            Address from,
            VASPCode vaspCode,
            Address owner,
            Channels channels,
            TransportKey transportKey,
            MessageKey messageKey,
            SigningKey signingKey,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return await SendTransactionAsync
            (
                from,
                new CreateVASPContractTransaction
                {
                    VASPCode = vaspCode,
                    Owner = owner,
                    Channels = channels,
                    TransportKey = transportKey,
                    MessageKey = messageKey,
                    SigningKey = signingKey
                },
                minimalConfirmationLevel
            );
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

        [Function("createVASPContract", "address")]
        public class CreateVASPContractTransaction : TransactionDefinition<CreateVASPContractTransaction>
        {
            public CreateVASPContractTransaction()
            {
                VASPCode = Array.Empty<byte>();
                Owner = string.Empty;
                Channels = Array.Empty<byte>();
                TransportKey = Array.Empty<byte>();
                MessageKey = Array.Empty<byte>();
                SigningKey = Array.Empty<byte>();
            }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            // ReSharper disable once RedundantArgumentDefaultValue
            [Parameter("bytes4", "vaspCode", 1)]
            public byte[] VASPCode { get; set; }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            [Parameter("address", "owner", 2)]
            public string Owner { get; set; }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            [Parameter("bytes4", "channels", 3)]
            public byte[] Channels { get; set; }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            [Parameter("bytes", "transportKey", 4)]
            public byte[] TransportKey { get; set; }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            [Parameter("bytes", "messageKey", 5)]
            public byte[] MessageKey { get; set; }
            
            [UsedImplicitly(ImplicitUseKindFlags.Access)]
            [Parameter("bytes", "signingKey", 6)]
            public byte[] SigningKey { get; set; }
        }
        
        #endregion
    }
}