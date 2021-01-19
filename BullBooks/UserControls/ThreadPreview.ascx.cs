using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks.UserControls
{
    public partial class ThreadPreview : System.Web.UI.UserControl
    {
        int ThreadID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void SetThread(Thread currentThread)
        {
            ThreadTitle.Text = currentThread.ThreadTitle;
            BookName.Text = currentThread.ThreadBook;
            PostingDate.Text = String.Format("{0:g}", currentThread.CreationDate);
            ThreadID = currentThread.ThreadID;
        }
    }
}