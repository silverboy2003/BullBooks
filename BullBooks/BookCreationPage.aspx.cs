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
            string bookName = BookName.Text;
        }

        protected void UploadFile_Click(object sender, EventArgs e)
        {
            if(BookCoverUpload.HasFile)
            {
                string[] names = Directory.GetFiles(@"CoverPics");
                string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                string newName = (int.Parse(fileName) + 1).ToString() + ".png";
                string newPath = @"~\CoverPics\" + newName;
                BookCoverUpload.SaveAs(Server.MapPath(newPath));
                BookUploadContainer.Style.Add("background-image", $"../CoverPics/{newName}");

                //string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                //int newName = int.Parse(fileName) + 1;
                //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
            }
        }
    }
}