using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Collections.Specialized;

namespace BullBooks.UserControls
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("userId", ((User)Session["User"]).Id.ToString());
                string query = queryString.ToString();
                string newString = "UserPage.aspx" + '?' + query;
                Response.Redirect(newString);
            }
        }
        protected void LoginUser(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string username = UsernameIn.Text;
                string password = PasswordIn.Text;
                User user = User.Login(username, password);
                if (user == null)
                {
                    //do something to alert wrong username or password
                }
                else
                {
                    try
                    {
                        Session["User"] = user;
                        Response.Redirect("MainPage.aspx");
                    }
                    catch
                    {
                        //do something...
                    }
                }
            }

        }

    }
}