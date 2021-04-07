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
            ThreadID = threadID;
            CommentText = text;
            CommentAuthorID = userID;
            CommentAuthorName = alias;
            CommentDate = date;
            ReplyTo = replyID;
            Replies = new List<Comment>();
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
        public int CommitComment()
        {
            List<object> inputs = new List<object>();
            inputs.Add(threadID);
            inputs.Add(CommentText);
            inputs.Add(commentAuthorID);
            inputs.Add(replyTo);
            inputs.Add(commentDate.ToString());
            int newID = CommentHelper.SendComment(inputs);
            this.commentID = newID;
            if (replyTo == 0)
                replyTo = newID;
            return newID;
        }
        /// <summary>
        /// Gets a comment and if any of its replies do not contain the current
        /// comment then it returns null. otherwise (if it contains the comment)
        /// if returns a pointer to the containing comment.
        /// </summary>
        /// <param name="commentNode">kind of self explanatory. the comment are arranged in some sort
        /// of twisted tree format, where each node contains more than one child. so commentnode is each
        /// tree node</param>
        /// <returns>null if there is no comment in the replies containing the current comment
        /// or a Comment object if there is (and it is the comment than contains)</returns>
        public Comment GetContainingComment(Comment commentNode)
        {
            if (commentNode.CommentID == replyTo)
                return commentNode;
            else if (commentNode.replies.Count == 0)
                return null;
            foreach(Comment nextComment in commentNode.replies)
            {
                Comment containingComment = GetContainingComment(nextComment);
                if (containingComment != null)
                    return containingComment;
            }
            return null;
        }
        public bool DeleteComment()
        {
            bool success = AdminHelper.DeleteComment(CommentID);
            return success;
        }
    }
}
