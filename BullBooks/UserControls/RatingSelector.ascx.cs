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
        
        /// <summary>
        /// this method gets the selected star rating out of 5, if none is selected
        /// (meaning checkedButton is null) then rating is 0.
        /// </summary>
        /// <returns>a rating of 0-5 of type int</returns>
        public int GetRating()
        {
            RadioButton checkedButton = StarPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedButton == null)
                return 0;
            return int.Parse(checkedButton.AccessKey);
        }
    }
}