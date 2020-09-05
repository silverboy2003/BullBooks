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
        protected void LoadBooks(string bookName, List<string> genres)
        {
            List<BL.Book> books = BL.Book.GetBooksBySearch(bookName, genres);
            foreach(BL.Book b in books)
            {
                BookPreview bp = new BookPreview();
                bp.BookID = b.ID;
                bp.Name = b.BookName;
                bp.Author = b.BookAuthor;
                bp.Cover = b.BookCover;
                bp.LoadBook();
                listBox.Controls.Add(bp);
            }
        }
    }
}