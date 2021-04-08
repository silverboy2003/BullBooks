using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace BullBooks
{
    public partial class EditProfilePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                BannerImage.Style.Add("background-image", "../" + newPath);
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
                ProfileImage.Style.Add("background-image", "../" + newPath);
                ViewState["ProfilePath"] = newPath;
                //string[] names = Directory.GetFiles(@"CoverPics");
                //string fileName = Path.GetFileNameWithoutExtension(names[names.Length - 1]);
                //int newName = int.Parse(fileName) + 1;
                //BookCoverUpload.SaveAs(@"CoverPics\" + BookCoverUpload.FileName);
            }
        }
    }
}