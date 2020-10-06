using System;
using System.IO;
using Shouldly;
using TechTalk.SpecFlow;
using VASPSuite.EtherGate.Features.Support.Extensions;

namespace VASPSuite.EtherGate.Features.Support.StepDefinitions
{
    [Binding]
    public class Thens
    {
        private readonly ScenarioContext _scenarioContext;
        
        
        public Thens(
            ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        
        
        [Then(@"the GetVASPCodeAsync call result should be ""(.*)""")]
        public void GetVASPCodeAsyncCallResultShouldBe(
            string expectedVASPCode)
        {
            _scenarioContext
                .GetCallResult<VASPCode>()
                .ShouldBe(VASPCode.Parse(expectedVASPCode));
        }
        
        [Then(@"the GetChannelsAsync call result should be ""(.*)""")]
        public void GetChannelsAsyncCallResultShouldBe(
            string channels)
        {
            _scenarioContext
                .GetCallResult<Channels>()
                .ShouldBe(Channels.Parse(channels));
        }
        
        [Then(@"the GetMessageKeyAsync call result should be ""(.*)""")]
        public void GetMessageKeyAsyncCallResultShouldBe(
            string messageKey)
        {
            _scenarioContext
                .GetCallResult<MessageKey>()
                .ShouldBe(MessageKey.Parse(messageKey));
        }
        
        [Then(@"the GetSigningKeyAsync call result should be ""(.*)""")]
        public void GetSigningKeyAsyncCallResultShouldBe(
            string signingKey)
        {
            _scenarioContext
                .GetCallResult<SigningKey>()
                .ShouldBe(SigningKey.Parse(signingKey));
        }
        
        [Then(@"the GetTransportKeyAsync call result should be ""(.*)""")]
        public void GetTransportKeyAsyncCallResultShouldBe(
            string transportKey)
        {
            _scenarioContext
                .GetCallResult<TransportKey>()
                .ShouldBe(TransportKey.Parse(transportKey));
        }
        
        [Then(@"the (.*) property of the GetVASPInfoAsync call result should be ""(.*)""")]
        public void SpecifiedPropertyOfTheGetVASPInfoAsyncCallResultShouldBe(
            string propertyName,
            string propertyValue)
        {
            var callResult = _scenarioContext.GetCallResult<VASPInfo>();

            switch (propertyName)
            {
                case "Channels":
                    callResult.Channels
                        .ShouldBe(Channels.Parse(propertyValue));
                    break;
                case "MessageKey":
                    callResult.MessageKey
                        .ShouldBe(MessageKey.Parse(propertyValue));
                    break;
                case "SigningKey":
                    callResult.SigningKey
                        .ShouldBe(SigningKey.Parse(propertyValue));
                    break;
                case "TransportKey":
                    callResult.TransportKey
                        .ShouldBe(TransportKey.Parse(propertyValue));
                    break;
                case "VASPCode":
                    callResult.VASPCode
                        .ShouldBe(VASPCode.Parse(propertyValue));
                    break;
                default:
                    throw new ArgumentException("Unexpected property name");
            }
        }
        
        [Then(@"the GetCredentialsAsync call should return credentials presented in ""(.*)""")]
        public void GetCredentialsAsyncCallShouldReturnCredentialsPresentedIn(
            string credentialsExamplePath)
        {
            _scenarioContext
                .GetCallResult<string>()
                .ShouldBe(File.ReadAllText(credentialsExamplePath));
        }
        
        [Then(@"the Ref property of the GetCredentialsRefAndHashAsync call result should be ""(.*)""")]
        public void VASPCredentialsRefPropertyOfGetCredentialsRefAndHashAsyncCallResultShouldBe(
            string expectedResult)
        {
            _scenarioContext
                .GetCallResult<VASPCredentialsRefAndHash>()
                .Ref
                .ShouldBe(new VASPCredentialsRef(expectedResult));
        }
        
        [Then(@"the Hash property of the GetCredentialsRefAndHashAsync call result should be ""(.*)""")]
        public void VASPCredentialsHashPropertyOfGetCredentialsRefAndHashAsyncCallResultShouldBe(
            string expectedResult)
        {
            _scenarioContext
                .GetCallResult<VASPCredentialsRefAndHash>()
                .Hash
                .ShouldBe(VASPCredentialsHash.Parse(expectedResult));
        }
        
        [Then(@"the GetVASPContractAddressAsync call result should be ""(.*)""")]
        public void GetVASPContractAddressAsyncCallResultShouldBe(
            string expectedVASPContractAddress)
        {
            _scenarioContext
                .GetCallResult<Address>()
                .ShouldBe(_scenarioContext.GetFakeContractAddress(expectedVASPContractAddress));
        }

        [Then(@"the TryGetVASPCodeAsync call result should be \(""(.*)"", ""(.*)""\)")]
        public void TryGetVASPCodeAsyncCallResultShouldBe(
            bool expectedVASPIsRegistered,
            string expectedVASPCode)
        {
            _scenarioContext
                .GetCallResult<(bool, VASPCode)>()
                .ShouldBe((expectedVASPIsRegistered, VASPCode.Parse(expectedVASPCode)));
        }
        
        [Then(@"the TryGetVASPContractAddressAsync call result should be \(""(.*)"", ""(.*)""\)")]
        public void TryGetVASPContractAddressAsyncCallResultShouldBe(
            bool expectedVASPIsRegistered,
            string expectedVASPContractAddress)
        {
            _scenarioContext
                .GetCallResult<(bool, Address)>()
                .ShouldBe((expectedVASPIsRegistered, _scenarioContext.GetFakeContractAddress(expectedVASPContractAddress)));
        }
        
        [Then(@"the VASPIsRegisteredAsync call result should be ""(.*)""")]
        public void VASPIsRegisteredAsyncCallResultShouldBe(
            bool expectedVASPIsRegistered)
        {
            _scenarioContext
                .GetCallResult<bool>()
                .ShouldBe(expectedVASPIsRegistered);
        }
        
        [Then(@"the ValidateCredentialsAsync call result should be ""(.*)""")]
        public void ValidateCredentialsAsyncCallResultShouldBe(
            bool expectedResult)
        {
            _scenarioContext
                .GetCallResult<bool>()
                .ShouldBe(expectedResult);
        }
        
        [Then(@"the ValidateCredentialsOffline call result should be ""(.*)""")]
        public void ValidateCredentialsOfflineCallResultShouldBe(
            bool expectedResult)
        {
            _scenarioContext
                .GetCallResult<bool>()
                .ShouldBe(expectedResult);
        }
        
        [Then(@"the VASPIsRegistered property of the TryGetCredentialsAsync call result should be ""(.*)""")]
        public void VASPIsRegisteredPropertyOfTryGetCredentialsAsyncCallResultShouldBe(
            bool expectedResult)
        {
            _scenarioContext
                .GetCallResult<(bool VASPIsRegistered, string Credentials)>()
                .VASPIsRegistered
                .ShouldBe(expectedResult);
        }
        
        [Then(@"the Credentials property of the TryGetCredentialsAsync call result should be presented in ""(.*)""")]
        public void CredentialsPropertyOfTryGetCredentialsAsyncCallResultShouldBePresentedIn(
            string credentialsExamplePath)
        {
            var expectedResult = File.ReadAllText(credentialsExamplePath);
            
            _scenarioContext
                .GetCallResult<(bool VASPIsRegistered, string Credentials)>()
                .Credentials
                .ShouldBe(expectedResult);
        }
        
        [Then(@"the VASPIsRegistered property of the TryGetCredentialsRefAndHashAsync call result should be ""(.*)""")]
        public void VASPIsRegisteredPropertyOfTryGetCredentialsRefAndHashAsyncCallResultShouldBe(
            bool expectedResult)
        {
            _scenarioContext
                .GetCallResult<(bool VASPIsRegistered, VASPCredentialsRefAndHash vaspCredentialsRefAndHash)>()
                .VASPIsRegistered
                .ShouldBe(expectedResult);
        }
        
        [Then(@"the VASPCredentialsRefAndHash property of the TryGetCredentialsRefAndHashAsync call result should be \(""(.*)"", ""(.*)""\)")]
        public void VASPCredentialsRefAndHashPropertyOfTheTryGetCredentialsRefAndHashAsyncCallResultShouldBe(
            string expectedRef,
            string expectedHash)
        {
            var (actualRef, actualHash) = _scenarioContext
                .GetCallResult<(bool VASPIsRegistered, VASPCredentialsRefAndHash VASPCredentialsRefAndHash)>()
                .VASPCredentialsRefAndHash;
            
            actualRef
                .ShouldBe(new VASPCredentialsRef(expectedRef));
            
            actualHash
                .ShouldBe(VASPCredentialsHash.Parse(expectedHash));
        }
    }
}