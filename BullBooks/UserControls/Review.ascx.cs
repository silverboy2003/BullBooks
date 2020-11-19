using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class Comment : System.Web.UI.UserControl
    {
        private Review currentReview;
        private User reviewer;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SetInformation(Review review)
        {
            currentReview = review;
            reviewer = ((Dictionary<int, User>)Application["Users"])[review.ReviewerID];
        }
        protected void Load_Review(Review review)
        {
            SetInformation(review);

            ReviewerName.Text = reviewer.Alias;
            ReviewerPic.ImageUrl = reviewer.Profile;
            Stars.GenerateStars(currentReview.Rating);
            ReviewContent.Text = currentReview.ReviewContent;
        }
    }
}