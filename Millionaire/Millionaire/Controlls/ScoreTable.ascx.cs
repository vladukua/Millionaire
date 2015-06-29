using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Millionaire.Controlls
{
    public partial class ScoreTable : System.Web.UI.UserControl
    {
        #region Properties

        public ImageButton BtnHelp1
        {
            get { return this.btnHint1; }
        }

        public ImageButton BtnHelp2
        {
            get { return this.btnHint2; }
        }

        public ImageButton BtnHelp3
        {
            get { return this.btnHint3; }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //scoretable.Rows[15].BgColor = "#D2691E";
        }

        #region Help Buttons Event

        protected void btnHelp1_Click(object sender, ImageClickEventArgs e)
        {
            btnHint1.Enabled = false;
            BtnHelp1.ImageUrl = @"~/Resources/50_50_hint_used.png";
            //btnHelp1.CssClass = "help1u";
        }

        protected void btnHelp2_Click(object sender, ImageClickEventArgs e)
        {
            btnHint2.Enabled = false;
            btnHint2.ImageUrl = @"~/Resources/hall_hint_used.png";
            //btnHelp2.CssClass = "help2u";
        }

        protected void btnHelp3_Click(object sender, ImageClickEventArgs e)
        {
            btnHint3.Enabled = false;
            BtnHelp1.ImageUrl = @"~/Resources/phone_hint_used.png";
            //btnHelp3.CssClass = "help3u";
        }

        public void ChangeScore(int iteration)
        {
            if (iteration != 0)
            {
                scoretable.Rows[15 - iteration + 1].Attributes.Clear();
                scoretable.Rows[15 - iteration + 1].Attributes.Add("class", "passedscore");
                scoretable.Rows[15 - iteration].Attributes.Add("class", "currentscore");
            }
            else
            {
                scoretable.Rows[15].Attributes.Add("class", "currentscore");
            }
        }

        public void ClearAll()
        {
            foreach (HtmlTableRow row in scoretable.Rows)
            {
                row.Attributes.Clear();
            }
            btnHint1.ImageUrl = "~/Resources/50_50_hint.png";
            btnHint1.Enabled = true;
            btnHint2.Enabled = true;
            btnHint2.ImageUrl = "~/Resources/hall_hint.png";
            btnHint3.Enabled = true;
            btnHint3.ImageUrl = "~/Resources/phone_hint.png";
        }

        #endregion

    }
}