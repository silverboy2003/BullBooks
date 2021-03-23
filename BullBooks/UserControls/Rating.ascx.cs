using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BullBooks
{
    public partial class Rating : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //public void GenerateStars(double rating)//★
        //{
        //    double score = rating; // change this back later
        //    if (double.IsNaN(score))
        //        score = 0;
        //    int starsCreated = 0; //counts how many stars were created using the score, in order to generate the remaining stars gray
        //    while (score >= 1)
        //    {
        //        Label star = new Label();
        //        star.Text = "★";
        //        star.Style.Add("color", "yellow");
        //        StarPanel.Controls.Add(star);
        //        score--;
        //        starsCreated++;
        //    }
        //    if (score != 0)
        //    {
        //        int percent = (int)Math.Floor(score * 100);
        //        Label star = new Label();
        //        star.CssClass = "Star";
        //        star.Text = "★";
        //        star.Style.Add("background", $"linear-gradient(to right, yellow {percent}%, gray {percent}%, gray {100 - percent}%)");
        //        star.Style.Add("-webkit-text-fill-color", "transparent");
        //        star.Style.Add("background-clip", "text");
        //        star.Style.Add("-webkit-background-clip", "text");
        //        //need to create star with gradient using the percentage
        //        StarPanel.Controls.Add(star);
        //        starsCreated++;
        //        score = 0;
        //    }
        //    while (starsCreated != 5)
        //    {
        //        Label star = new Label();
        //        star.Text = "★";
        //        star.Style.Add("color", "gray");
        //        StarPanel.Controls.Add(star);
        //        starsCreated++;
        //    }
        //}
        public void ResetStars()
        {
            Star1.Style.Add("background", "gray");
            Star2.Style.Add("background", "gray");
            Star3.Style.Add("background", "gray");
            Star4.Style.Add("background", "gray");
            Star5.Style.Add("background", "gray");
        }
        public void GenerateStars(double rating)//★
        {
            double score = rating; // change this back later
            if (double.IsNaN(score))
                score = 0;
            int starsCreated = 0; //counts how many stars were created using the score, in order to generate the remaining stars gray
            while (score >= 1)
            {
                Label star = (Label)FindControl($"Star{starsCreated+1}");
                star.Style.Add("background", "yellow");
                score--;
                starsCreated++;
            }
            if (score != 0)
            {
                int percent = (int)Math.Floor(score * 100);
                Label star = (Label)FindControl($"Star{starsCreated + 1}");
                star.Style.Add("background", $"linear-gradient(to right, yellow {percent}%, gray {percent}%, gray {100 - percent}%)");
                //star.Style.Add("-webkit-text-fill-color", "transparent");
                //star.Style.Add("background-clip", "text");
                //star.Style.Add("-webkit-background-clip", "text");
                //need to create star with gradient using the percentage
                starsCreated++;
                score = 0;
            }
        }
    }
}