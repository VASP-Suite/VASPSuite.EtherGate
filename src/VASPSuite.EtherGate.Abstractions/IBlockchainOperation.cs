using System.Threading;
using System.Threading.Tasks;

namespace VASPSuite.EtherGate
{
    public interface IBlockchainOperation
    {
        BlockchainOperationId Id { get; }
        
        Task<BlockchainOperationState> GetCurrentStateAsync();
        
        Task WaitForExecutionAsync(
            CancellationToken cancellationToken = default);
    }
}