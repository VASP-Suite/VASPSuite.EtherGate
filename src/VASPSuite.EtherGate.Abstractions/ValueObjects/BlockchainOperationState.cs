namespace VASPSuite.EtherGate
{
    public abstract class BlockchainOperationState
    {
        public sealed class Completed : BlockchainOperationState
        {
            
        }
        
        public sealed class Failed : BlockchainOperationState
        {
            public Failed(
                string reason)
            {
                Reason = reason;
            }
            
            public string Reason { get; }
        }
        
        public sealed class Pending : BlockchainOperationState
        {
            
        }
        
        public sealed class WaitingForConfirmation : BlockchainOperationState
        {
            public WaitingForConfirmation(
                ConfirmationLevel remainingConfirmationLevel)
            {
                RemainingConfirmationLevel = remainingConfirmationLevel;
            }
            
            public ConfirmationLevel RemainingConfirmationLevel { get; }
        }
    }
}