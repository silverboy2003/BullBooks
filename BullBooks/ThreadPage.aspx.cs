using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class ThreadPage : System.Web.UI.Page
    {
        private Thread currentThread;
        protected void Page_Load(object sender, EventArgs e)
        {
            currentThread = ((Dictionary<int, Thread>)Application["Threads"])[1];
        }
        private void LoadThreadComments()
        {
            foreach(Comment comment in currentThread.ThreadMasterComments)
            {
                LoadCommentAndReplies(comment, 0);
            }
        }
        /// <summary>
        /// a recursive fuction that treats comment sort of like trees. 
        /// i go to the lowest node then load it, then load the comment
        /// before it, and so on and so forth
        /// originally the comment would load upside down, but instead of 
        /// loading then into the last spot in the array, now i add each comment
        /// to the first place in the array, so that the first comment
        /// i load will be the last
        /// O(n)
        /// </summary>
        /// <param name="commentNode">a comment object, contains all comment date</param>
        /// <param name="depth">in order to determine how many thread lines to create</param>
        private void LoadCommentAndReplies(Comment commentNode, int depth)
        {
            foreach (Comment comment in commentNode.Replies)
            {
                LoadCommentAndReplies(comment, depth + 1);
            }
            UserControls.ThreadComment newComment = (UserControls.ThreadComment)Page.LoadControl("~/UserControls/ThreadComment.ascx");
            newComment.createComment(commentNode, depth);
            CommentContainer.Controls.AddAt(0, newComment);
        }
    }
}