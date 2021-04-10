using System;
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
        }//sets the connection string in the DB class
        public static void SetAllReviews(Dictionary<int, Book> books)//gets a list of reviews sorted by bookID and bind them to corresponding book
        {
            
            LinkedListNode<Review> reviewNode = Review.LoadReviews().Next;
            foreach(Book book in books.Values)
            {
                List<Review> bookReviews = new List<Review>();
                while(reviewNode != null && reviewNode.Value.BookID == book.Id)
                {
                    bookReviews.Add(reviewNode.Value);
                    reviewNode = reviewNode.Next;
                }
                book.Reviews = bookReviews;
            }
        }//
        public static Dictionary<int, Thread> LoadThreads()
        {
            Dictionary<int, Thread> threads = Thread.GetAllThreads(); //gets all threads without comments loaded
            Dictionary<int, Comment> allComments = Comment.GetBoundComments();
            foreach(Comment currentComment in allComments.Values)
            {
                if (currentComment.CommentID == currentComment.ReplyTo)
                    threads[currentComment.ThreadID].ThreadMasterComments.Add(currentComment);
            }
            return threads;
        }//gets all threads in a list and binds all comments to them
    }
}
