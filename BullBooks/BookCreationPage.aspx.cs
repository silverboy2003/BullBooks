using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.IO;

namespace BullBooks
{
    public partial class BookCreationPage : System.Web.UI.Page
    {
        private string ImageDirectory;
        protected void Page_Load(object sender, EventArgs e)
        {
            User currentUser = (User)Session["User"];
            if (currentUser == null || (!currentUser.IsAdmin && !currentUser.IsPublisher && !currentUser.IsAuthor))
                Response.Redirect("SearchPage.aspx");
            if (!IsPostBack)
            {
                LoadGenres();
                if (currentUser.IsAdmin || (currentUser.IsAuthor && currentUser.IsPublisher))
                {
                    LoadAuthors();
                    LoadPublishers();
                }
                else if (currentUser.IsAuthor)
                {
                    AuthorName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                    LoadPublishers();
                }
                else if(currentUser.IsPublisher)
                {
                    PublisherName.Items.Add(new ListItem(currentUser.Alias + '-' + currentUser.Username, currentUser.Id.ToString()));
                    LoadAuthors();
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
        protected void LoadPublishers()
        {
            Dictionary<int, User> allUsers = (Dictionary<int, User>)Application["Users"];
            List<User> publishers = BL.User.GetPublishers(allUsers.Values.ToList());
            foreach(User publisher in publishers)
            {
                PublisherName.Items.Add(new ListItem(publisher.Alias + '-' + publisher.Username, publisher.Id.ToString()));
            }
            
        }
        protected void LoadAuthors()
        {
            Dictionary<int, User> allUsers = (Dictionary<int, User>) Application["Users"];
            List<User> authors = BL.User.GetAuthors(allUsers.Values.ToList());
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
                string bookCover = ImageDirectory;
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
                Book newBook = new Book(-1, bookName, authorName, publisherName, publisherID, authorID, synopsis, bookCover, 0, 0, numPages, numChapters, releaseDate, isbn, genres);
                
                int newID = newBook.CommitBook();
                if (newID != -1)
                {
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
                string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                string newName = (int.Parse(fileName) + 1).ToString() + ".png";
                string newPath = @"CoverPics/" + newName;
                BookCoverUpload.SaveAs(Server.MapPath("~/" + newPath));
                BookUploadContainer.Style.Add("background-image", "../" + newPath);
                ImageDirectory = newPath;
                //string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                //int newName = int.Parse(fileName) + 1;
                //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
            }
        }

        protected void ISBNService_Click(object sender, EventArgs e)
        {

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