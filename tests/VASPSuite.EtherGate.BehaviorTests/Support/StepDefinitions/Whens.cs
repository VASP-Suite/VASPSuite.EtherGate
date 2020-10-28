using System;
using System.IO;
using System.Threading.Tasks;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Web3;
using TechTalk.SpecFlow;
using VASPSuite.EtherGate.BehaviorTests.Support.Extensions;
using VASPSuite.EtherGate.BehaviorTests.Support.SmartContracts;

namespace VASPSuite.EtherGate.BehaviorTests.Support.StepDefinitions
{
    [Binding]
    public class Whens
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWeb3 _web3;
        
        public Whens(
            ScenarioContext scenarioContext,
            IWeb3 web3)
        {
            _scenarioContext = scenarioContext;
            _web3 = web3;
        }
        
        
        [When(@"I call GetChannelsAsync method of a VASPContractClient with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetChannelsAsyncMethodOfVASPContractClient(
            int minimalConfirmationLevel)
        {
            var vaspContract = _scenarioContext.GetContractByType<VASPContract>();
            var vaspContractClient = new EtherGate.VASPContractClient(vaspContract.RealAddress, _web3);

            var callResult = await vaspContractClient
                .GetChannelsAsync(new ConfirmationLevel(minimalConfirmationLevel));
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetMessageKeyAsync method of a VASPContractClient with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetMessageKeyAsyncMethodOfVASPContractClient(
            int minimalConfirmationLevel)
        {
            var vaspContract = _scenarioContext.GetContractByType<VASPContract>();
            var vaspContractClient = new EtherGate.VASPContractClient(vaspContract.RealAddress, _web3);
            
            var callResult = await vaspContractClient
                .GetMessageKeyAsync(new ConfirmationLevel(minimalConfirmationLevel));
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetSigningKeyAsync method of a VASPContractClient with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetSigningKeyAsyncMethodOfVASPContractClient(
            int minimalConfirmationLevel)
        {
            var vaspContract = _scenarioContext.GetContractByType<VASPContract>();
            var vaspContractClient = new EtherGate.VASPContractClient(vaspContract.RealAddress, _web3);
            
            var callResult = await vaspContractClient
                .GetSigningKeyAsync(new ConfirmationLevel(minimalConfirmationLevel));
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetTransportKeyAsync method of a VASPContractClient with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetTransportKeyAsyncMethodOfVASPContractClient(
            int minimalConfirmationLevel)
        {
            var vaspContract = _scenarioContext.GetContractByType<VASPContract>();
            var vaspContractClient = new EtherGate.VASPContractClient(vaspContract.RealAddress, _web3);
            
            var callResult = await vaspContractClient
                .GetTransportKeyAsync(new ConfirmationLevel(minimalConfirmationLevel));
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetVASPCodeAsync method of a VASPContractClient with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetVASPCodeAsyncMethodOfVASPContractClient(
            int minimalConfirmationLevel)
        {
            var vaspContract = _scenarioContext.GetContractByType<VASPContract>();
            var vaspContractClient = new EtherGate.VASPContractClient(vaspContract.RealAddress, _web3);
            
            var callResult = await vaspContractClient
                .GetVASPCodeAsync(new ConfirmationLevel(minimalConfirmationLevel));
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetVASPInfoAsync method of a VASPContractClient with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetVASPInfoAsyncMethodOfVASPContractClient(
            int minimalConfirmationLevel)
        {
            var vaspContract = _scenarioContext.GetContractByType<VASPContract>();
            var vaspContractClient = new EtherGate.VASPContractClient(vaspContract.RealAddress, _web3);
            
            var callResult = await vaspContractClient
                .GetVASPInfoAsync(new ConfirmationLevel(minimalConfirmationLevel));
            
            _scenarioContext.SetCallResult(callResult);
        }

        [When(@"I call GetCredentialsAsync method of a VASPDirectoryClient with a following parameters: ""(.*)"", ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetCredentialsAsyncMethodOfVASPDirectoryClient(
            string vaspId,
            string vaspCredentialsRef,
            int minimalConfirmationLevel)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();
            var vaspDirectoryClient = new EtherGate.VASPDirectoryClient(vaspDirectory.RealAddress, _web3);

            var callResult = await vaspDirectoryClient.GetCredentialsAsync
            (
                vaspId: VASPId.Parse(vaspId),
                vaspCredentialsRef: new VASPCredentialsRef(vaspCredentialsRef),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel) 
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetCredentialsRefAndHashAsync method of a VASPDirectoryClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetCredentialsRefAndHashAsyncMethodOfVASPDirectoryClient(
            string vaspId,
            int minimalConfirmationLevel)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();
            var vaspDirectoryClient = new EtherGate.VASPDirectoryClient(vaspDirectory.RealAddress, _web3);
            
            var callResult = await vaspDirectoryClient.GetCredentialsRefAndHashAsync
            (
                vaspId: VASPId.Parse(vaspId),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel) 
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call VASPIsRegisteredAsync method of a VASPDirectoryClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallVASPIsRegisteredAsyncMethodOfVASPRegistryClient(
            string vaspId,
            int minimalConfirmationLevel)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();
            var vaspDirectoryClient = new EtherGate.VASPDirectoryClient(vaspDirectory.RealAddress, _web3);

            var callResult = await vaspDirectoryClient.VASPIsRegisteredAsync
            (
                vaspId: VASPId.Parse(vaspId),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }

        [When(@"I call GetVASPCodeAsync method of a VASPIndexClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetVASPCodeAsyncMethodOfVASPIndexClient(
            string vaspContractAddress,
            int minimalConfirmationLevel)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            var vaspIndexClient = new EtherGate.VASPIndexClient(vaspIndex.RealAddress, _web3);

            var callResult = await vaspIndexClient.GetVASPCodeAsync
            (
                vaspContractAddress: _scenarioContext.GetRealContractAddress(vaspContractAddress),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call GetVASPContractAddressAsync method of a VASPIndexClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallGetVASPContractAddressAsyncMethodOfVASPIndexClient(
            string vaspCode,
            int minimalConfirmationLevel)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            var vaspIndexClient = new EtherGate.VASPIndexClient(vaspIndex.RealAddress, _web3);

            var callResult = await vaspIndexClient.GetVASPContractAddressAsync
            (
                vaspCode: VASPCode.Parse(vaspCode),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }

        [When(@"I call TryGetVASPCodeAsync method of a VASPIndexClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallTryGetVASPCodeAsyncMethodOfVASPIndexClient(
            string vaspContractAddress,
            int minimalConfirmationLevel)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            var vaspIndexClient = new EtherGate.VASPIndexClient(vaspIndex.RealAddress, _web3);

            var callResult = await vaspIndexClient.TryGetVASPCodeAsync
            (
                vaspContractAddress: _scenarioContext.GetRealContractAddress(vaspContractAddress),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call TryGetVASPContractAddressAsync method of a VASPIndexClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallTryGetVASPContractAddressAsyncMethodOfVASPIndexClient(
            string vaspCode,
            int minimalConfirmationLevel)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            var vaspIndexClient = new EtherGate.VASPIndexClient(vaspIndex.RealAddress, _web3);

            var callResult = await vaspIndexClient.TryGetVASPContractAddressAsync
            (
                vaspCode: VASPCode.Parse(vaspCode),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call TryGetCredentialsAsync method of a VASPDirectoryClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallTryGetCredentialsAsyncMethodOfVASPDirectoryClient(
            string vaspId,
            int minimalConfirmationLevel)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();
            var vaspDirectoryClient = new EtherGate.VASPDirectoryClient(vaspDirectory.RealAddress, _web3);

            var callResult = await vaspDirectoryClient.TryGetCredentialsAsync
            (
                vaspId: VASPId.Parse(vaspId),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call TryGetCredentialsRefAndHashAsync method of a VASPDirectoryClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallTryGetCredentialsRefAndHashAsyncMethodOfVASPDirectoryClient(
            string vaspId,
            int minimalConfirmationLevel)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();
            var vaspDirectoryClient = new EtherGate.VASPDirectoryClient(vaspDirectory.RealAddress, _web3);
            
            var callResult = await vaspDirectoryClient.TryGetCredentialsRefAndHashAsync
            (
                vaspId: VASPId.Parse(vaspId),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call VASPIsRegisteredAsync method of a VASPIndexClient with a following parameters: ""(.*)"", ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public Task ICallVASPIsRegisteredAsyncMethodOfVASPIndexClient(
            string vaspCodeOrContractAddress,
            int minimalConfirmationLevel)
        {
            var vaspIndex = _scenarioContext.GetContractByType<VASPIndex>();
            var vaspIndexClient = new EtherGate.VASPIndexClient(vaspIndex.RealAddress, _web3);
            
            // ReSharper disable once ConvertSwitchStatementToSwitchExpression
            switch (vaspCodeOrContractAddress.Length)
            {
                case 8:
                    return ICallVASPIsRegisteredAsyncMethodOfVASPIndexClient
                    (
                        vaspIndexClient,
                        VASPCode.Parse(vaspCodeOrContractAddress),
                        minimalConfirmationLevel
                    );
                case 42:
                    return ICallVASPIsRegisteredAsyncMethodOfVASPIndexClient
                    (
                        vaspIndexClient,
                        Address.Parse(vaspCodeOrContractAddress),
                        minimalConfirmationLevel
                    );
                default:
                    throw new ArgumentException
                    (
                        "Is definitely neither VASP code, nor VASP contract address",
                        nameof(vaspCodeOrContractAddress)
                    );
            }
        }

        // ReSharper disable once InconsistentNaming
        private async Task ICallVASPIsRegisteredAsyncMethodOfVASPIndexClient(
            IVASPIndexClient vaspIndexClient,
            VASPCode vaspCode,
            int minimalConfirmationLevel)
        {
            var callResult = await vaspIndexClient.VASPIsRegisteredAsync
            (
                vaspCode: vaspCode,
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        // ReSharper disable once InconsistentNaming
        private async Task ICallVASPIsRegisteredAsyncMethodOfVASPIndexClient(
            IVASPIndexClient vaspIndexClient,
            Address vaspContractAddress,
            int minimalConfirmationLevel)
        {
            var callResult = await vaspIndexClient.VASPIsRegisteredAsync
            (
                vaspContractAddress: _scenarioContext.GetRealContractAddress(vaspContractAddress),
                minimalConfirmationLevel: new ConfirmationLevel(minimalConfirmationLevel)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call ValidateCredentialsAsync method of a VASPRegistryClient with a credentials from ""(.*)"" and a following hash ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public async Task ICallValidateCredentialsAsyncMethodOfVASPDirectoryClient(
            string credentialsExamplePath,
            string credentialsHash)
        {
            var vaspDirectory = _scenarioContext.GetContractByType<VASPDirectory>();
            var vaspDirectoryClient = new EtherGate.VASPDirectoryClient(vaspDirectory.RealAddress, _web3);
            
            var callResult = await vaspDirectoryClient.ValidateCredentialsAsync
            (
                credentials: await File.ReadAllTextAsync(credentialsExamplePath),
                credentialsHash: VASPCredentialsHash.Parse(credentialsHash)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call ValidateCredentialsOffline method of a VASPRegistryClient with a credentials from ""(.*)"" and a following hash ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public void ICallValidateCredentialsOfflineMethodOfVASPRegistryClient(
            string credentialsExamplePath,
            string credentialsHash)
        {
            var callResult = EtherGate.VASPRegistryClient.ValidateCredentialsOffline
            (
                credentials: File.ReadAllText(credentialsExamplePath),
                credentialsHash: VASPCredentialsHash.Parse(credentialsHash)
            );
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call ToString method of an Address ""(.*)"" with a following parameter: ""(.*)""")]
        // ReSharper disable once InconsistentNaming
        public void ICallToStringMethodOfAddressWithAFollowingParameter(
            string addressBytes,
            bool addChecksum)
        {
            var callResult = (new Address(addressBytes.HexToByteArray()))
                .ToString(addChecksum);
            
            _scenarioContext.SetCallResult(callResult);
        }
        
        [When(@"I call Parse method of the Address struct with a following parameter: ""(.*)""")]
        public void ICallParseMethodOfAddressStruct(
            string addressString)
        {
            try
            {
                var callResult = Address.Parse(addressString);
            
                _scenarioContext.SetCallResult(callResult);
            }
            catch (Exception e)
            {
                _scenarioContext.SetException(e);
            }
        }
    }
}