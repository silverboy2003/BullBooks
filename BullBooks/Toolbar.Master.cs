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
            if (Session["User"] != null)
            {
                UserButton.ImageUrl = "../ControlImages/Userpage.png";
                LogoutButton.Visible = true;
            }
            else
            {
                UserButton.ImageUrl = "../ControlImages/Login.png";
                LogoutButton.Visible = false;
            }
        }
        protected void LoadLogin(object sender, EventArgs e)
        {
            UserControls.Login lg = (UserControls.Login)Page.LoadControl("UserControls/Login.ascx");
            lg.ID = "loginID";
            lg.EnableViewState = true;
            MainForm.Controls.Add(lg);
        }

        protected void RedirectLogin(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            { }
            Response.Redirect("LoginPage.aspx");
        }
        protected void Logout(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect(Request.RawUrl);
        }
    }
}