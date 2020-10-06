using Nethereum.Web3;

namespace VASPSuite.EtherGate.Features.Support.SmartContracts
{
    public abstract class SmartContract
    {
        public SmartContract(
            Address address,
            IWeb3 web3)
        {
            FakeAddress = address;
            RealAddress = address;
            Web3 = web3;
        }
        
        protected SmartContract(
            Address fakeAddress,
            Address realAddress,
            IWeb3 web3)
        {
            FakeAddress = fakeAddress;
            RealAddress = realAddress;
            Web3 = web3;
        }

        
        public Address FakeAddress { get; }
        
        public Address RealAddress { get; }
        
        protected IWeb3 Web3 { get; }
    }
}