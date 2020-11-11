namespace ReplyWorkflow.Outputs
{
    public static partial class SendAckToOwnerResult
    {
        public interface ISendAckToOwnerResult 
        {

        }

        public class AckToOwnerSent : ISendAckToOwnerResult 
        {
            public string Acknowledgment { get; }

            public AckToOwnerSent(string ack)
            {
                Acknowledgment = ack;
            }
        }

        public class AckToOwnerFailed : ISendAckToOwnerResult
        {
            public string FailedAcknowledgment { get; }

            public AckToOwnerFailed( string failedAck)
            {
                FailedAcknowledgment = failedAck;
            }
        }
    }
}