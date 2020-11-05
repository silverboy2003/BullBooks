﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class Helper
    {
        public static void SetDBConnString(string conn)
        {
            DAL.DBHelper.SetConnString(conn);
        }
        public static void SetAllReviews(Dictionary<int, Book> books)
        {
            
            LinkedListNode<Review> reviewNode = Review.LoadReviews().Next;
            foreach(Book book in books.Values)
            {
                List<Review> bookReviews = new List<Review>();
                while(reviewNode != null && reviewNode.Value.BookID == book.ID)
                {
                    bookReviews.Add(reviewNode.Value);
                    reviewNode = reviewNode.Next;
                }
                book.Reviews = bookReviews;
            }
        }
    }
}
