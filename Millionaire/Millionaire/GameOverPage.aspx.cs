using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Code;

namespace Millionaire
{
    public partial class GameOverPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var state = Request.QueryString["state"];
            var money = Request.QueryString["money"];
            var userName = (string) Session[Keys.UserKey];
            if (state == "win")
            {
                const string winScript = "var audio = new Audio();\n" +
                    @"audio.src = '            http://static.mezgrman.de/downloads/wwm/richtig_millionenfrage.mp3';" +
                    "\n" +
                    @"audio.autoplay = true;" + "\n" +
                    "audio.play();\n";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "winSounds", winScript, true);

                lblCaption.Text = userName + ". Ви виграли + " + money + " грн.";
            }
            else if (state == "lose")
            {
                const string wrongAnswerScript = "var audio = new Audio(); // Создаём новый элемент Audio\n" +
                     @"audio.src = 'http://static.mezgrman.de/downloads/wwm/falsch.mp3'; // Указываем путь к звуку" +
                     "\n" +
                     @"audio.autoplay = true; // Автоматически запускаем" + "\n" +
                     "audio.play();\n";
                Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", wrongAnswerScript, true);

                lblCaption.Text = userName + ". Ви програли. Ваш виграш становить " + money + " грн.";
            }
        }

        protected void btnRestart_OnClick(object sender, ImageClickEventArgs e)
        {
            Session[Keys.IterationKey] = 0;
            Response.Redirect("~/MainPage.aspx");
        }
    }
}