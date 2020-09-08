using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BullBooks
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected string name;
        protected List<int> genres;
        protected void Page_Load(object sender, EventArgs e)
        {
            genres = new List<int>();
            genres.Add(1);
            genres.Add(2);
            Blist.LoadBooks(name, genres);
        }
    }
}