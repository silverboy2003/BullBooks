using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class BookReview : System.Web.UI.UserControl
    {
        private Review currentReview;
        private User reviewer;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void SetInformation(Review review)
        {
            currentReview = review;
            Dictionary<int, User> users = (Dictionary<int, User>)Application["Users"];
            reviewer = users[currentReview.ReviewerID];
        }
        public void Load_Review(Review review)
        {
            SetInformation(review);

            ReviewDate.Text = currentReview.CreationDate.ToString("dd/MM/yyyy");
            ReviewerName.Text = reviewer.Alias;
            ReviewerPic.ImageUrl = "../" + reviewer.Profile;
            Rating stars = (Rating)Page.LoadControl("~/UserControls/Rating.ascx");
            stars.ID = "Stars";
            ReviewContainer.Controls.Add(stars);
            stars.GenerateStars(currentReview.Rating);
            ReviewContent.Text = currentReview.ReviewContent;
        }
    }
}