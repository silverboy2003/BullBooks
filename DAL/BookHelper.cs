using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public static class BookHelper
    {
        public static DataTable GetBookSearch(string bookName, List<string> genres)
        {
            string genresSQL = $"SELECT Books.BookID, bookName, bookAuthor, BookCoverPic FROM (Books INNER JOIN GenreToBook ON Books.BookID = GenreToBook.bookID) WHERE bookName LIKE '%@Text%' ";
            
            foreach(string genre in genres)
            {
                genresSQL += $"AND {genre} = True ";
            }
            DataTable books = DBHelper.GetDataTable(genresSQL, bookName);//Books.BookID, bookName, bookAuthor, BookCoverPic
            return books;
        }
    }
}
