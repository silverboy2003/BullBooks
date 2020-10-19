using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class ReviewHelper
    {
        public static DataTable GetAllReviews()//gets all reviews SORTED by book id for easy value assignemnt later
        {
            string sql = "SELECT * FROM Reviews ORDER BY bookID DESC";
            DataTable reviews = DBHelper.GetDataTable(sql);
            return reviews;
        }
    }
}
