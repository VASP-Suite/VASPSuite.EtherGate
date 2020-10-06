using System.Threading.Tasks;
using Nethereum.Web3;

namespace VASPSuite.EtherGate.Features.Support.Extensions
{
    internal static class Web3Extensions
    {
        public static Task MineBlockAsync(
            this IWeb3 web3)
        {
            return web3.Client.SendRequestAsync("evm_mine");
        }
    }
}