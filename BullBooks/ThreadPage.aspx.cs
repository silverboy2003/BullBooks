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
            
            LoadThread();
            LoadThreadComments();
            ThreadHeader.Text = currentThread.ThreadTitle;
            //ThreadText.Text = currentThread.ThreadText;
            ThreadText.InnerHtml = currentThread.ThreadText;
            PostingTime.Text = String.Format("{0:g}", currentThread.CreationDate);
            AuthorAlias.Text = currentThread.ThreadAuthor;
            if ((User)Session["User"] != null)
            {
                Editor.Visible = true;
                CommentSubmit.Visible = true;
                if(((User)Session["User"]).IsAdmin || ((User)Session["User"]).Id == currentThread.ThreadAuthorID)
                {
                    DeleteThreadButton.Visible = true;
                }
            }
        }
        private void RemoveComment(object sender, EventArgs data)
        {

        }
        private void LoadThread()
        {
            string idQuery = Request.QueryString["ThreadID"];
            if (idQuery != null)
            {
                int id = int.Parse(idQuery);
                Dictionary<int, Thread> allThread = (Dictionary<int, Thread>)Application["Threads"];
                if (allThread.ContainsKey(id))
                    currentThread = allThread[id];
                else
                    Response.Redirect("MainPage.aspx");
            }
            else
                Response.Redirect("MainPage.aspx");
        }
        private void LoadThreadComments()
        {
            foreach(Comment comment in currentThread.ThreadMasterComments)
            {
                CommentContainer.Controls.Add(LoadComments(comment));
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
            User commenter = ((Dictionary<int, User>)Application["Users"])[commentNode.CommentAuthorID];
            newComment.createComment(commentNode, commenter);
            CommentContainer.Controls.AddAt(0, newComment);
        }
        private UserControls.ThreadComment LoadComments(Comment commentNode)
        {
            UserControls.ThreadComment newComment = (UserControls.ThreadComment)Page.LoadControl("~/UserControls/ThreadComment.ascx");
            User commenter = ((Dictionary<int, User>)Application["Users"])[commentNode.CommentAuthorID];
            newComment.createComment(commentNode, commenter);
            if (commentNode.Replies != null)
                foreach (Comment comment in commentNode.Replies)
            {
                newComment.bindReply(LoadComments(comment));
            }
            return newComment;
        }
        protected void SendComment(object sender, EventArgs e)
        {
            string comment = HiddenEditor.Value;
            comment = comment.Replace("\r\n", string.Empty);
            BL.User commenter = (BL.User)Session["User"];
            BL.Comment newComment = new Comment(currentThread.ThreadID, comment, commenter.Id, commenter.Alias, DateTime.Now, 0);
            int newID = newComment.CommitComment();
            if(newID != -1)
            {
                Editor.Visible = false;
                CommentSubmit.Visible = false;
                currentThread.ThreadMasterComments.Add(newComment);
                currentThread.CntComments++;
                UserControls.ThreadComment currentComment = (UserControls.ThreadComment)Page.LoadControl("~/UserControls/ThreadComment.ascx");
                currentComment.createComment(newComment, commenter);
                CommentContainer.Controls.Add(currentComment);
            }
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }

        protected void DeleteThreadButton_Click(object sender, ImageClickEventArgs e)
        {
            Dictionary<int, Thread> allThreads = (Dictionary<int, Thread>)(Application["Threads"]);
            allThreads.Remove(currentThread.ThreadID);
            currentThread.RemoveThread();
            Response.Redirect("Threadsearchpage.aspx");
        }
    }
}