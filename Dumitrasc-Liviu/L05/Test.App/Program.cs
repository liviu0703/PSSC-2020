using System;
using System.Collections.Generic;
using Question.Domain.AskQuestionWorkflow;
using LanguageExt;

namespace Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> taglist = new List<string> { "C#", "WFA" };
            var questionResult = UnverifiedQuestion.Create("How to change button size dynamically", "Hi, how can i change a button's size programatically, while the app is running, when something is pressed for example", taglist);

            questionResult.Match(
                Succ: question =>
                {
                    VoteAddManager(question);

                    Console.WriteLine("Question data is valid");

                    return Unit.Default;
                },
                Fail: ex =>
                {
                    Console.WriteLine(ex.Message);

                    return Unit.Default;
                }
            );


        }

        private static void VoteAddManager(UnverifiedQuestion questionData)
        {
            var verifiedQuestionResult = new VerifyQuestionService().VerifyQuestion(questionData);
            verifiedQuestionResult.Match(
                    verifiedQuestion =>
                    {
                        var id = Guid.NewGuid();
                        IReadOnlyCollection<VoteEnum> votes = Array.Empty<VoteEnum>();
                        var question = new AskQuestionResult.QuestionAdded(id, questionData.Title, questionData.Text, questionData.Tags, 0, votes);
                        question = new VoteManager().Update(question, VoteEnum.Up);
                        question = new VoteManager().Update(question, VoteEnum.Up);
                        question = new VoteManager().Update(question, VoteEnum.Down);

                        Console.WriteLine(question.Votes.Count);

                        return Unit.Default;
                    },
                    ex =>
                    {
                        Console.WriteLine("Question data could not be verified");
                        return Unit.Default;
                    }
                );
        }


    }
}