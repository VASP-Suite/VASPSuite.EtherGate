using System.Threading.Tasks;

namespace VASPSuite.EtherGate
{
    public sealed class BlockchainOperation : IBlockchainOperation
    {
        internal BlockchainOperation(
            BlockchainOperationId id)
        {
            Id = id;
        }
        
        
        public BlockchainOperationId Id { get; }
        
        
        public Task<BlockchainOperationState> GetCurrentStateAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<BlockchainOperationState> WaitForExecutionAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}