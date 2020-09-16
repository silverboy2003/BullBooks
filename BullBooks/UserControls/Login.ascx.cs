using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BullBooks.UserControls
{
    public partial class Login : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendLogin(object sender, EventArgs e)
        {
            string username = TextIn.Text;
            string password = PasswordIn.Text;

        }
    }
}