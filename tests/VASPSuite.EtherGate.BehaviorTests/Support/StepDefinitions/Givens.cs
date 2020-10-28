using System.IO;
using System.Threading.Tasks;
using Nethereum.Web3;
using TechTalk.SpecFlow;
using VASPSuite.EtherGate.BehaviorTests.Support.Extensions;
using VASPSuite.EtherGate.BehaviorTests.Support.SmartContracts;

namespace VASPSuite.EtherGate.BehaviorTests.Support.StepDefinitions
{
    [Binding]
    public class Givens
    {
        private readonly Accounts _accounts;
        private readonly ScenarioContext _scenarioContext;
        private readonly SmartContractDeployer _smartContractDeployer;
        private readonly IWeb3 _web3;
        
        public Givens(
            Accounts accounts,
            ScenarioContext scenarioContext,
            SmartContractDeployer smartContractDeployer,
            IWeb3 web3)
        {
            _accounts = accounts;
            _scenarioContext = scenarioContext;
            _smartContractDeployer = smartContractDeployer;
            _web3 = web3;
        }
        
        [Given(@"then (.*) blocks were mined")]
        public async Task ThenNBlocksWereMined(
            int numberOfBlocks)
        {
            for (var i = 0; i < numberOfBlocks; i++)
            {
                await _web3.MineBlockAsync();
            }
        }
        
        [Given(@"VASPDirectory smart contract was deployed")]
        public async Task VASPDirectorySmartContractWasDeployed()
        {
            var vaspDirectory = await _smartContractDeployer.DeployVASPDirectoryAsync
            (
                owner: _accounts.Owner,
                administrator: _accounts.Administrator
            );
            
            _scenarioContext.RegisterContract(vaspDirectory);
        }
        
        [Given(@"VASPIndex smart contract was deployed")]
        public async Task VASPIndexSmartContractWasDeployed()
        {
            var vaspContractFactory = await _smartContractDeployer.DeployVASPContractFactoryAsync();
            var vaspIndex = await _smartContractDeployer.DeployVASPIndexAsync(_accounts.Owner, vaspContractFactory);
            
            _scenarioContext.RegisterContract(vaspIndex);
        }
        
        [Given(@"VASP with a code (.*) created a VASP contract")]
        public async Task VASPCreatedVaspContract(
            string vaspCode)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            
            var vaspContract = await vaspIndex.CreateVASPContractAsync
            (
                vaspContractCreator: _accounts.Deployer,
                vaspCode: VASPCode.Parse(vaspCode),
                vaspContractOwner: _accounts.Owner,
                channels: Channels.Parse("0x00000001"),
                transportKey: KeyGenerator.GenerateTransportKey(),
                messageKey: KeyGenerator.GenerateMessageKey(),
                signingKey: KeyGenerator.GenerateSigningKey()
            );
            
            _scenarioContext.RegisterContract(vaspContract);
        }
        
        [Given(@"VASP with a code (.*) created a VASP contract with an address (.*)")]
        public async Task VASPCreatedVaspContract(
            string vaspCode,
            string vaspContractAddress)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            
            var vaspContract = await vaspIndex.CreateVASPContractAsync
            (
                vaspContractCreator: _accounts.Deployer,
                fakeVASPContractAddress: Address.Parse(vaspContractAddress), 
                vaspCode: VASPCode.Parse(vaspCode),
                vaspContractOwner: _accounts.Owner,
                channels: Channels.Parse("0x00000001"),
                transportKey: KeyGenerator.GenerateTransportKey(),
                messageKey: KeyGenerator.GenerateMessageKey(),
                signingKey: KeyGenerator.GenerateSigningKey()
            );
            
            _scenarioContext.RegisterContract(vaspContract);
        }
        
        [Given(@"VASP set its contract channels to (.*)")]
        public Task VASPSetItsContractChannelsTo(
            string channels)
        {
            return _scenarioContext
                .GetContractByType<VASPContract>()
                .SetChannels
                (
                    owner: _accounts.Owner,
                    channels: Channels.Parse(channels)
                );
        }
        
        [Given(@"VASP set its contract message key to (.*)")]
        public Task VASPSetItsContractMessageKeyTo(
            string messageKey)
        {
            return _scenarioContext
                .GetContractByType<VASPContract>()
                .SetMessageKey
                (
                    owner: _accounts.Owner,
                    messageKey: MessageKey.Parse(messageKey)
                );
        }
        
        [Given(@"VASP set its contract signing key to (.*)")]
        public Task VASPSetItsContractSigningKeyTo(
            string signingKey)
        {
            return _scenarioContext
                .GetContractByType<VASPContract>()
                .SetSigningKey
                (
                    owner: _accounts.Owner,
                    signingKey: SigningKey.Parse(signingKey)
                );
        }
        
        [Given(@"VASP set its contract transport key to (.*)")]
        public Task VASPSetItsContractTransportKeyTo(
            string transportKey)
        {
            return _scenarioContext
                .GetContractByType<VASPContract>()
                .SetTransportKey
                (
                    owner: _accounts.Owner,
                    transportKey: TransportKey.Parse(transportKey)
                );
        }
        
        [Given(@"directory administrator added credentials from ""(.*)"" for the VASP with id ""(.*)""")]
        public async Task DirectoryAdministratorAddedVASPCredentials(
            string credentialsExamplePath,
            string vaspId)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();

            await vaspDirectory.InsertCredentials
            (
                administrator: _accounts.Administrator,
                vaspId: VASPId.Parse(vaspId),
                credentials: await File.ReadAllTextAsync(credentialsExamplePath)
            );
        }
    }
}