using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Collections.Specialized;
using System.Security.Policy;
using System.Security.Principal;

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
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("userId", ((User)Session["User"]).Id.ToString());
                UserButton.PostBackUrl = "UserPage.aspx" + '?' + queryString.ToString();
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
        protected void RedirectSearch(object sender, EventArgs e)
        {
            Response.Redirect("SearchPage.aspx");
        }
    }
}