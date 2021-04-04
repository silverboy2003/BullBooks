using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BullBooks
{
    public partial class ThreadCreationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("ThreadSearchPage.aspx");
        }

        protected void ThreadSubmitButton_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}