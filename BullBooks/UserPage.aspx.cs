using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class UserPage : System.Web.UI.Page
    {
        User currentUser;
        int amoutBooks;
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["userId"];
            if (string.IsNullOrEmpty(id))
                Response.Redirect("MainPage.aspx");
            int userID = int.Parse(Request.QueryString["userId"]);
            Dictionary<int, User> allUsers = (Dictionary<int, User>)(Application["Users"]);
            if (!allUsers.ContainsKey(userID))
                Response.Redirect("MainPage.aspx");
            currentUser = allUsers[userID];
            if (!IsPostBack)
            {
                if (currentUser.Id == userID)
                    EditProfileButton.Visible = true;
                LoadProfile();
                Blist_Load();
                LoadPublishedBooks();
                LoadWrittenBooks();
            }
        }
        protected void LoadPublishedBooks()
        {
            int id = currentUser.Id;
            int amount = PublishedBooks.LoadBooks(Book.GetPublishedBook(id, (Dictionary<int, Book>)Application["Books"]));
            if (amount > 0)
            {
                PublishedBooks.Visible = true;
                PublishedLabel.Visible = true;
            }
        }
        protected void LoadWrittenBooks()
        {
            int id = currentUser.Id;
            int amount = WrittenBooks.LoadBooks(Book.GetWrittenBooks(id, (Dictionary<int, Book>)Application["Books"]));
            if (amount > 0)
            {
                WrittenBooks.Visible = true;
                WrittenLabel.Visible = true;
            }
        }
        protected void Blist_Load()
        {
            int id = currentUser.Id;
            int amount = Blist.LoadBooks(Book.GetReadBooks(id, (Dictionary<int, Book>)Application["Books"]));
            if (amount > 0)
            {
                Blist.Visible = true;
                BlistLabel.Visible = true;
            }
        }
        protected void LoadProfile()
        {
            UserBanner.ImageUrl = "../" + currentUser.Banner;
            UsernameLabel.Text = currentUser.Alias + "'s" + " profile";
            ProfileImage.ImageUrl = "../" + currentUser.Profile;
        }
        protected void EditProfileButton_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("EditProfilePage.aspx");
        }
    }
}