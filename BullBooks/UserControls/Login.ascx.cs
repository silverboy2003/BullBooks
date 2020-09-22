using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void LoginUser()
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
                Session["User"] = user;
            }
        }
    }
}