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
                owner: await _accounts.GetOwnerAsync(),
                administrator: await _accounts.GetAdministratorAsync()
            );
            
            _scenarioContext.RegisterContract(vaspDirectory);
        }
        
        [Given(@"VASPIndex smart contract was deployed")]
        public async Task VASPIndexSmartContractWasDeployed()
        {
            var owner = await _accounts.GetOwnerAsync();
            var vaspContractFactory = await _smartContractDeployer.DeployVASPContractFactoryAsync();
            var vaspIndex = await _smartContractDeployer.DeployVASPIndexAsync(owner, vaspContractFactory);
            
            _scenarioContext.RegisterContract(vaspIndex);
        }
        
        [Given(@"VASP with a code (.*) created a VASP contract")]
        public async Task VASPCreatedVaspContract(
            string vaspCode)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            
            var vaspContract = await vaspIndex.CreateVASPContractAsync
            (
                vaspContractCreator: await _accounts.GetDeployerAsync(),
                vaspCode: VASPCode.Parse(vaspCode),
                vaspContractOwner: await _accounts.GetOwnerAsync(),
                channels: Channels.Parse("0x00000001"),
                transportKey: MockKeyGenerator.GenerateTransportKey(),
                messageKey: MockKeyGenerator.GenerateMessageKey(),
                signingKey: MockKeyGenerator.GenerateSigningKey()
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
                vaspContractCreator: await _accounts.GetDeployerAsync(),
                fakeVASPContractAddress: Address.Parse(vaspContractAddress), 
                vaspCode: VASPCode.Parse(vaspCode),
                vaspContractOwner: await _accounts.GetOwnerAsync(),
                channels: Channels.Parse("0x00000001"),
                transportKey: MockKeyGenerator.GenerateTransportKey(),
                messageKey: MockKeyGenerator.GenerateMessageKey(),
                signingKey: MockKeyGenerator.GenerateSigningKey()
            );
            
            _scenarioContext.RegisterContract(vaspContract);
        }
        
        [Given(@"VASP set its contract channels to (.*)")]
        public async Task VASPSetItsContractChannelsTo(
            string channels)
        {
            await _scenarioContext
                .GetContractByType<VASPContract>()
                .SetChannels
                (
                    owner: await _accounts.GetOwnerAsync(),
                    channels: Channels.Parse(channels)
                );
        }
        
        [Given(@"VASP set its contract message key to (.*)")]
        public async Task VASPSetItsContractMessageKeyTo(
            string messageKey)
        {
            await _scenarioContext
                .GetContractByType<VASPContract>()
                .SetMessageKey
                (
                    owner: await _accounts.GetOwnerAsync(),
                    messageKey: MessageKey.Parse(messageKey)
                );
        }
        
        [Given(@"VASP set its contract signing key to (.*)")]
        public async Task VASPSetItsContractSigningKeyTo(
            string signingKey)
        {
            await _scenarioContext
                .GetContractByType<VASPContract>()
                .SetSigningKey
                (
                    owner: await _accounts.GetOwnerAsync(),
                    signingKey: SigningKey.Parse(signingKey)
                );
        }
        
        [Given(@"VASP set its contract transport key to (.*)")]
        public async Task VASPSetItsContractTransportKeyTo(
            string transportKey)
        {
            await _scenarioContext
                .GetContractByType<VASPContract>()
                .SetTransportKey
                (
                    owner: await _accounts.GetOwnerAsync(),
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
                administrator: await _accounts.GetAdministratorAsync(),
                vaspId: VASPId.Parse(vaspId),
                credentials: await File.ReadAllTextAsync(credentialsExamplePath)
            );
        }
    }
}