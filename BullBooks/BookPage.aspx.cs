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
                StarsRating.GenerateStars(thisBook.BookRating);
                Load_Reviews(thisBook.Reviews);
                if ((User)Session["User"] != null && !thisBook.Reviews.Any(review => review.ReviewerID == ((User)Session["User"]).Id))
                {
                    Editor.Visible = true;
                    RatingSelect.GenerateStarsSelect();
                }
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
            string bookGenres = "";
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

        public void Load_Reviews(List<Review> reviews)
        {
            foreach (Review item in reviews)
            {
                Review review = item;
                BookReview currentReview = (BookReview)Page.LoadControl("~/UserControls/BookReview.ascx");
                Reviews_Container.Controls.Add(currentReview);
                currentReview.Load_Review(review);
            }
        }
    }
}