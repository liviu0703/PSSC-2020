using LanguageExt.Common;

namespace Question.Domain.AskQuestionWorkflow
{
    public class VerifyQuestionService
    {
        public Result<VerifiedQuestion> VerifyQuestion(UnverifiedQuestion question)
        {
            return new VerifiedQuestion(question.Title, question.Text, question.Tags);
        }
    }
}