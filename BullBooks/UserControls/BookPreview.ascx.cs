using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Security.Policy;
using System.Security.Principal;

namespace BullBooks.Controllers
{
    public partial class BookPreview : System.Web.UI.UserControl
    {

        public int BookID
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Author
        {
            get; set;
        }
        public string Cover
        {
            get; set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadBook();
            CoverImage.Click += Redirect;
        }
        protected void Redirect(object sender, System.EventArgs e)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("id", BookID.ToString());
            string query = queryString.ToString();
            string newString = "BookPage.aspx" + '?' + query;
            Response.Redirect(newString);
        }
        public void LoadBook()
        {
            Cover = "../" + Cover;
            CoverImage.Style.Add("Background-Image", Cover);
            BookName.Text = Name;
            BookAuthor.Text = Author;
        }
    }
}