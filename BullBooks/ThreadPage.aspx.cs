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
    }
}