﻿namespace Millionaire.Code
{
    public class Question
    {
        public string Task { get; set; }

        public Answer[] Answers { get; set; }

        public Question()
        {
            this.Answers = new Answer[4];
            for (var i = 0; i < this.Answers.Length; ++i)
            {
                Answers[i] = new Answer();;
            }
        }
    }
}