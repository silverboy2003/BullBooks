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
            if (!IsPostBack)
                LoadGenres();
        }
        protected void LoadGenres()
        {
            Dictionary<int, string> allGenres = (Dictionary<int, string>)Application["Genres"];
            foreach(KeyValuePair<int, string> genre in allGenres)
            {
                ListItem genreItem = new ListItem();
                genreItem.Value = genre.Key.ToString();
                genreItem.Text = genre.Value;
                Genres.Items.Add(genreItem);
            }
        }
    }
}