using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static BL.Book;

namespace BullBooks.Controllers
{
    public partial class BookList : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public int LoadBooks(List<Book> books)//loads books and return amount
        {
            int counter = 0;
            foreach (BL.Book b in books)
            {
                BookPreview bp = (BookPreview)Page.LoadControl("~/UserControls/BookPreview.ascx");
                listBox.Controls.Add(bp);
                bp.BookID = b.Id;
                bp.Name = b.BookName;
                bp.Author = b.AuthorName;
                bp.Cover = b.BookCover;
                counter++;
            }
            return counter;
        }
        public void LoadBooks(string bookName, List<int> genres)
        {
            
            List<BL.Book> books = BL.Book.GetBooksBySearch(bookName, genres, (Dictionary<int, BL.Book>)Application["Books"]);
            foreach(BL.Book b in books)
            {
                BookPreview bp = (BookPreview)Page.LoadControl("~/UserControls/BookPreview.ascx");
                listBox.Controls.Add(bp);
                bp.BookID = b.Id;
                bp.Name = b.BookName;
                bp.Author = b.AuthorName;
                bp.Cover = b.BookCover;
            }
        }
    }
}