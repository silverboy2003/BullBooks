using System;
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
<<<<<<< HEAD
            Page.Validate("Register");
            if(Page.IsValid)
            {
                string email = this.EmailIn.Text;
                string username = this.UsernameIn.Text;
                string alias = this.AliasIn.Text;
                string password = this.PasswordIn.Text;
                DateTime birthDate = DateTime.Parse(this.CalendarIn.Value);
                int gender = int.Parse(this.GenderIn.SelectedValue);
                DateTime creationDate = DateTime.Now;
                if (string.IsNullOrEmpty(alias))
                    alias = username;
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

            }
        }

        protected void EmailCheck(object source, ServerValidateEventArgs args)
        {
            string email = EmailIn.Text;
            bool isAvailable = User.IsAvailable(email, "email");
            if (!isAvailable)
                args.IsValid = false;
        }
        protected void UsernameCheck(object source, ServerValidateEventArgs args)
        {
            string username = UsernameIn.Text;
            bool isAvailable = User.IsAvailable(username, "username");
            if (!isAvailable)
                args.IsValid = false;
=======

>>>>>>> parent of 2b9368b... Designed Register
        }
    }
}