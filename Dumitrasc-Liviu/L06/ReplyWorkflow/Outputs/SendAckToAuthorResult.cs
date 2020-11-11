namespace ReplyWorkflow.Outputs
{
    public static partial class SendAckToAuthorResult
    {
        public interface ISendAckToAuthorResult 
        {

        }

        public class AckToAuthorSent : ISendAckToAuthorResult 
        {
            public string Acknowledgment { get; }

            public AckToAuthorSent(string ack)
            {
                Acknowledgment = ack;
            }
        }

        public class AckToAuthorFailed : ISendAckToAuthorResult 
        {
            public string FailedAcknowledgment { get; }

            public AckToAuthorFailed( string failedAck)
            {
                FailedAcknowledgment = failedAck;
            }
        }
    }
}