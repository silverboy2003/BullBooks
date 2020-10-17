using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace BL
{
    public class Review
    {
        private double rating;

        public double Rating { get => rating; set => rating = value; }

        public static int LoadReviews(Book book)
        {
            int bookID = book.ID;
        }
    }
}
