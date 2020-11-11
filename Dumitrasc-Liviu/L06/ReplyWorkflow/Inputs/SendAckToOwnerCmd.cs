using System.ComponentModel.DataAnnotations;
using ReplyWorkflow.Outputs;

namespace ReplyWorkflow.Inputs
{
    public class SendAckToOwnerCmd
    {
        [Required]
        public CheckLanguageResult.SafeText validAck;
        [Required]
        public int QuestionId { get; }
        [Required]
        public int AutoherId { get; }

        public SendAckToOwnerCmd(CheckLanguageResult.SafeText ack, int questionid, int authorid)
        {
            validAck = ack;
            QuestionId = questionid;
            AutoherId = authorid;
        }
    }
}