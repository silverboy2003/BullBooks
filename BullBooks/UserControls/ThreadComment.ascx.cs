using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void createComment(Comment comment, int depth, User commenter)
        {
            CommenterPic.ImageUrl = "../" + commenter.Profile;
            CommenterName.Text = commenter.Alias;
            CommentDate.Text = String.Format("{0:g}", comment.CommentDate);
            CommentContent.Text = comment.CommentText;
            createThreadLines(depth);
        }
        private void createThreadLines(int depth)//create n thread lines where n = depth
        {
            for(int i = 0; i < depth; i++)
            {
                Panel newLineBox = new Panel();//each div would have a small margin to the left, and inside would be another div which would be 50% wider, resulting in the right border being in the middle
                Panel line = new Panel();

                newLineBox.CssClass = "LineBox";
                line.CssClass = "ThreadLine";

                newLineBox.Controls.Add(line);
                ThreadlineContainer.Controls.Add(newLineBox);
            }
        }
    }
}