
using System;
using System.Linq;

namespace Question.Domain.AskQuestionWorkflow
{
    public class VoteManager
    {
        public AskQuestionResult.QuestionAdded Update(AskQuestionResult.QuestionAdded question, VoteEnum vote)
        {
            var votes = question.Votes.ToList();
            votes.Add(vote);
            
            return new AskQuestionResult.QuestionAdded(question.Id, question.Title, question.Text, question.Tags, votes.Sum(score => Convert.ToInt32(score)), votes);
        }
    }
}