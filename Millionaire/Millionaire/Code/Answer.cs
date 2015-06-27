namespace Millionaire.Code
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