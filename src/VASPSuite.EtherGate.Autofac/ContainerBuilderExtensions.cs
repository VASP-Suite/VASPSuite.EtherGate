using Autofac.Builder;
using JetBrains.Annotations;
using Nethereum.Web3;
using VASPSuite.EtherGate;
using VASPSuite.EtherGate.Strategies;
using VASPSuite.EtherGate.Strategy;

// ReSharper disable once CheckNamespace
namespace Autofac
{
    #region Shorthands

    // ReSharper disable IdentifierTypo
    
    using IBlockchainOperationServiceRegistrationBuilder
        = IRegistrationBuilder<IBlockchainOperationsService, SimpleActivatorData, SingleRegistrationStyle>;
    
    using IVASPContractClientFactoryRegistrationBuilder 
        = IRegistrationBuilder<IVASPContractClientFactory, SimpleActivatorData, SingleRegistrationStyle>;

    using IVASPDirectoryClientRegistrationBuilder
        = IRegistrationBuilder<IVASPDirectoryClient, SimpleActivatorData, SingleRegistrationStyle>;
    
    using IVASPIndexClientRegistrationBuilder
        = IRegistrationBuilder<IVASPIndexClient, SimpleActivatorData, SingleRegistrationStyle>;
    
    // ReSharper restore IdentifierTypo

    #endregion
    
    [PublicAPI]
    public static class ContainerBuilderExtensions
    {
        internal static ContainerBuilder RegisterDefaultEstimateGasPriceStrategy(
            this ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterType<DefaultEstimateGasPriceStrategy>()
                .As<IEstimateGasPriceStrategy>()
                .IfNotRegistered(typeof(IEstimateGasPriceStrategy));

            return containerBuilder;
        }
        
        public static IBlockchainOperationServiceRegistrationBuilder RegisterBlockchainOperationsService(
            this ContainerBuilder containerBuilder)
        {
            return containerBuilder
                .Register<IBlockchainOperationsService>(context => new BlockchainOperationsService
                (
                    web3: context.Resolve<IWeb3>()
                ));
        }
        
        public static IVASPContractClientFactoryRegistrationBuilder RegisterVASPContractClientFactory(
            this ContainerBuilder containerBuilder)
        {
            return containerBuilder
                .RegisterDefaultEstimateGasPriceStrategy()
                .Register<IVASPContractClientFactory>(context => new VASPContractClientFactory
                (
                    estimateGasPriceStrategy: context.Resolve<IEstimateGasPriceStrategy>(),
                    web3: context.Resolve<IWeb3>()
                ));
        }

        public static IVASPDirectoryClientRegistrationBuilder RegisterVASPDirectoryClient(
            this ContainerBuilder containerBuilder,
            Address vaspDirectoryAddress)
        {
            return containerBuilder
                .RegisterDefaultEstimateGasPriceStrategy()
                .Register<IVASPDirectoryClient>(context => new VASPDirectoryClient
                (
                    address: vaspDirectoryAddress,
                    estimateGasPriceStrategy: context.Resolve<IEstimateGasPriceStrategy>(),
                    web3: context.Resolve<IWeb3>()
                ));
        }
        
        public static IVASPDirectoryClientRegistrationBuilder RegisterVASPDirectoryClient(
            this ContainerBuilder containerBuilder,
            string vaspDirectoryAddress)
        {
            return containerBuilder
                .RegisterDefaultEstimateGasPriceStrategy()
                .RegisterVASPDirectoryClient
                (
                    vaspDirectoryAddress: Address.Parse(vaspDirectoryAddress)
                );
        }
        
        public static IVASPIndexClientRegistrationBuilder RegisterVASPIndexClient(
            this ContainerBuilder containerBuilder,
            Address vaspIndexAddress)
        {
            return containerBuilder
                .RegisterDefaultEstimateGasPriceStrategy()
                .Register<IVASPIndexClient>(context => new VASPIndexClient
                (
                    address: vaspIndexAddress,
                    estimateGasPriceStrategy: context.Resolve<IEstimateGasPriceStrategy>(),
                    web3: context.Resolve<IWeb3>()
                ));
        }
        
        public static IVASPIndexClientRegistrationBuilder RegisterVASPIndexClient(
            this ContainerBuilder containerBuilder,
            string vaspIndexAddress)
        {
            return containerBuilder
                .RegisterDefaultEstimateGasPriceStrategy()
                .RegisterVASPIndexClient
                (
                    vaspIndexAddress: Address.Parse(vaspIndexAddress)
                );
        }
    }
}