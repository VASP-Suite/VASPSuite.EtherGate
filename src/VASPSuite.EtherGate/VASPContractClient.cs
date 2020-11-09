using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using VASPSuite.EtherGate.Extensions;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class VASPContractClient : SmartContractClient, IVASPContractClient
    {
        public VASPContractClient(
            Address address,
            IWeb3 web3)
            : base(address, web3)
        {
        }

        
        public async Task<Channels> GetChannelsAsync(
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return await GetChannelsAsync
            (
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }
        
        private async Task<Channels> GetChannelsAsync(
            BlockParameter block)
        {
            var callResult = await CallWithSimpleResultAsync(ChannelsCall.Empty, block);

            return new Channels(callResult);
        }
        
        public async Task<MessageKey> GetMessageKeyAsync(
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return await GetMessageKeyAsync
            (
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }
        
        private async Task<MessageKey> GetMessageKeyAsync(
            BlockParameter block)
        {
            var callResult = await CallWithSimpleResultAsync(MessageKeyCall.Empty, block);

            return new MessageKey(callResult);
        }

        public async Task<SigningKey> GetSigningKeyAsync(
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return await GetSigningKeyAsync
            (
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }

        private async Task<SigningKey> GetSigningKeyAsync(
            BlockParameter block)
        {
            var callResult = await CallWithSimpleResultAsync(SigningKeyCall.Empty, block);

            return new SigningKey(callResult);
        }
        
        public async Task<TransportKey> GetTransportKeyAsync(
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return await GetTransportKeyAsync
            (
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }
        
        private async Task<TransportKey> GetTransportKeyAsync(
            BlockParameter block)
        {
            var callResult = await CallWithSimpleResultAsync(TransportKeyCall.Empty, block);

            return new TransportKey(callResult);
        }

        public async Task<VASPCode> GetVASPCodeAsync(
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return await GetVASPCodeAsync
            (
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }
        
        private async Task<VASPCode> GetVASPCodeAsync(
            BlockParameter block)
        {
            var callResult = await CallWithSimpleResultAsync(VASPCodeCall.Empty, block);
            
            return new VASPCode(callResult);
        }

        public async Task<VASPInfo> GetVASPInfoAsync(
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            var block = await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel);
            
            var getChannels = GetChannelsAsync(block);
            var getVASPCode = GetVASPCodeAsync(block);
            var getMessageKey = GetMessageKeyAsync(block);
            var getSigningKey = GetSigningKeyAsync(block);
            var getTransportKey = GetTransportKeyAsync(block);

            await Task.WhenAll(getChannels, getVASPCode, getMessageKey, getSigningKey, getTransportKey);
            
            return new VASPInfo
            (
                channels:     await getChannels,
                vaspCode:     await getVASPCode,
                messageKey:   await getMessageKey,
                signingKey:   await getSigningKey,
                transportKey: await getTransportKey
            );
        }

        #region Call definitions

        [Function("channels", "bytes4")]
        public class ChannelsCall : CallDefinition<ChannelsCall, byte[]>
        {
        }

        [Function("messageKey", "bytes")]
        public class MessageKeyCall : CallDefinition<MessageKeyCall, byte[]>
        {
        }

        [Function("signingKey", "bytes")]
        public class SigningKeyCall : CallDefinition<SigningKeyCall, byte[]>
        {
        }

        [Function("transportKey", "bytes")]
        public class TransportKeyCall : CallDefinition<TransportKeyCall, byte[]>
        {
        }
        
        [Function("vaspCode", "bytes4")]
        public class VASPCodeCall : CallDefinition<VASPCodeCall, byte[]>
        {
        }
        
        #endregion
    }
}