using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks.UserControls
{
    public partial class ReviewsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Load_Reviews(List<Review> reviews)
        {
            foreach(Review item in reviews)
            {
                Review review = item;
                ReviewControl currentReview = (ReviewControl)Page.LoadControl("~/UserControls/ReviewControl.ascx");
                currentReview.Load_Review(review);
                ReviewsContainer.Controls.Add(currentReview);
            }
        }
    }
}