using System;
using System.Threading.Tasks;
using Nethereum.Web3;

namespace VASPSuite.EtherGate.BehaviorTests.Support.SmartContracts
{
    public sealed class SmartContractDeployer
    {
        private readonly Accounts _accounts;
        private readonly IWeb3 _web3;

        
        public SmartContractDeployer(
            Accounts accounts,
            IWeb3 web3)
        {
            _accounts = accounts;
            _web3 = web3;
        }


        public async Task<VASPContract> DeployVASPContractAsync(
            VASPCode vaspCode,
            Address owner,
            Channels channels,
            TransportKey transportKey,
            MessageKey messageKey,
            SigningKey signingKey)
        {
            var vaspContractAddress = Address.Parse(await DeployAsync(
                abi: VASPContract.ABI,
                byteCode: VASPContract.ByteCode,
                constructorArguments: new object[]
                {
                    (byte[]) vaspCode,
                    (string) owner,
                    (byte[]) channels,
                    (byte[]) transportKey,
                    (byte[]) messageKey,
                    (byte[]) signingKey
                }
            ));
            
            return new VASPContract(vaspContractAddress, _web3);
        }
        
        public async Task<VASPContractFactory> DeployVASPContractFactoryAsync()
        {
            var vaspContractFactoryAddress = Address.Parse(await DeployAsync
            (
                abi: VASPContractFactory.ABI,
                byteCode: VASPContractFactory.ByteCode,
                constructorArguments: Array.Empty<object>()
            ));
            
            return new VASPContractFactory(vaspContractFactoryAddress, _web3);
        }
        
        public async Task<VASPDirectory> DeployVASPDirectoryAsync(
            Address owner,
            Address administrator)
        {
            var vaspDirectoryAddress = Address.Parse(await DeployAsync
            (
                abi: VASPDirectory.ABI,
                byteCode: VASPDirectory.ByteCode,
                constructorArguments: new object[]
                {
                    (string) owner,
                    (string) administrator
                }
            ));
            
            return new VASPDirectory(vaspDirectoryAddress, _web3);
        }
        
        public async Task<VASPIndex> DeployVASPIndexAsync(
            Address owner,
            VASPContractFactory vaspContractFactory)
        {
            var vaspIndexAddress = Address.Parse(await DeployAsync
            (
                abi: VASPIndex.ABI,
                byteCode: VASPIndex.ByteCode,
                constructorArguments: new object[]
                {
                    (string) owner,
                    (string) vaspContractFactory.RealAddress
                }
            ));
            
            return new VASPIndex(vaspIndexAddress, _web3);
        }

        private async Task<string> DeployAsync(
            string abi,
            string byteCode,
            object[] constructorArguments)
        {
            var gas = await _web3.Eth.DeployContract.EstimateGasAsync
            (
                abi: abi,
                contractByteCode: byteCode,
                @from: await _accounts.GetDeployerAsync(),
                values: constructorArguments
            );

            var receipt = await _web3.Eth.DeployContract.SendRequestAndWaitForReceiptAsync
            (
                abi: abi,
                contractByteCode: byteCode,
                @from: await _accounts.GetDeployerAsync(),
                gas: gas,
                receiptRequestCancellationToken: null,
                values: constructorArguments
            );

            return receipt.ContractAddress;
        }
    }
}