using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class BookPage : System.Web.UI.Page
    {
        private Book thisBook;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBook();
                CreateBookPage();
                GenerateStars();
            }
        }
        protected void CreateBookPage()
        {

        }
        protected void GenerateStars()//★
        {
            double score = 4.75;
            int starsCreated = 0; //counts how many stars were created using the score, in order to generate the remaining stars gray
            while (score >= 1)
            {
                Label star = new Label();
                star.Text = "★";
                star.Style.Add("color", "yellow");
                StarPanel.Controls.Add(star);
                score--;
                starsCreated++;
            }
            if (score != 0)
            {
                int percent = (int)Math.Floor(score * 100);
                Label star = new Label();
                star.Text = "★";
                star.CssClass = "Star";
                star.Style.Add("background", $"linear-gradient(to right, yellow {percent}%, gray {percent}%, gray {100 - percent}%);");
                //need to create star with gradient using the percentage
                StarPanel.Controls.Add(star);
                starsCreated++;
                score = 0;
            }
            for (int i = 5; i > starsCreated; i++)
            {
                //create gray star
            }
        }
        protected void LoadBook()//gets and sets the current page's object from application 
        {
            string idQuery = Request.QueryString["id"];
            if (idQuery != null)
            {
                int id = int.Parse(idQuery);
                Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
                if (allBooks.ContainsKey(id))
                    thisBook = allBooks[id];
                else
                    thisBook = null;
            }
        }
    }
}