using Nethereum.Web3;

namespace VASPSuite.EtherGate.Features.Support
{
    public class Accounts
    {
        private readonly string[] _accounts;

        public Accounts(
            IWeb3 web3)
        {
            _accounts = web3.Eth.Accounts.SendRequestAsync().Result;
        }

        public Address Deployer
            => Address.Parse(_accounts[0]);
        
        public Address Owner
            => Address.Parse(_accounts[1]);
        
        public Address Administrator
            => Address.Parse(_accounts[2]);
        
        public Address Other
            => Address.Parse(_accounts[9]);
    }
}