using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Mail;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using Millionaire.Helpers;
using MailMessage = System.Net.Mail.MailMessage;
using MailPriority = System.Net.Mail.MailPriority;

namespace Millionaire
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly Question[] _questions;
        private static int _iteration;
        private bool _gameOver = false;
        const string CorrectAnswerScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                             @"audio.src = 'http://static.mezgrman.de/downloads/wwm/richtig_stufe_1.mp3'; // Указываем путь к звуку" +
                             "\n" +
                             @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                             "audio.play();\n";

        private Button[] _answerButtons;

        static WebForm1()
        {
            _iteration = 0;
        }
        public WebForm1()
        {
            _questions = new Question[15];
            ReadQuestions();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            _answerButtons = new Button[4];
            _answerButtons[0] = this.btnAAnswer;
            _answerButtons[1] = this.btnBAnswer;
            _answerButtons[2] = this.btnCAnswer;
            _answerButtons[3] = this.btnDAnswer;
            FillFields();
        }

        private void ReadQuestions()
        {
            var i = 0;
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(Server.MapPath("/Resources/Questions.xml"));
            foreach (XmlNode task in xmlDoc.DocumentElement.ChildNodes)
            {
                if (task.Name == "Question")
                {
                    foreach (XmlNode param in task.ChildNodes)
                    {
                        if (param.Name == "Text")
                        {
                            _questions[i] = new Question();
                            _questions[i].Task = param.FirstChild.InnerText;
                        }
                        if (param.Name == "A")
                        {                          
                            _questions[i].Answers[0].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            _questions[i].Answers[0].AnswerText = param.InnerText;
                        }
                        else if (param.Name == "B")
                        {
                            _questions[i].Answers[1].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            _questions[i].Answers[1].AnswerText = param.InnerText;
                        }
                        else if (param.Name == "C")
                        {
                            _questions[i].Answers[2].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            _questions[i].Answers[2].AnswerText = param.InnerText;
                        }
                        else if (param.Name == "D")
                        {
                            _questions[i].Answers[3].IsRight = bool.Parse(param.Attributes.GetNamedItem("isCorrect").Value);
                            _questions[i].Answers[3].AnswerText = param.InnerText;
                            i++;
                        }
                    }
                }
            }
        }

        private void FillFields()
        {
            this.lblQuestion.Text = _questions[_iteration].Task;
            this.btnAAnswer.Text = _questions[_iteration].Answers[0].AnswerText;
            this.btnBAnswer.Text = _questions[_iteration].Answers[1].AnswerText;
            this.btnCAnswer.Text = _questions[_iteration].Answers[2].AnswerText;
            this.btnDAnswer.Text = _questions[_iteration].Answers[3].AnswerText;
            MarkRating();
            EnableAll();
        }

        private void MarkRating()
        {
            if (_iteration != 0)
            {
                scoretable.Rows[15 - _iteration + 1].Attributes.Clear();
                scoretable.Rows[15 - _iteration + 1].Attributes.Add("class", "passedscore");
                scoretable.Rows[15 - _iteration].Attributes.Add("class", "currentscore");
            }
            else
            {
                scoretable.Rows[15].Attributes.Add("class", "currentscore");
            }
        }
        private void Restart(bool isWinner = false)
        {
            _iteration = 0;
            if (isWinner)
            {
                const string winGameScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                                                 @"audio.src = 'http://static.mezgrman.de/downloads/wwm/richtig_millionenfrage.mp3'; // Указываем путь к звуку" +
                                                 "\n" +
                                                 @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                                                 "audio.play();\n";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", winGameScript, true);
            }
            ClearAll(false);
            EnableAll();
        }

        protected void btnAAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.A))
            {
                _iteration++;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Restart(true);
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                ClearAll();
            }
        }

        protected void btnBAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.B))
            {
                _iteration++;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Restart(true);
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                ClearAll();
            }
        }

        protected void btnCAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.C))
            {
                _iteration++;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Restart(true);
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                ClearAll();
            }
        }

        protected void btnDAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.D))
            {
                _iteration++;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Restart(true);
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                ClearAll();
            }
        }

        private bool CheckAnswer(AnswerType answer)
        {
            var retFlag = false;
            switch (answer)
            {
                case AnswerType.A:
                    retFlag = _questions[_iteration].Answers[0].IsRight;
                    break;
                case AnswerType.B:
                    retFlag = _questions[_iteration].Answers[1].IsRight;
                    break;
                case AnswerType.C:
                    retFlag = _questions[_iteration].Answers[2].IsRight;
                    break;
                case AnswerType.D:
                    retFlag = _questions[_iteration].Answers[3].IsRight;
                    break;
            }

            return retFlag;
        }

        private void ClearAll(bool flag = true)
        {
            if (flag)
            {
                const string wrongAnswerScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                                                 @"audio.src = 'http://static.mezgrman.de/downloads/wwm/falsch.mp3'; // Указываем путь к звуку" +
                                                 "\n" +
                                                 @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                                                 "audio.play();\n";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", wrongAnswerScript, true);
            }
            foreach (HtmlTableRow row in scoretable.Rows)
            {
                _iteration = 0;
                row.Attributes.Clear();
            }
            btnHint1.ImageUrl = "~/Resources/50_50_hint.png";
            btnHint1.Enabled = true;
            btnHint2.Enabled = true;
            btnHint2.ImageUrl = "~/Resources/hall_hint.png";
            btnHint3.Enabled = true;
            btnHint3.ImageUrl = "~/Resources/phone_hint.png";
            FillFields();
        }

        private void EnableAll()
        {
            foreach (var btn in _answerButtons)
            {
                btn.Enabled = true;
            }
        }

        protected void btnHint1_Click(object sender, ImageClickEventArgs e)
        {
            const string hintScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                                 @"audio.src = 'http://static.mezgrman.de/downloads/wwm/50_50.mp3'; // Указываем путь к звуку" +
                                 "\n" +
                                 @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                                 "audio.play();\n";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", hintScript, true);

            this.btnHint1.ImageUrl = @"~/Resources/50_50_hint_used.png";
            this.btnHint1.Enabled = false;

            var rnd = new Random(DateTime.Now.Millisecond);
            var answer1 = 0;
            for (var i = 0; i < _questions[_iteration].Answers.Length; ++i)
            {
                if (!_questions[_iteration].Answers[i].IsRight) continue;
                answer1 = i;
                i = _questions[_iteration].Answers.Length;
            }

            var answer2 = 0;
            do
            {
                answer2 = rnd.Next(4);
            } while (answer2 == answer1);

            for (var i = 0; i < _answerButtons.Length; ++i)
            {
                if (i != answer1 && i != answer2)
                {
                    _answerButtons[i].Text = string.Empty;
                    _answerButtons[i].Enabled = false;
                }
            }
        }

        protected void btnHint2_Click(object sender, ImageClickEventArgs e)
        {
            const string hintScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                     @"audio.src = 'http://static.mezgrman.de/downloads/wwm/50_50.mp3'; // Указываем путь к звуку" +
                     "\n" +
                     @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                     "audio.play();\n";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", hintScript, true);

            ClientScript.RegisterStartupScript(this.GetType(), "window.open", "window.open('https://www.google.com.ua')", true);
            btnHint2.ImageUrl = @"~/Resources/hall_hint_used.png";
            btnHint2.Enabled = false;
        }

        protected void btnHint3_Click(object sender, ImageClickEventArgs e)
        {
            const string hintScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                     @"audio.src = 'http://static.mezgrman.de/downloads/wwm/50_50.mp3'; // Указываем путь к звуку" +
                     "\n" +
                     @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                     "audio.play();\n";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", hintScript, true);

            btnHint3.ImageUrl = @"~/Resources/phone_hint_used.png";
            btnHint3.Enabled = false;

            var fromAddress = new MailAddress("olegpavlukua@gmail.com", "Millionaire");
            var toAddress = new MailAddress("vladukteo@gmail.com", "Friend");

            const string fromPassword = "oleg2580";
            const string subject = "Friend's help";
            var body = string.Format("Question: {0}\nAnswers:\nA:  {1}\nB:  {2}\nC:  {3}\nD:  {4}",
                _questions[_iteration].Task,
                _questions[_iteration].Answers[0].AnswerText, _questions[_iteration].Answers[1].AnswerText,
                _questions[_iteration].Answers[2].AnswerText, _questions[_iteration].Answers[3].AnswerText);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }                  

        }
    }
}