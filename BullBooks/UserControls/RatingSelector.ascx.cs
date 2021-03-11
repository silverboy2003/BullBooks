using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BullBooks
{
    public partial class RatingSelector : System.Web.UI.UserControl
    {
        public delegate void SendReviewDelegate(int rating);
        public event SendReviewDelegate SendReview;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SendEvent(object sender, EventArgs e)
        {
            SendReview(int.Parse(((Button)sender).CommandArgument));
        }

    }
}