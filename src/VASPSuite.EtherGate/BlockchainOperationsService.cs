using JetBrains.Annotations;
using Nethereum.Web3;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class BlockchainOperationsService : IBlockchainOperationsService
    {
        private readonly IWeb3 _web3;

        public BlockchainOperationsService(
            IWeb3 web3)
        {
            _web3 = web3;
        }

        public IBlockchainOperation GetOperation(
            BlockchainOperationId operationId,
            ConfirmationLevel minimalConfirmationLevel = default)
        {
            return new BlockchainOperation(operationId, _web3, minimalConfirmationLevel);
        }
    }
}