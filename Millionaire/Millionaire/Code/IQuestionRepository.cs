using System;
using System.Collections.Generic;

namespace Millionaire.Code
{
    public interface IQuestionRepository
    {
        IEnumerable<Question> GetQuestions();
    }
}
