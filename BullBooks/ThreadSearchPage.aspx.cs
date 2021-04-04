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

namespace BullBooks
{
    public partial class ThreadSearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Thread> allThreads = new List<Thread>(((Dictionary<int, Thread>)Application["Threads"]).Values);//encapsulation, creates a new list with all the values of the list saved on the application but using a different pointer
            string book = Request.QueryString["book"];
            string thread = Request.QueryString["thread"];
            Thread.Search(allThreads, thread, book);
            LoadPreviews(allThreads);
            if(Session["User"] != null)
            {
                CreateThread.Visible = true;
            }
        }
        private void LoadPreviews(List<Thread> results)
        {
            
            foreach(Thread current in results)
            {
                UserControls.ThreadPreview newPreview = (UserControls.ThreadPreview)Page.LoadControl("~/UserControls/ThreadPreview.ascx");
                newPreview.SetThread(current);
                PreviewsContainer.Controls.Add(newPreview);
                //Container.Controls.Add(newPreview);
            }

        }
        
       private string CreateQuery()
        {
            string thread = ThreadSearchBox.Text;
            string book = BookThreadSearch.Text;
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("thread", thread);
            queryString.Add("book", book);
            return queryString.ToString();

        }
        protected void RedirectSearch(object sender, EventArgs e)
        {
            string query = CreateQuery();
            string current = Request.Url.GetLeftPart(UriPartial.Path);
            string newString = current + '?' + query;
            Response.Redirect(newString);
        }

        protected void CreateThreadRedirect(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ThreadCreationPage.aspx");
        }
    }
}