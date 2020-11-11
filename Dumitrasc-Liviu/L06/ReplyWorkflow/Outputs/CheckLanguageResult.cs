using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;

namespace ReplyWorkflow.Outputs
{
    [AsChoice]
    public static partial class CheckLanguageResult 
    {
        public interface ICheckLanguageResult 
        {

        }

        public class SafeText : ICheckLanguageResult
        {
            public string Message { get; }
            public SafeText(string msg)
            {
                Message = msg;
            }
            
        }

        public class ErrorText : ICheckLanguageResult
        {
           public string ErrorMessge { get; }
           public ErrorText (string err)
           {
               ErrorMessge = err;
           }
        }
    }
}
