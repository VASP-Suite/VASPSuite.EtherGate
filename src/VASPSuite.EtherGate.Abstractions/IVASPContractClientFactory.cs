namespace VASPSuite.EtherGate
{
    public interface IVASPContractClientFactory
    {
        IVASPContractClient CreateVASPContractClient(
            Address vaspContractAddress);
    }
}