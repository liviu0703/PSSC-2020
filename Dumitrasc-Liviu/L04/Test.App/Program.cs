using System;
using System.Collections.Generic;
using Question.Domain.AskQuestionWorkflow;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> taglist = new List<string>{ "C#", "WFA" };
            var cmd = new AskQuestionCmd("How to change button size dynamically", "Hi, how can i change a button's size programatically, while the app is running, when something is pressed for example", taglist);
            var result = AskQuestion(cmd);
            
            result.Match(
                ProcessQuestionAdded,
                ProcessQuestionNotAdded,
                ProcessQuestionValidationFailed
            );
        }

        private static string ProcessQuestionNotAdded(AskQuestionResult.QuestionNotAdded question)
        {
            Console.WriteLine("Question not added. Reason: " + question.ErrorMessage.ToString());
            
            return question.ErrorMessage.ToString();
        }

        private static string ProcessQuestionValidationFailed(AskQuestionResult.QuestionValidationFailed question)
        {
            Console.WriteLine("Question failed validation: ");
            foreach(var error in question.ValidationErrros)
            {
                Console.WriteLine(question);
            }

            Console.WriteLine("Feel free to contact administration for a manual question review!");
            return question.ToString();
        }

        private static string ProcessQuestionAdded(AskQuestionResult.QuestionAdded question)
        {
            Console.WriteLine("Question added with id:" + question.Id);
            Console.WriteLine("Title: " + question.Title);
            Console.WriteLine("Body text: " + question.Text);
            Console.WriteLine("Tags:");
            foreach(var item in question.Tags)
            {
                Console.WriteLine(item);
            }

            return question.ToString();
        }

        static AskQuestionResult.IAskQuestionResult AskQuestion(AskQuestionCmd cmd)
        {
            if(string.IsNullOrWhiteSpace(cmd.Title))
            {
                string error = new string ("Title must not be empty!");
                return new AskQuestionResult.QuestionNotAdded(error);
            }

            if(string.IsNullOrWhiteSpace(cmd.Text))
            {
                string error = new string ("Body must not be empty!");
                return new AskQuestionResult.QuestionNotAdded(error);
            }

            if(new Random().Next(10) > 7) //simulare analiza text
            {
                var error = new List<string> {"ML validation failed!"};
                return new AskQuestionResult.QuestionValidationFailed(error);
            }

            var Id = Guid.NewGuid();
            var result = new AskQuestionResult.QuestionAdded(Id, cmd.Title, cmd.Text, cmd.Tags);
            return result;
        }
    }
}