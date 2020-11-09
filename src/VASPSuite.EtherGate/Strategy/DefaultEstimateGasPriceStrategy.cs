using System.Numerics;
using System.Threading.Tasks;
using Nethereum.Web3;
using VASPSuite.EtherGate.Strategies;

namespace VASPSuite.EtherGate.Strategy
{
    public class DefaultEstimateGasPriceStrategy : IEstimateGasPriceStrategy
    {
        private readonly IWeb3 _web3;


        public DefaultEstimateGasPriceStrategy(
            IWeb3 web3)
        {
            _web3 = web3;
        }

        
        public async Task<BigInteger> ExecuteAsync()
        {
            return (await _web3.Eth.GasPrice.SendRequestAsync()).Value;
        }
    }
}