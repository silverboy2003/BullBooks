using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
namespace BullBooks
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["User"] == null || !((User)Session["User"]).IsAdmin)
            //    Response.Redirect("mainpage.aspx");
            if (!Page.IsPostBack)
            {
                Dictionary<int, User> allUsers = (Dictionary<int, User>)(Application["Users"]);
                CreateUserTable(allUsers);
            }  
        }
        private void CreateUserTable(Dictionary<int, User> users)
        {
            UserTable.DataSource = users.Values;
            UserTable.DataBind();
        }

        protected void RemoveColumns(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }
    }
}