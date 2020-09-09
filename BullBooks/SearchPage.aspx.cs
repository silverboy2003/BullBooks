using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected string name;
        protected List<int> genreIDs;
        protected void Page_Load(object sender, EventArgs e)
        {
            Load_Radio();
            genreIDs = new List<int>();
            genreIDs.Add(1);
            genreIDs.Add(2);
            Blist.LoadBooks(name, genreIDs);
        }
        protected void Load_Radio()
        {
            List<Genre> gList = Genre.GetAllGenres();
            foreach(Genre g in gList)
            {
                ListItem genre = new ListItem();
                genre.Text = g.GenreName;
                genre.Value = (g.GenreID).ToString();
                ((CheckBoxList)Genres).Items.Add(genre);
            }
        }
    }
}