﻿using System;
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
            string sql = "SELECT * FROM Reviews ORDER BY bookID ASC";
            DataTable reviews = DBHelper.GetDataTable(sql);
            return reviews;
        }
        public static int SendReview(List<object> inputs)
        {
            string sql = $"INSERT INTO Reviews (review, bookID, bookRating, reviewerID, reviewDate) VALUES (@Text1, {inputs[1]}, {inputs[2]}, {inputs[3]}, '{inputs[4]}')";
            return DBHelper.InsertWithAutoNumKey(sql, inputs);
        }//inserts new review
    }
}
