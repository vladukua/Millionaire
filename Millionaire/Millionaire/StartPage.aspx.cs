using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Millionaire.Code;

namespace Millionaire
{
    public partial class StartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAcceptUserName_OnClick(object sender, EventArgs e)
        {
            var xqr = new XmlQuestionRepository(Server.MapPath("App_Data/Questions.xml"));

            Session[Keys.UserKey] = txtUserName.Text;
            Session[Keys.IterationKey] = 0;
            Session[Keys.QuestionsKey] = xqr.GetQuestions();
            Response.Redirect("~/MainPage.aspx");
        }
    }
}