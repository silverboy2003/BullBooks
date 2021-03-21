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
        public Review(string content, int bookid, int rating, int reviewerID, DateTime creation)
        {
            reviewContent = content;
            BookID = bookid;
            Rating = rating;
            ReviewerID = reviewerID;
            CreationDate = creation;
        }
        /// <summary>
        /// turns review data into a list and sends it to DAL in order to add to database
        /// </summary>
        /// <returns>new review id, if an error occurs it returns -1</returns>
        public int CommitReview()
        {
            List<object> inputs = new List<object>();
            inputs.Add(reviewContent);
            inputs.Add(BookID);
            inputs.Add(rating);
            inputs.Add(reviewerID);
            inputs.Add(creationDate);
            int newID = ReviewHelper.SendReview(inputs);
            reviewID = newID;
            return newID;
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
        public static List<Review> GetAssociatedReviews(int id, Dictionary<int, Review> allReviews)
        {
            Dictionary<int, Review> copyReviews = new Dictionary<int, Review>(allReviews);
            List<Review> reviews = copyReviews.Values.ToList();
            reviews.RemoveAll(review => review.ReviewerID != id);
            return reviews;
        }
    }
}
