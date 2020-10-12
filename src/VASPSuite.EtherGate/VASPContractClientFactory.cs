using JetBrains.Annotations;
using Nethereum.Web3;

namespace VASPSuite.EtherGate
{
    [PublicAPI]
    public sealed class VASPContractClientFactory : IVASPContractClientFactory
    {
        private readonly IWeb3 _web3;
        
        
        public VASPContractClientFactory(
            IWeb3 web3)
        {
            _web3 = web3;
        }
        
        
        public IVASPContractClient CreateVASPContractClient(
            Address vaspContractAddress)
        {
            return new VASPContractClient(vaspContractAddress, _web3);
        }
    }
}