using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.IO;
using System.Text.RegularExpressions;
using BullBooks.ISBNWS;
using System.Collections.Specialized;

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
                //}
                PublisherName.Items.Clear();
                AuthorName.Items.Clear();
                string currentBookID = Request.QueryString["id"];
                int tempInt;
                if (!string.IsNullOrEmpty(currentBookID) && int.TryParse(currentBookID, out tempInt))
                {
                    Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
                    Book currentBook = allBooks[int.Parse(currentBookID)];
                    if (!currentUser.IsAdmin && currentUser.Id != currentBook.AuthorID && currentUser.Id != currentBook.PublisherID)
                    {
                        NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
                        queryString.Add("id", currentBookID.ToString());
                        string query = queryString.ToString();
                        string newString = "BookPage.aspx" + '?' + query;
                        Response.Redirect(newString);
                    }
                    ISBN.Text = currentBook.ISBN;
                    ISBNContainer.Visible = false;
                    BookName.Text = currentBook.BookName;
                    ViewState["CoverPath"] = currentBook.BookCover;

                    AuthorName.Items.Add(new ListItem(currentBook.AuthorName.ToString(), currentBook.AuthorID.ToString()));
                    AuthorName.SelectedIndex = AuthorName.Items.IndexOf(AuthorName.Items.FindByValue(currentBook.AuthorID.ToString()));

                    PublisherName.Items.Add(new ListItem(currentBook.PublisherName.ToString(), currentBook.PublisherID.ToString()));
                    PublisherName.SelectedIndex = PublisherName.Items.IndexOf(PublisherName.Items.FindByValue(currentBook.PublisherID.ToString()));

                    foreach (int genre in currentBook.Genres)
                    {
                        ListItem genreItem = Genres.Items.FindByValue(genre.ToString());
                        if (genreItem != null)
                            genreItem.Selected = true;
                    }

                    Synopsis.Text = currentBook.BookSynopsis.Replace("<br>", "\r\n");
                    NumPages.Text = currentBook.NumPages.ToString();
                    NumChapters.Text = currentBook.NumChapters.ToString();
                    ReleaseDate.Value = currentBook.BookRelease.ToString("yyyy-MM-dd");
                    BookUploadContainer.ImageUrl = "../" + currentBook.BookCover;
                }
                else if (currentUser.IsAdmin)
                {
                    LoadAuthors(allUsers.Values.ToList());
                    LoadPublishers(allUsers.Values.ToList());
                }
                else if (currentUser.IsAuthor && currentUser.IsPublisher)
                {
                    AuthorName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                    PublisherName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                }
                else if (currentUser.IsAuthor)
                {
                    AuthorName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                    LoadPublishers(allUsers.Values.ToList());
                }
                else if (currentUser.IsPublisher)
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
        protected void LoadPublishers(List<User> allUsers)
        {
            List<User> publishers = new List<User>(allUsers);
            publishers.RemoveAll(user => !user.IsPublisher);
            PublisherName.Items.Clear();
            foreach(User publisher in publishers)
            {
                PublisherName.Items.Add(new ListItem(publisher.Alias + '-' + publisher.Username, publisher.Id.ToString()));
            }
            
        }
        protected void LoadAuthors(List<User> allUsers)
        {
            List<User> authors = new List<User>(allUsers);
            authors.RemoveAll(user => !user.IsAuthor);
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
                int publisherID = int.Parse(PublisherName.Items[PublisherName.SelectedIndex].Value);
                int authorID = int.Parse(AuthorName.Items[AuthorName.SelectedIndex].Value);
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

                if(ISBNContainer.Visible == false)
                {
                    Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
                    Book currentBook = allBooks[int.Parse(Request.QueryString["id"])];
                    currentBook.BookName = bookName;
                    currentBook.PublisherID = publisherID;
                    currentBook.AuthorID = authorID;
                    currentBook.PublisherName = publisherName;
                    currentBook.AuthorName = authorName;
                    currentBook.BookSynopsis = synopsis;
                    currentBook.BookCover = bookCover;
                    currentBook.NumPages = numPages;
                    currentBook.NumChapters = numChapters;
                    currentBook.BookRelease = releaseDate;
                    currentBook.Genres = genres;
                    if(currentBook.UpdateBook())
                        Response.Redirect($"BookPage.aspx?id={currentBook.Id}");
                }
                else
                {
                    Book newBook = new Book(-1, bookName, authorName, publisherName, publisherID, authorID, synopsis, bookCover, 0, 0, numPages, numChapters, releaseDate, isbn, genres, new List<Review>());
                    ISBNWS.WSBook yam = new WSBook
                    {
                        Isbn = isbn,
                        BookName = bookName,
                        Author = authorName,
                        Publisher = publisherName,
                        Synopsis = synopsis,
                        NumPages = numPages,
                        NumChapters = numChapters,
                        BookRelease = releaseDate,
                        Genres = genres.ToArray(),
                        Rating = 0
                    };
                    bool success = new ISBNWS.ISBN().AddNewBook(yam);
                    int newID = newBook.CommitBook();
                    if (newID != -1)
                    {
                        newBook.CommitGenres();
                        Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
                        allBooks.Add(newID, newBook);
                        Response.Redirect($"BookPage.aspx?id={newID}");
                    }
                }


            }
            else
            {
                
            }
        }

        protected void UploadFile_Click(object sender, EventArgs e)
        {
            bool fileOK = false;
            if (BookCoverUpload.HasFile)
            {

                String fileExtension = System.IO.Path.GetExtension(BookCoverUpload.FileName).ToLower();
                String[] allowedExtensions = { ".jpg", ".gif", ".png" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }

                if (fileOK)
                {
                    string[] names = Directory.GetFiles(@"CoverPics");
                    //string fileName = Path.GetFileNameWithoutExtension(names[names.Length-1]);
                    string newName = names.Length + ".png";
                    string newPath = @"CoverPics/" + newName;
                    BookCoverUpload.SaveAs(Server.MapPath("~/" + newPath));
                    //BookUploadContainer.Style.Add("background-image", "../" + newPath);
                    BookUploadContainer.ImageUrl = "../" + newPath;
                    ViewState["CoverPath"] = newPath;
                    //string[] names = Directory.GetFiles(@"CoverPics");
                    //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                    //int newName = int.Parse(fileName) + 1;
                    //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
                }
            }
        }

        protected void ISBNService_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ISBN.Text))
            {
                ISBNWS.ISBN ws = new ISBN();
                ISBNWS.WSBook wSBook = ws.GetBookByISBN(ISBN.Text);
                if(wSBook != null)
                {
                    BookName.Text = wSBook.BookName;
                    Synopsis.Text = wSBook.Synopsis;
                    NumPages.Text = wSBook.NumPages.ToString();
                    NumChapters.Text = wSBook.NumChapters.ToString();
                    ReleaseDate.Value = wSBook.BookRelease.ToString("yyyy-MM-dd");

                    string authorAlias = wSBook.Author.ToLower();
                    string publisherAlias = wSBook.Publisher.ToLower();

                    Dictionary<int, User> allUsers = (Dictionary<int, User>)Application["Users"];
                    List<User> authors = allUsers.Values.Where(user => user.Alias.ToLower().Equals(authorAlias)).ToList();
                    List<User> publishers = allUsers.Values.Where(user => user.Alias.ToLower().Equals(publisherAlias)).ToList();
                    LoadAuthors(authors);
                    LoadPublishers(publishers);

                    int[] bookGenres = wSBook.Genres;
                    foreach (int genre in bookGenres)
                    {
                        ListItem genreItem = Genres.Items.FindByValue(genre.ToString());
                        if (genreItem != null)
                            genreItem.Selected = true;
                    }
                }
                
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
        protected void ValidateDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime inputDate = DateTime.Parse(ReleaseDate.Value);
            if (DateTime.Compare(inputDate, DateTime.Today) >= 0)
                args.IsValid = false;
        }

    }
}