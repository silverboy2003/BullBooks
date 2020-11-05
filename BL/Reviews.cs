using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using DAL;

namespace BL
{
    public class Review
    {
        private int reviewID;
        private double rating;
        private string reviewContent;
        private int bookID;
        private int reviewerID;
        private DateTime creationDate;

        public double Rating { get => rating; set => rating = value; }
        public int BookID { get => bookID; set => bookID = value; }
        public int ReviewerID { get => reviewerID; set => reviewerID = value; }
        public string ReviewContent { get => reviewContent; set => reviewContent = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public int ReviewID { get => reviewID; set => reviewID = value; }

        public Review(DataRow review)
        {
            ReviewID = (int)review["reviewID"];
            ReviewContent = (string)review["review"];
            BookID = (int)review["bookID"];
            Rating = (int)review["bookRating"];
            ReviewerID = (int)review["reviewerID"];
            creationDate = DateTime.Parse(review["reviewDate"].ToString());
        }

        public static LinkedListNode<Review> LoadReviews()//get all reviews in the form of datatable and convert+return them in the form of nodes
        {
            DataTable reviews = ReviewHelper.GetAllReviews();
            if (reviews == null)
                return null;
            LinkedList<Review> ReviewList = new LinkedList<Review>();
            LinkedListNode<Review> ReviewDummyNode = new LinkedListNode<Review>(null);
            ReviewList.AddFirst(ReviewDummyNode);
            LinkedListNode<Review> ReviewNode = ReviewDummyNode;
            foreach (DataRow reviewRow in reviews.Rows)
            {
                Review review = new Review(reviewRow);
                ReviewList.AddAfter(ReviewNode, review);
                ReviewNode = ReviewNode.Next;
            }
            return ReviewDummyNode;
        }
    }
}
