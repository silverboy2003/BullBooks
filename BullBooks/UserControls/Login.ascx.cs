﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks.UserControls
{
    public partial class Login : System.Web.UI.UserControl
    {
        private string referrer;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LoginUser(object sender, EventArgs e)
        {
            string username = TextIn.Text;
            string password = PasswordIn.Text;
            User user = User.Login(username, password);
            if(user == null)
            {
                //do something to alert wrong username or password
            }
            else
            {
                try
                {
                    Session["User"] = user;
                    HttpCookie hc = new HttpCookie("nigga");
                    hc["name"] = user.GetUsername();
                    hc.Expires.Add(new TimeSpan(0, 1, 0));
                    Response.Cookies.Add(hc);

                    Response.Redirect("MainPage.aspx");
                }
                catch
                {
                    //do something...
                }
            }

        }

        protected void LoadRegister(object sender, EventArgs e)
        {

        }
    }
}