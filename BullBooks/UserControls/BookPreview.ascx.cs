using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using System.IO;
using System.Net;

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
            //CoverImage.Click += Redirect;
        }
        protected void Redirect(object sender, System.EventArgs e)
        {
            var client = new WebClient();
            client.QueryString.Add("id", ID);
            Response.Redirect("BookPage.aspx");
        }
        public void LoadBook()
        {
            CoverImage.ImageUrl = Cover;
            BookName.Text = Name;
            BookAuthor.Text = Author;
        }
    }
}