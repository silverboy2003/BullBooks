﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text.RegularExpressions;
using System.Collections.Specialized;

namespace BullBooks
{
    public partial class BookPage : System.Web.UI.Page      
    {

        private Book thisBook;
    
    protected void Page_Load(object sender, EventArgs e)
        {
                LoadBook();
                CreateBookPage();
                StarsRating.GenerateStars(thisBook.BookRating);
                Load_Reviews(thisBook.Reviews);
                if ((User)Session["User"] != null && (thisBook.Reviews == null || !thisBook.Reviews.Any(review => review.ReviewerID == ((User)Session["User"]).Id)))
                {
                    Editor.Visible = true;
                    RatingSelect.Visible = true;
                    ReviewSubmit.Visible = true;
                }
            User currentUser = (User)Session["User"];
            if (currentUser != null && (currentUser.IsAdmin || (currentUser.Id == thisBook.AuthorID || currentUser.Id == thisBook.PublisherID)))
            {
                RedirectEdit.Visible = true;
                DeleteBook.Visible = true;
            }
            //RatingSelect.SendReview += new RatingSelector.SendReviewDelegate(CommitReview);
        }
        //private void CommitReview(int rating)
        //{
        //    int Rating = rating;
        //}
        protected void CreateBookPage()
        {
            BookName.Text = thisBook.BookName;
            AuthorName.Text = thisBook.AuthorName;
            PublisherName.Text = thisBook.PublisherName;
            NumPages.Text = thisBook.NumPages.ToString();
            NumChapters.Text = thisBook.NumChapters.ToString();
            ReleaseDate.Text = thisBook.BookRelease.ToString("dd/MM/yyyy");
            ISBN.Text = thisBook.ISBN.ToString();
            Synopsis.InnerHtml = thisBook.BookSynopsis;

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
            if(reviews != null)
            foreach (Review item in reviews)
            {
                Review review = item;
                BookReview currentReview = (BookReview)Page.LoadControl("~/UserControls/BookReview.ascx");
                Reviews_Container.Controls.Add(currentReview);
                currentReview.Load_Review(review);
            }
        }

        protected void SendReview(object sender, ImageClickEventArgs e)
        {
            int rating = RatingSelect.GetRating();
            string review = HiddenEditor.Value;
            review = review.Replace("\r\n", string.Empty);
            BL.Review newReview = new Review(review, thisBook.Id, rating, ((User)Session["User"]).Id, DateTime.Now);
            int newID = newReview.CommitReview();
            if (newID != -1)
            {
                thisBook.Reviews.Add(newReview);
                BookReview currentReview = (BookReview)Page.LoadControl("~/UserControls/BookReview.ascx");
                Reviews_Container.Controls.Add(currentReview);
                currentReview.Load_Review(newReview);
                thisBook.CalculateReviews();
                ISBNWS.ISBN ws = new ISBNWS.ISBN();
                ws.UpdateRating(thisBook.ISBN, thisBook.BookRating);
                StarsRating.ResetStars();
                StarsRating.GenerateStars(thisBook.BookRating);
            }
            Editor.Visible = false;
            RatingSelect.Visible = false;
            ReviewSubmit.Visible = false;
        }

        protected void RedirectEdit_Click(object sender, ImageClickEventArgs e)
        {
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("id", thisBook.Id.ToString());
            string query = queryString.ToString();
            string newString = "BookCreationPage.aspx" + '?' + query;
            Response.Redirect(newString);
        }
        protected void DeleteBook_Click(object sender, ImageClickEventArgs e)
        {
            Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
            allBooks.Remove(thisBook.Id);
            thisBook.DeleteSelf();
            Response.Redirect("SearchPage.aspx");
        }
    }
}