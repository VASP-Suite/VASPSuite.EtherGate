using System.Threading.Tasks;

namespace VASPSuite.EtherGate
{
    public interface IBlockchainOperation
    {
        BlockchainOperationId Id { get; }
        
        Task<BlockchainOperationState> GetCurrentStateAsync();
        
        Task<BlockchainOperationState> WaitForExecutionAsync();
    }
}