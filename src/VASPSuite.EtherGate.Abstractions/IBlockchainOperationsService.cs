namespace VASPSuite.EtherGate
{
    public interface IBlockchainOperationsService
    {
        IBlockchainOperation GetOperation(
            BlockchainOperationId operationId,
            ConfirmationLevel minimalConfirmationLevel = default);
    }
}