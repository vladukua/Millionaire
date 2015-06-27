using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Millionaire.Code
{
    public class XmlQuestionRepository : IQuestionRepository
    {
        #region Fields

        private readonly string _fileName;

        #endregion

        #region Constructors

        public XmlQuestionRepository(string fileName)
        {
            this._fileName = fileName;
        }

        #endregion

        #region IQuestionRepository

        public IEnumerable<Question> GetQuestions()
        {
            var questions = new Question[15];
            var i = 0;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(_fileName);
            foreach (XmlNode task in xmlDoc.DocumentElement.ChildNodes)
            {
                if (task.Name == "Question")
                {
                    foreach (XmlNode param in task.ChildNodes)
                    {
                        if (param.Name == "Text")
                        {
                            questions[i] = new Question();
                            questions[i].Task = param.FirstChild.InnerText;
                        }
                        if (param.Name == "A")
                        {
                            questions[i].Answers[0].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            questions[i].Answers[0].AnswerText = param.InnerText;
                        }
                        else if (param.Name == "B")
                        {
                            questions[i].Answers[1].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            questions[i].Answers[1].AnswerText = param.InnerText;
                        }
                        else if (param.Name == "C")
                        {
                            questions[i].Answers[2].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            questions[i].Answers[2].AnswerText = param.InnerText;
                        }
                        else if (param.Name == "D")
                        {
                            questions[i].Answers[3].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            questions[i].Answers[3].AnswerText = param.InnerText;
                            i++;
                        }
                    }
                }
            }
            return questions;
        }

        #endregion
    }
}