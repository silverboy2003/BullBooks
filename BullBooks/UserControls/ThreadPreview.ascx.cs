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

namespace BullBooks.UserControls
{
    public partial class ThreadPreview : System.Web.UI.UserControl
    {
        int ThreadID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetThread(Thread currentThread)
        {
            ThreadTitle.Text = currentThread.ThreadTitle;
            BookName.Text = currentThread.ThreadBook;
            PostingDate.Text = String.Format("{0:g}", currentThread.CreationDate);
            ThreadID = currentThread.ThreadID;
        }
        protected string CreateQuery()//generates query string
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("ThreadID", ThreadID.ToString());
            return queryString.ToString();
        }
        protected void RedirectSearch(object sender, EventArgs e)
        {
            string query = CreateQuery();
            string current = "ThreadPage.aspx";     
            string newString = current + '?' + query;
            Response.Redirect(newString);
        }
    }
}