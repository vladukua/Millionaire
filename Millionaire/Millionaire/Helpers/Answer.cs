using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Millionaire.Helpers
{
    public class Answer
    {
        public string AnswerText { get; set; }
        public bool IsRight { get; set; }
    }

    public enum AnswerType
    {
        A,
        B,
        C,
        D
    }
}