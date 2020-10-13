﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text.RegularExpressions;
namespace BullBooks.UserControls
{
    public partial class Register : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RegisterUser(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string email = this.EmailIn.Text;
                string username = this.UsernameIn.Text;
                string alias = this.AliasIn.Text;
                string password = this.PasswordIn.Text;
                DateTime birthDate = DateTime.Parse(this.CalendarIn.Value);
                int gender = int.Parse(this.GenderIn.SelectedValue);
                DateTime creationDate = DateTime.Now;

                User user = new User(email, username, gender, birthDate, password, creationDate, alias);
                int newID = user.Register();
                if (newID == -1)
                {
                    //register unsuccessful, do something
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
            else
            {
                //do something to say page is not valid
            }
        }
        protected void EmailVal()
        {
            string email = this.EmailIn.Text;
            Regex emailRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            bool isMatch = emailRegex.Match(email).Success;
            EmailValidator.IsValid = false;
        }
    }
}