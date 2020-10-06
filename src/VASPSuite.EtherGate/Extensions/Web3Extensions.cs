using System.Threading.Tasks;
using Nethereum.Hex.HexTypes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;

namespace VASPSuite.EtherGate.Extensions
{
    internal static class Web3Extensions
    {
        public static async Task<BlockParameter> GetBestTrustedBlockAsync(
            this IWeb3 web3,
            ConfirmationLevel minimalConfirmationLevel)
        {
            if (minimalConfirmationLevel > ConfirmationLevel.Zero)
            {
                var bestBlockNumber = (await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync()).Value;
                var bestTrustedBlockNumber = bestBlockNumber - minimalConfirmationLevel; 
                
                return new BlockParameter(new HexBigInteger(bestTrustedBlockNumber));
            }
            else
            {
                return BlockParameter.CreateLatest();
            }
        }
    }
}