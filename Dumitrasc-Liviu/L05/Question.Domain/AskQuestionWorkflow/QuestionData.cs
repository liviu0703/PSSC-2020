using System.Collections.Generic;
using LanguageExt.Common;

namespace Question.Domain.AskQuestionWorkflow
{
    public interface IQuestionData { }

    public class UnverifiedQuestion : IQuestionData
    {
        public string Title { get; private set; }
        public string Text { get; private set; }
        public List<string> Tags { get; private set; }
        public UnverifiedQuestion(string title, string text, List<string> tags)
        {
            Title = title;
            Text = text;
            Tags = tags;
        }

        public static Result<UnverifiedQuestion> Create(string title, string text, List<string> tags)
        {
            if (IsQuestionDataValid(title, text, tags))
            {
                return new UnverifiedQuestion(title, text, tags);
            }
            else
            {
                return new Result<UnverifiedQuestion>(new InvalidQuestionDataException(title, text, tags));
            }
        }

        private static bool IsQuestionDataValid(string title, string text, List<string> tags)
        {
            if(text.Length > 1000)
            {
                return false;
            }

            if(tags.Count < 1 || tags.Count > 3)
            {
                return false;
            }

            return true;
        }
    }

    public class VerifiedQuestion : IQuestionData
    {
        public string Title { get; private set; }
        public string Text { get; private set; }
        public List<string> Tags { get; private set; }

        internal VerifiedQuestion(string title, string text, List<string> tags)
        {
            Title = title;
            Text = text;
            Tags = tags;
        }
    }

}