using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;

namespace BullBooks
{
    public partial class ThreadCreationPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
                Response.Redirect("ThreadSearchPage.aspx");
            LoadBooksDropdown();
        }

        protected void ThreadSubmitButton_Click(object sender, ImageClickEventArgs e)
        {
            Dictionary<int, Book> allBooks = (Dictionary<int, Book>)Application["Books"];
            int selectedBookID = int.Parse(SelectBook.Value);
            string threadBookName = allBooks[selectedBookID].BookName;
            string title = ThreadTitle.Text;
            int authorID = ((User)Session["User"]).Id;
            string authorName = ((User)Session["User"]).Alias;

            string text = HiddenEditor.Value;
            text = text.Replace("\r\n", string.Empty);

            Thread newThread = new Thread(-1, title, text, selectedBookID, threadBookName, authorID, authorName, 0, DateTime.Now, new List<Comment>());
            int newID = newThread.SubmitNewThread();
            if (newID != -1) 
                ((Dictionary<int, Thread>)Application["Threads"]).Add(newID, newThread);

            Response.Redirect($"ThreadPage.aspx?ThreadID={newID}");
        }
        protected void LoadBooksDropdown()
        {
            Dictionary<int, Book> allBooks = (Dictionary<int,Book>)Application["Books"];
            foreach (Book book in allBooks.Values)
            {
                ListItem bookItem = new ListItem();
                bookItem.Value = book.ID.ToString();
                bookItem.Text = book.BookName + '-' + book.AuthorName;
                SelectBook.Items.Add(bookItem);
            }
        }
    }
}