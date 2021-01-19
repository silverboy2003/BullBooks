using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL; 

namespace BullBooks
{
    public partial class ThreadSearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<int, Thread> allThreads = (Dictionary<int, Thread>)Application["Threads"];
            LoadPreviews(allThreads);
        }
        private void LoadPreviews(Dictionary<int, Thread> results)
        {
            
            foreach(Thread current in results.Values)
            {
                UserControls.ThreadPreview newPreview = (UserControls.ThreadPreview)Page.LoadControl("~/UserControls/ThreadPreview.ascx");
                newPreview.SetThread(current);
                PreviewsContainer.Controls.Add(newPreview);
            }

        }
    }
}