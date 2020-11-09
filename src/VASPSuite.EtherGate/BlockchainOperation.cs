using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class BlockchainOperation : IBlockchainOperation
    {
        private readonly ConfirmationLevel _minimalConfirmationLevel;
        private readonly IWeb3 _web3;
        
        internal BlockchainOperation(
            BlockchainOperationId id,
            IWeb3 web3,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            _minimalConfirmationLevel = minimalConfirmationLevel;
            _web3 = web3;
            Id = id;
        }
        
        
        public BlockchainOperationId Id { get; }
        
        
        public async Task<BlockchainOperationState> GetCurrentStateAsync()
        {
            var receipt = await _web3.Eth.Transactions
                .GetTransactionReceipt
                .SendRequestAsync(Id);

            if (receipt != null)
            {
                if (receipt.Succeeded())
                {
                    // TODO: Need to think about caching the best block number
                    var currentBlock = await _web3.Eth.Blocks
                        .GetBlockNumber
                        .SendRequestAsync();

                    var currentConfirmationLevel = currentBlock.Value - receipt.BlockNumber.Value;
                    var remainingConfirmationLevel = _minimalConfirmationLevel - currentConfirmationLevel;

                    if (remainingConfirmationLevel > 0)
                    {
                        return new BlockchainOperationState.WaitingForConfirmation(remainingConfirmationLevel);
                    }
                    
                    return new BlockchainOperationState.Completed();
                }

                // ReSharper disable once InvertIf
                if (receipt.Failed())
                {
                    var error = await _web3.Eth
                        .GetContractTransactionErrorReason
                        .SendRequestAsync(Id);
                    
                    return new BlockchainOperationState.Failed(error);
                }
            }
            else
            {
                return new BlockchainOperationState.Pending();
            }

            throw new NotSupportedException("Blockchain operation is in an unexpected state.");
        }

        public async Task WaitForExecutionAsync(
            CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var state = await GetCurrentStateAsync();
                
                if (state is BlockchainOperationState.Completed || state is BlockchainOperationState.Failed)
                {
                    break;
                }
                
                // TODO: Make delay configurable
                await Task.Delay(30000, cancellationToken);
            }
        }
    }
}