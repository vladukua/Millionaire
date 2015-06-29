using System;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Code;
using MailMessage = System.Net.Mail.MailMessage;
using System.Collections.Generic;
using System.Linq;

namespace Millionaire
{
    public partial class MainPage : Page
    {
        #region Private Fields

        private readonly IEnumerable<Question> _questions;
        private int _iteration;
        private string _gameOverMsg;
        const string CorrectAnswerScript = "var audio = new Audio();\n" +
                             @"audio.src = 'http://static.mezgrman.de/downloads/wwm/richtig_stufe_1.mp3';" +
                             "\n" +
                             @"audio.autoplay = true;" + "\n" +
                             "audio.play();\n";
        private Button[] _answerButtons;
        private XmlQuestionRepository xqr;
        private const string UserKey = "User";
        private const string IterationKey = "Iteration";

        #endregion

        #region Constructors

        public MainPage()
        {
            xqr = new XmlQuestionRepository(Server.MapPath("App_Data/Questions.xml"));
            _questions = xqr.GetQuestions();
        }

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[IterationKey] == null)
            {
                Session[IterationKey] = 0;
            }
            _iteration = (int)Session[IterationKey];
            if (Session[UserKey] != null)
            {
                lblUserName.Text = "Гравець:  " + (string) Session[Keys.UserKey];
                _answerButtons = new Button[4];
                _answerButtons[0] = this.btnAAnswer;
                _answerButtons[1] = this.btnBAnswer;
                _answerButtons[2] = this.btnCAnswer;
                _answerButtons[3] = this.btnDAnswer;
                FillFields();
                InitHintButtons();
            }
        }

        protected void btnAAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.A))
            {
                _iteration++;
                Session[IterationKey] = _iteration;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Response.Redirect("~/GameOverPage.aspx?state=win&money=" + GetMoney());
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                GameOver();
            }
        }

        protected void btnBAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.B))
            {
                _iteration++;
                Session[IterationKey] = _iteration;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Response.Redirect("~/GameOverPage.aspx?state=win&money=1000000");
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                GameOver();
            }
        }

        protected void btnCAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.C))
            {
                _iteration++;
                Session[IterationKey] = _iteration;
                if (_iteration >= 15)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Ви перемогли. Гру буде перезапущено.');", true);
                    Response.Redirect("~/GameOverPage.aspx?state=win&money=1000000");
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                GameOver();
            }
        }

        protected void btnDAnswer_Click(object sender, EventArgs e)
        {
            if (CheckAnswer(AnswerType.D))
            {
                _iteration++;
                Session[IterationKey] = _iteration;
                if (_iteration >= 15)
                {
                    Response.Redirect("~/GameOverPage.aspx?state=win&money=1000000");
                    return;
                }
                FillFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling3", CorrectAnswerScript, true);
            }
            else
            {
                GameOver();
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

            /*
            this.btnHint1.ImageUrl = @"~/Resources/50_50_hint_used.png";
            this.btnHint1.Enabled = false;
            */
            
            var rnd = new Random(DateTime.Now.Millisecond);
            var answer1 = 0;
            for (var i = 0; i < _questions.ElementAt(_iteration).Answers.Length; ++i)
            {
                if (!_questions.ElementAt(_iteration).Answers[i].IsRight) continue;
                answer1 = i;
                i = _questions.ElementAt(_iteration).Answers.Length;
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

            var query = "window.open('https://www.google.com.ua/search?q=" + _questions.ElementAt(_iteration).Task + "');";
            ClientScript.RegisterStartupScript(this.GetType(), "window.open", query, true);
            /*
            btnHint2.ImageUrl = @"~/Resources/hall_hint_used.png";
            btnHint2.Enabled = false;
            */
        }

        protected void btnHint3_Click(object sender, ImageClickEventArgs e)
        {
            const string hintScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                     @"audio.src = 'http://static.mezgrman.de/downloads/wwm/50_50.mp3'; // Указываем путь к звуку" +
                     "\n" +
                     @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                     "audio.play();\n";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", hintScript, true);

            /*
            btnHint3.ImageUrl = @"~/Resources/phone_hint_used.png";
            btnHint3.Enabled = false;
            */

            var fromAddress = new MailAddress("olegpavlukua@gmail.com", "Millionaire");
            var toAddress = new MailAddress("vladukteo@gmail.com", "Friend");

            const string fromPassword = "oleg2580";
            const string subject = "Friend's help";
            var body = string.Format("Question: {0}\nAnswers:\nA:  {1}\nB:  {2}\nC:  {3}\nD:  {4}",
                _questions.ElementAt(_iteration).Task,
                _questions.ElementAt(_iteration).Answers[0].AnswerText, _questions.ElementAt(_iteration).Answers[1].AnswerText,
                _questions.ElementAt(_iteration).Answers[2].AnswerText, _questions.ElementAt(_iteration).Answers[3].AnswerText);

            var sc = new SmtpClient();
            sc.Host = @"smtp.gmail.com";
            sc.Port = 587;
            sc.EnableSsl = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
            sc.Timeout = 20000;

            var msg = new MailMessage();//fromAddress, toAddress
            msg.From = fromAddress;
            msg.To.Add(toAddress);
            msg.Subject = subject;
            msg.Body = body;
            sc.Send(msg);
        }

        #endregion

        #region Helpers

        private void InitHintButtons()
        {
            ScoreTableControl.BtnHelp1.Click += btnHint1_Click;
            ScoreTableControl.BtnHelp2.Click += btnHint2_Click;
            ScoreTableControl.BtnHelp3.Click += btnHint3_Click;
        }

        private void FillFields()
        {
            this.lblQuestion.Text = _questions.ElementAt(_iteration).Task;
            this.btnAAnswer.Text = _questions.ElementAt(_iteration).Answers[0].AnswerText;
            this.btnBAnswer.Text = _questions.ElementAt(_iteration).Answers[1].AnswerText;
            this.btnCAnswer.Text = _questions.ElementAt(_iteration).Answers[2].AnswerText;
            this.btnDAnswer.Text = _questions.ElementAt(_iteration).Answers[3].AnswerText;
            MarkRating();
            EnableAll();
        }

        private void MarkRating()
        {
            ScoreTableControl.ChangeScore(_iteration);
        }

        private int GetMoney()
        {
            if (_iteration < 4)
            {
                return 0;
            }
            else if (_iteration < 9)
            {
                return 1000;
            }
            else if (_iteration < 14)
            {
                return 32000;
            }
            else
            {
                return 1000000;
            }
        }

        private void GameOver()
        {
            Response.Redirect("~/GameOverPage.aspx?state=lose&money=" + GetMoney());
        }

        private bool CheckAnswer(AnswerType answer)
        {
            var retFlag = false;
            switch (answer)
            {
                case AnswerType.A:
                    retFlag = _questions.ElementAt(_iteration).Answers[0].IsRight;
                    break;
                case AnswerType.B:
                    retFlag = _questions.ElementAt(_iteration).Answers[1].IsRight;
                    break;
                case AnswerType.C:
                    retFlag = _questions.ElementAt(_iteration).Answers[2].IsRight;
                    break;
                case AnswerType.D:
                    retFlag = _questions.ElementAt(_iteration).Answers[3].IsRight;
                    break;
            }

            return retFlag;
        }

        private void EnableAll()
        {
            foreach (var btn in _answerButtons)
            {
                btn.Enabled = true;
            }
        }

        #endregion
    }
}