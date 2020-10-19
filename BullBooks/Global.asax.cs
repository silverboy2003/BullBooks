using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Configuration;
using BL;

namespace BullBooks
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            System.IO.Directory.SetCurrentDirectory(Server.MapPath("~/"));

            string connString = WebConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            BL.Helper.SetDBConnString(connString);

            List<Book> books = Book.LoadBooks(); //Load all the books from Database and save them in Application
            Helper.SetAllReviews(books);
            Application["Books"] = books;
            Dictionary<int, string> genres = Genre.GetAllGenresDictionary();
            Application["Genres"] = genres;
            
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}