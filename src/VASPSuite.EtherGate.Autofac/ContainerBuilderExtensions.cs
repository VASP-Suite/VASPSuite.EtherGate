using Autofac.Builder;
using JetBrains.Annotations;
using Nethereum.Web3;
using VASPSuite.EtherGate;

// ReSharper disable once CheckNamespace
namespace Autofac
{
    #region Shorthands

    // ReSharper disable IdentifierTypo
    
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
        public static IVASPContractClientFactoryRegistrationBuilder RegisterVASPContractClientFactory(
            this ContainerBuilder containerBuilder)
        {
            return containerBuilder
                .Register<IVASPContractClientFactory>(context => new VASPContractClientFactory
                (
                        web3: context.Resolve<IWeb3>()
                ));
        }

        public static IVASPDirectoryClientRegistrationBuilder RegisterVASPDirectoryClient(
            this ContainerBuilder containerBuilder,
            Address vaspDirectoryAddress)
        {
            return containerBuilder
                .Register<IVASPDirectoryClient>(context => new VASPDirectoryClient
                (
                    address: vaspDirectoryAddress,
                    web3: context.Resolve<IWeb3>()
                ));
        }
        
        public static IVASPDirectoryClientRegistrationBuilder RegisterVASPDirectoryClient(
            this ContainerBuilder containerBuilder,
            string vaspDirectoryAddress)
        {
            return containerBuilder
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
                .Register<IVASPIndexClient>(context => new VASPIndexClient
                (
                    address: vaspIndexAddress,
                    web3: context.Resolve<IWeb3>()
                ));
        }
        
        public static IVASPIndexClientRegistrationBuilder RegisterVASPIndexClient(
            this ContainerBuilder containerBuilder,
            string vaspIndexAddress)
        {
            return containerBuilder
                .RegisterVASPIndexClient
                (
                    vaspIndexAddress: Address.Parse(vaspIndexAddress)
                );
        }
    }
}