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
            BookName.Text = thisBook.BookName;
            AuthorName.Text = thisBook.AuthorName;
            PublisherName.Text = thisBook.PublisherName;
            NumPages.Text = thisBook.NumPages.ToString();
            NumChapters.Text = thisBook.NumChapters.ToString();
            ReleaseDate.Text = thisBook.BookRelease.ToString("dd/MM/yyyy");
            ISBN.Text = thisBook.ISBN.ToString();
            Synopsis.Text = thisBook.BookSynopsis;

            //now to load genres
            List<int> genres = thisBook.Genres;
            string bookGenres = "genres:";
            if (genres.Count != 0)
            {
                Dictionary<int, string> genresDictionary = (Dictionary<int, string>)Application["Genres"];
                for (int i = 0; i<genres.Count; i++)
                {
                    string genreName = ' ' + genresDictionary[genres[i]] + (i == genres.Count-1 ? '.' : ',');
                    bookGenres += genreName;
                }
            }
            Genres.Text = bookGenres;

            BookImage.ImageUrl = thisBook.BookCover;
        }
        protected void GenerateStars()//★
        {
            double score = thisBook.BookRating; // change this back later
            if (double.IsNaN(score))
                score = 0;
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
                star.CssClass = "Star";
                star.Text = "★";
                star.Style.Add("background", $"linear-gradient(to right, yellow {percent}%, gray {percent}%, gray {100 - percent}%)");
                star.Style.Add("-webkit-text-fill-color", "transparent");
                star.Style.Add("background-clip", "text");
                star.Style.Add("-webkit-background-clip", "text");
                //need to create star with gradient using the percentage
                StarPanel.Controls.Add(star);
                starsCreated++;
                score = 0;
            }
            while(starsCreated != 5)
            {
                Label star = new Label();
                star.Text = "★";
                star.Style.Add("color", "gray");
                StarPanel.Controls.Add(star);
                starsCreated++;
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
                    Response.Redirect("MainPage.aspx");
            }
            else
                Response.Redirect("MainPage.aspx");
        }
    }
}