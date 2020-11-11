using System.ComponentModel.DataAnnotations;
using ReplyWorkflow.Outputs;

namespace ReplyWorkflow.Inputs
{
    public class SendAckToAuthorCmd
    {       
        [Required]
        public CheckLanguageResult.SafeText validAck;    
        [Required]
        public int AuthorId { get; }
        [Required]
        public int QuestionId { get; }

        public SendAckToAuthorCmd(CheckLanguageResult.SafeText ack, int questionid, int authorid)
        {
            validAck = ack;
            AuthorId = authorid;
            QuestionId = questionid;
        }
    }
}