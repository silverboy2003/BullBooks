﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.IO;
using System.Text.RegularExpressions;
using BullBooks.ISBNWS;

namespace BullBooks
{
    public partial class BookCreationPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<int, User> allUsers = (Dictionary<int, User>)Application["Users"];   
            User currentUser = (User)Session["User"];
            if (currentUser == null || (!currentUser.IsAdmin && !currentUser.IsPublisher && !currentUser.IsAuthor))
                Response.Redirect("SearchPage.aspx");
            if (!IsPostBack)
            {
                LoadGenres();
                if (currentUser.IsAdmin || (currentUser.IsAuthor && currentUser.IsPublisher))
                {
                    LoadAuthors(allUsers.Values.ToList()) ;
                    LoadPublishers(allUsers.Values.ToList());
                }
                else if (currentUser.IsAuthor)
                {
                    AuthorName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                    LoadPublishers(allUsers.Values.ToList());
                }
                else if(currentUser.IsPublisher)
                {
                    PublisherName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                    LoadAuthors(allUsers.Values.ToList());
                }
            }
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
        protected void LoadPublishers(List<User> publishers)
        {
            PublisherName.Items.Clear();
            foreach(User publisher in publishers)
            {
                PublisherName.Items.Add(new ListItem(publisher.Alias + '-' + publisher.Username, publisher.Id.ToString()));
            }
            
        }
        protected void LoadAuthors(List<User> authors)
        {
            AuthorName.Items.Clear();
            foreach (User author in authors)
            {
                AuthorName.Items.Add(new ListItem(author.Alias + '-' + author.Username, author.Id.ToString()));
            }
        }

        protected void SendBook_Click(object sender, ImageClickEventArgs e)
        {
            Page.Validate("CreateBook");
            if (Page.IsValid)
            {
                Dictionary<int, User> allUsers = (Dictionary<int, User>)Application["Users"];
                string bookName = BookName.Text;
                int publisherID = int.Parse(PublisherName.Value);
                int authorID = int.Parse(AuthorName.Value);
                string publisherName = allUsers[publisherID].Alias;
                string authorName = allUsers[authorID].Alias;
                string synopsis = Synopsis.Text;
                synopsis = synopsis.Replace("\r\n", "<br>");
                string bookCover = string.Empty;
                if (ViewState["CoverPath"] != null)
                    bookCover = ViewState["CoverPath"].ToString(); 
                int numPages = int.Parse(NumPages.Text);
                int numChapters = int.Parse(NumChapters.Text);
                DateTime releaseDate = DateTime.Parse(ReleaseDate.Value);
                string isbn = ISBN.Text;

                List<int> genres = new List<int>();
                foreach (ListItem genre in Genres.Items)
                {
                    if (genre.Selected)
                        genres.Add(int.Parse(genre.Value));
                }
                Book newBook = new Book(-1, bookName, authorName, publisherName, publisherID, authorID, synopsis, bookCover, 0, 0, numPages, numChapters, releaseDate, isbn, genres, new List<Review>());
                
                int newID = newBook.CommitBook();
                if (newID != -1)
                {
                    newBook.CommitGenres();
                    Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
                    allBooks.Add(newID, newBook);
                    Response.Redirect($"BookPage.aspx?id={newID}");
                }


            }
            else
            {
                
            }
        }

        protected void UploadFile_Click(object sender, EventArgs e)
        {
            if(BookCoverUpload.HasFile)
            {
                string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length-1]);
                string newName = names.Length + ".png";
                string newPath = @"CoverPics/" + newName;
                BookCoverUpload.SaveAs(Server.MapPath("~/" + newPath));
                BookUploadContainer.Style.Add("background-image", "../" + newPath);
                ViewState["CoverPath"] = newPath;
                //string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                //int newName = int.Parse(fileName) + 1;
                //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
            }
        }

        protected void ISBNService_Click(object sender, EventArgs e)
        {
            ISBNWS.ISBN ws = new ISBN();
            ISBNWS.WSBook wSBook = ws.GetBookByISBN(ISBN.Text);
            BookName.Text = wSBook.BookName;
            Synopsis.Text = wSBook.Synopsis;
            NumPages.Text = wSBook.NumPages.ToString();
            NumChapters.Text = wSBook.NumChapters.ToString();
            ReleaseDate.Value = wSBook.BookRelease.ToString("yyyy-MM-dd");

            string authorAlias = wSBook.Author.ToLower();
            string publisherAlias = wSBook.Author.ToLower();

            Dictionary<int, User> allUsers = (Dictionary<int, User>)Application["Users"];
            List<User> authors = allUsers.Values.Where(user => user.Alias.ToLower().Equals(authorAlias)).ToList();
            List<User> publishers = allUsers.Values.Where(user => user.Alias.ToLower().Equals(authorAlias)).ToList();
            LoadAuthors(authors);
            LoadPublishers(publishers);

            int[] bookGenres = wSBook.Genres;
            foreach(int genre in bookGenres)
            {
                ListItem genreItem = Genres.Items.FindByValue(genre.ToString());
                if (genreItem != null)
                    genreItem.Selected = true;
            }
        }

        protected void CustomISBN_ServerValidate(object source, ServerValidateEventArgs args)
        {
            List<Book> allBooks = ((Dictionary<int, Book>)Application["Books"]).Values.ToList();
            if (allBooks.Any(book => book.ISBN == ISBN.Text))
            {
                args.IsValid = false;
            }
        }

    }
}