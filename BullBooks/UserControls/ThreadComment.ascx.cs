﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks.UserControls
{
    public partial class ThreadComment : System.Web.UI.UserControl
    {
        public Comment currentComment;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["User"] == null)
            {
                ReplyButton.Visible = false;
                CancelButton.Visible = false;
            }
        }
        public void createComment(Comment comment, User commenter)
        {
            currentComment = comment;
            CommenterPic.ImageUrl = "../" + commenter.Profile;
            CommenterName.Text = commenter.Alias;
            CommentDate.Text = String.Format("{0:g}", comment.CommentDate);
            //CommentContent.Text = comment.CommentText;
            CommentTextContainer.InnerHtml = comment.CommentText;
            ReplyButton.CommandArgument = comment.CommentID.ToString();
            
        }
        public void bindReply(ThreadComment reply)
        {
            Replies.Controls.Add(reply);
        }
        private void createThreadLines(int depth)//create n thread lines where n = depth
        {
            if (depth != 0)
            {
                Panel container = new Panel();
                container.ID = "ThreadlineContainer";
                container.CssClass = "ThreadlineContainer";
                CommentContainer.Controls.Add(container);

                for (int i = 0; i < depth; i++)
                {
                    Panel newLineBox = new Panel();//each div would have a small margin to the left, and inside would be another div which would be 50% wider, resulting in the right border being in the middle
                    Panel line = new Panel();

                    newLineBox.CssClass = "LineBox";
                    line.CssClass = "ThreadLine";

                    newLineBox.Controls.Add(line);
                    container.Controls.Add(newLineBox);
                }
            }
        }

        protected void ReplyButtonPress(object sender, ImageClickEventArgs e)
        {
                ReplyEditor.Visible = true;
                Page.ClientScript.RegisterStartupScript(GetType(), "Key1", $"ReplaceReplyEditor({ReplyEditor.ClientID})", true);
                CancelButton.Visible = true;
                SendReplyButton.Visible = true;
        }
        protected void CancelButtonPress(object sender, ImageClickEventArgs e)
        {
            CancelButton.Visible = false;
            SendReplyButton.Visible = false;
        }

        protected void SendReply(object sender, EventArgs e)
        {
            string comment = HiddenReply.Value;
            comment = comment.Replace("\r\n", string.Empty);
        }
    }
}