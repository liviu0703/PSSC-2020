using System.Collections.Generic;

namespace Question.Domain.AskQuestionWorkflow
{
    internal class InvalidQuestionDataException : System.Exception
    {
        public InvalidQuestionDataException()
        {

        }

        public InvalidQuestionDataException(string title, string text, List<string> tags) 
        : base("Invalid format:\n" +
                "Title: " + title + "\n" +
                "Text: " + text + " (must be < 1000)\n" +
                "Tags: " + tags + " (nr of tags > 1 and < 3)\n")
        {

        }
    }
}