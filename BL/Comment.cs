using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using System.Reflection;

namespace BL
{
    public class Comment
    {
        private int commentID;
        private int threadID;
        private string commentText;
        private int commentAuthorID;
        private string commentAuthorName;
        private DateTime commentDate;
        private int replyTo; //if replyTo value is the same as commentID, that means it's a 'master' comment
        private List<Comment> replies; //load seperately 

        public int CommentID { get => commentID; set => commentID = value; }
        public int ThreadID { get => threadID; set => threadID = value; }
        public string CommentText { get => commentText; set => commentText = value; }
        public int CommentAuthorID { get => commentAuthorID; set => commentAuthorID = value; }
        public string CommentAuthorName { get => commentAuthorName; set => commentAuthorName = value; }
        public DateTime CommentDate { get => commentDate; set => commentDate = value; }
        public int ReplyTo { get => replyTo; set => replyTo = value; }
        public List<Comment> Replies { get => replies; set => replies = value; }

        public Comment(int threadID, string text, int userID, string alias, DateTime date, int replyID)
        {
            commentID = -1;
            ThreadID = ThreadID;
            CommentText = text;
            CommentAuthorID = userID;
            CommentAuthorName = alias;
            CommentDate = date;
            ReplyTo = replyID;
        }
        public Comment(DataRow comment)
        {
            commentID = (int)comment["commentID"];
            threadID = (int)comment["threadID"];
            commentText = (string)comment["commentText"];
            commentAuthorID = (int)comment["commentAuthorID"];
            replyTo = (int)comment["replyTo"];
            commentDate = (DateTime)comment["commentDate"];
            commentAuthorName = (string)comment["commentAuthorName"];
            Replies = new List<Comment>();
        }
        private static Dictionary<int, Comment> GetAllThreadComments()
        {
            DataTable threadComments = CommentHelper.GetAllComments();
            Dictionary<int, Comment> allComments = new Dictionary<int, Comment>();
            foreach(DataRow comment in threadComments.Rows)
            {
                Comment newComment = new Comment(comment);
                allComments.Add(newComment.commentID, newComment);
            }
            return allComments;
        }
        public static Dictionary<int, Comment> GetBoundComments()
        {
            Dictionary<int, Comment> allComments = GetAllThreadComments();
            if (allComments == null)
                return null;
            foreach(Comment tempComment in allComments.Values)
            {
                int replyTo = tempComment.replyTo;
                if (replyTo != tempComment.commentID)
                {
                    allComments[replyTo].replies.Add(tempComment);
                }
            }
            return allComments;
        } 
    }
}
