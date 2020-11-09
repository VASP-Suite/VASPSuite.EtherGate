using System.Numerics;
using System.Threading.Tasks;

namespace VASPSuite.EtherGate.Strategies
{
    public interface IEstimateGasPriceStrategy
    {
        Task<BigInteger> ExecuteAsync();
    }
}