using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using VASPSuite.EtherGate.BehaviorTests.Support.SmartContracts;

namespace VASPSuite.EtherGate.BehaviorTests.Support.Extensions
{
    internal static class ScenarioContextExtensions
    {
        private const string CallResultKey = "CallResult";
        private const string ExceptionKey = "Exception";

        
        public static T GetCallResult<T>(
            this ScenarioContext scenarioContext)
        {
            return (T) scenarioContext[CallResultKey];
        }
        
        public static Exception? GetException(
            this ScenarioContext scenarioContext)
        {
            return scenarioContext.ContainsKey(ExceptionKey)
                ? scenarioContext[ExceptionKey] as Exception
                : null;
        }
        
        public static T GetContractByFakeAddress<T>(
            this ScenarioContext scenarioContext,
            Address fakeAddress)
            where T : SmartContract
        {
            return (T) scenarioContext
                .GetContracts()
                .Single(x => x.FakeAddress == fakeAddress);
        }
        
        public static T GetContractByRealAddress<T>(
            this ScenarioContext scenarioContext,
            Address realAddress)
            where T : SmartContract
        {
            return (T) scenarioContext
                .GetContracts()
                .Single(x => x.RealAddress == realAddress);
        }
        
        public static T GetContractByType<T>(
            this ScenarioContext scenarioContext)
            where T : SmartContract
        {
            return (T) scenarioContext
                .GetContracts()
                .First(x => x is T);
        }

        public static Address GetFakeContractAddress(
            this ScenarioContext scenarioContext,
            Address realAddress)
        {
            var contract = scenarioContext
                .GetContracts()
                .SingleOrDefault(x => x.RealAddress == realAddress);

            return contract?.FakeAddress ?? realAddress;
        }
        
        public static Address GetFakeContractAddress(
            this ScenarioContext scenarioContext,
            string realAddress)
        {
            return scenarioContext.GetRealContractAddress(Address.Parse(realAddress));
        }
        
        public static Address GetRealContractAddress(
            this ScenarioContext scenarioContext,
            Address fakeAddress)
        {
            var contract = scenarioContext
                .GetContracts()
                .SingleOrDefault(x => x.FakeAddress == fakeAddress);

            return contract?.RealAddress ?? fakeAddress;
        }
        
        public static Address GetRealContractAddress(
            this ScenarioContext scenarioContext,
            string fakeAddress)
        {
            return scenarioContext.GetRealContractAddress(Address.Parse(fakeAddress));
        }

        public static void RegisterContract<T>(
            this ScenarioContext scenarioContext,
            T contract)
            where T : SmartContract
        {
            scenarioContext
                .GetContracts()
                .Add(contract);
        }
        
        public static void SetCallResult<T>(
            this ScenarioContext scenarioContext,
            T callResult)
        {
            scenarioContext[CallResultKey] = callResult;
        }
        
        public static void SetException<T>(
            this ScenarioContext scenarioContext,
            T exception)
            where T : Exception
        {
            scenarioContext[ExceptionKey] = exception;
        }
        
        private static ICollection<SmartContract> GetContracts(
            this ScenarioContext scenarioContext)
        {
            const string key = "Contracts";

            if (!scenarioContext.ContainsKey(key))
            {
                scenarioContext[key] = new List<SmartContract>(); 
            }

            return (ICollection<SmartContract>) scenarioContext[key];
        }
    }
}