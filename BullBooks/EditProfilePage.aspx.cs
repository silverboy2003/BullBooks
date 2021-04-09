using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BL;

namespace BullBooks
{
    public partial class EditProfilePage : System.Web.UI.Page
    {
        private User currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("MainPage.aspx");
            Dictionary<int, User> allUsers = (Dictionary<int, User>)Application["Users"];
            currentUser = allUsers[((User)Session["User"]).Id];
            if (!IsPostBack)
            {
                ProfileImage.ImageUrl = "../" + currentUser.Profile;
                BannerImage.ImageUrl = "../" + currentUser.Banner;
                AliasEdit.Text = currentUser.Alias;
            }
        }

        protected void UploadBanner_Click(object sender, EventArgs e)
        {
            if (BannerFile.HasFile)
            {
                string[] names = Directory.GetFiles(@"UserImages/Banners");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length-1]);
                string newName = names.Length + ".png";
                string newPath = @"UserImages/Banners/" + newName;
                BannerFile.SaveAs(Server.MapPath("~/" + newPath));
                BannerImage.ImageUrl = "../" + currentUser.Banner;
                ViewState["BannerPath"] = newPath;
                //string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                //int newName = int.Parse(fileName) + 1;
                //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
            }
        }

        protected void UploadProfile_Click(object sender, EventArgs e)
        {
            if (ProfileFile.HasFile)
            {
                string[] names = Directory.GetFiles(@"UserImages/Profile");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length-1]);
                string newName = names.Length + ".png";
                string newPath = @"UserImages/Profile/" + newName;
                ProfileFile.SaveAs(Server.MapPath("~/" + newPath));
                ProfileImage.ImageUrl = "../" + currentUser.Profile;
                ViewState["ProfilePath"] = newPath;
                //string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                //int newName = int.Parse(fileName) + 1;
                //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
            }
        }

        protected void UpdateProfileButton_Click(object sender, ImageClickEventArgs e)
        {
            string bannerPath = (ViewState["BannerPath"] == null) ? null : ViewState["BannerPath"].ToString();
            string profilePath = (ViewState["ProfilePath"] == null) ? null : ViewState["ProfilePath"].ToString();
            string alias = AliasEdit.Text;

            string password = NewPassword.Text;
            string conPassword = ConfirmPassword.Text;

            currentUser.Banner = (bannerPath == null) ? currentUser.Banner : bannerPath;
            currentUser.Profile = (profilePath == null)  ? currentUser.Profile : profilePath;
            currentUser.Alias = alias;
            if (!string.IsNullOrEmpty(password) && password == conPassword)
                currentUser.Password = password;
            currentUser.UpdateUser();

        }
    }
}