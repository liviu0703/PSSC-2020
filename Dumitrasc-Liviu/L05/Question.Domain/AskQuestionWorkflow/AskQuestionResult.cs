using System;
using System.Collections.Generic;
using CSharp.Choices;

namespace Question.Domain.AskQuestionWorkflow
{
    [AsChoice]
    public static partial class AskQuestionResult
    {
        public interface IAskQuestionResult
        {

        }

        public class QuestionAdded : IAskQuestionResult
        {
            public Guid Id { get; private set; }
            public string Title { get; private set; }
            public string Text { get; private set; }
            public List<string> Tags { get; private set; }
            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> Votes { get; private set; }

            public QuestionAdded(Guid id, string title, string text, List<string> tags, int voteCount, IReadOnlyCollection<VoteEnum> votes)
            {
                Id = id;
                Title = title;
                Text = text;
                Tags = tags;
                VoteCount = voteCount;
                Votes = votes;
            }
        }

        public class QuestionNotAdded : IAskQuestionResult
        {
            public string ErrorMessage { get; set; }

            public QuestionNotAdded(string errorMessage)
            {
                ErrorMessage = errorMessage;
            }
        }

        public class QuestionValidationFailed : IAskQuestionResult
        {
            public List<string> ValidationErrros { get; set; }

            public QuestionValidationFailed(List<string> errors)
            {
                ValidationErrros = errors;
            }
        }
    }
}