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
                
                LoadProfile();
            }
        }
        protected void LoadProfile()
        {
            UserBanner.Style.Add("background-image", currentUser.Banner);
            UsernameLabel.Text = currentUser.Alias + "'s" + " profile";
            ProfileImage.ImageUrl = "../" + currentUser.Profile;
        }
        protected void Blist_Load(object sender, EventArgs e)
        {
            if(currentUser != null)
            {
                int id = currentUser.Id;
                int amount = Blist.LoadBooks(id);
                amoutBooks = amount;
            }
            BooksAmount.Text = amoutBooks.ToString() + " Books read";
        }

        protected void EditProfileButton_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}