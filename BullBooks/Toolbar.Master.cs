using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BullBooks
{
    public partial class Toolbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoadLogin(object sender, EventArgs e)
        {
            UserControls.Login lg = (UserControls.Login)Page.LoadControl("UserControls/Login.ascx");
            MainForm.Controls.Add(lg);
        }
    }
}