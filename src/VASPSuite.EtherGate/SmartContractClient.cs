using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using VASPSuite.EtherGate.Extensions;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public abstract class SmartContractClient : ISmartContractClient
    {
        protected SmartContractClient(
            Address contractAddress,
            IWeb3 web3)
        {
            ContractAddress = contractAddress;
            Web3 = web3;
        }
        
        
        public Address ContractAddress { get; }
        
        protected IWeb3 Web3 { get; }

        
        protected Task<TResult> CallWithComplexResultAsync<TQuery, TResult>(
            CallDefinition<TQuery, TResult> callDefinition)        
            where TQuery : CallDefinition<TQuery, TResult>, new()
            where TResult : IFunctionOutputDTO, new()
        {
            return CallWithComplexResultAsync
            (
                callDefinition,
                ConfirmationLevel.Zero
            );
        }
        
        protected async Task<TResult> CallWithComplexResultAsync<TQuery, TResult>(
            CallDefinition<TQuery, TResult> callDefinition,
            ConfirmationLevel minimalConfirmationLevel)        
            where TQuery : CallDefinition<TQuery, TResult>, new()
            where TResult : IFunctionOutputDTO, new()
        {
            return await CallWithComplexResultAsync
            (
                callDefinition,
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }
        
        protected Task<TResult> CallWithComplexResultAsync<TQuery, TResult>(
            CallDefinition<TQuery, TResult> callDefinition,
            BlockParameter block)        
            where TQuery : CallDefinition<TQuery, TResult>, new()
            where TResult : IFunctionOutputDTO, new()
        {
            return Web3.Eth
                .GetContractQueryHandler<TQuery>()
                .QueryDeserializingToObjectAsync<TResult>
                (
                    contractAddress: ContractAddress,
                    functionMessage: (TQuery) callDefinition,
                    block: block
                );
        }

        protected Task<TResult> CallWithSimpleResultAsync<TQuery, TResult>(
            CallDefinition<TQuery, TResult> callDefinition)        
            where TQuery : CallDefinition<TQuery, TResult>, new()
        {
            return CallWithSimpleResultAsync
            (
                callDefinition,
                ConfirmationLevel.Zero
            );
        }
        
        protected async Task<TResult> CallWithSimpleResultAsync<TQuery, TResult>(
            CallDefinition<TQuery, TResult> callDefinition,
            ConfirmationLevel minimalConfirmationLevel)        
            where TQuery : CallDefinition<TQuery, TResult>, new()
        {
            return await CallWithSimpleResultAsync
            (
                callDefinition,
                await Web3.GetBestTrustedBlockAsync(minimalConfirmationLevel)
            );
        }

        protected Task<TResult> CallWithSimpleResultAsync<TQuery, TResult>(
            CallDefinition<TQuery, TResult> callDefinition,
            BlockParameter block)        
            where TQuery : CallDefinition<TQuery, TResult>, new()
        {
            return Web3.Eth
                .GetContractQueryHandler<TQuery>()
                .QueryAsync<TResult>
                (
                    contractAddress: ContractAddress,
                    functionMessage: (TQuery) callDefinition,
                    block: block
                );
        }

        protected async Task<TransactionReceipt> SendTransactionAndWaitForReceiptAsync<TParameters>(
            TransactionDefinition<TParameters> transactionDefinition)
            where TParameters : TransactionDefinition<TParameters>, new()
        {
            throw new NotImplementedException();

            //var transactionInput = await Web3.Eth
            //    .GetContractTransactionHandler<TParameters>()
            //    .CreateTransactionInputEstimatingGasAsync
            //    (
            //        ContractAddress,
            //        (TParameters) transactionDefinition
            //    );
        }
        
        public class CallDefinition<TQuery, TResult> : FunctionMessage
            where TQuery : CallDefinition<TQuery, TResult>, new()
        {
            public static TQuery Empty
                => new TQuery();
        }

        public class TransactionDefinition<TParameters> : FunctionMessage
            where TParameters : TransactionDefinition<TParameters>, new()
        {
            public static TParameters Empty
                => new TParameters();
        }
    }
}