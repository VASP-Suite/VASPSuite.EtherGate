using System.Threading.Tasks;
using Nethereum.Web3;

namespace VASPSuite.EtherGate.BehaviorTests.Support
{
    public class Accounts
    {
        private readonly IWeb3 _web3;

        
        public Accounts(
            IWeb3 web3)
        {
            _web3 = web3;
        }


        private async Task<Address> GetAddressAsync(
            int index)
        {
            var accounts = await _web3.Eth.Accounts.SendRequestAsync();

            return Address.Parse(accounts[index]);
        }
        
        public Task<Address> GetDeployerAsync()
            => GetAddressAsync(0);
        
        public Task<Address> GetOwnerAsync()
            => GetAddressAsync(1);
        
        public Task<Address> GetAdministratorAsync()
            => GetAddressAsync(2);
        
        public Task<Address> GetOtherAsync()
            => GetAddressAsync(9);
    }
}