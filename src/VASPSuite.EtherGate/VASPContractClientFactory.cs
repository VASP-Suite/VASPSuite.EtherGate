using JetBrains.Annotations;
using Nethereum.Web3;
using VASPSuite.EtherGate.Strategies;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class VASPContractClientFactory : IVASPContractClientFactory
    {
        private readonly IEstimateGasPriceStrategy _estimateGasPriceStrategy;
        private readonly IWeb3 _web3;
        
        
        public VASPContractClientFactory(
            IEstimateGasPriceStrategy estimateGasPriceStrategy,
            IWeb3 web3)
        {
            _estimateGasPriceStrategy = estimateGasPriceStrategy;
            _web3 = web3;
        }
        
        
        public IVASPContractClient CreateVASPContractClient(
            Address vaspContractAddress)
        {
            return new VASPContractClient(vaspContractAddress, _estimateGasPriceStrategy, _web3);
        }
    }
}