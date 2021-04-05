using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class BookCreationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User currentUser = (User)Session["User"];
            if (currentUser == null || (!currentUser.IsAdmin && !currentUser.IsPublisher))
                Response.Redirect("SearchPage.aspx");
        }
    }
}