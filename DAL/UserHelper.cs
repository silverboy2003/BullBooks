using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace DAL
{
    public class UserHelper
    {
        public static DataRow GetUser(string id)
        {
            string sql = $"SELECT * FROM Users WHERE userID = '{id}'";
            DataTable user = DBHelper.GetDataTable(sql);
            if (user != null)
                return user.Rows[0];
            return null;
        }
        public static DataTable GetReadBooksList(string id)
        {
            string sql = $"SELECT Books.bookID, Books.bookName, Books.bookCoverPic FROM Books INNER JOIN BooksRead ON BooksRead.bookID = Books.bookID WHERE BooksRead.userID = '{id}'";
            //get all books from booksread table where the user id is the parameter
            DataTable books = DBHelper.GetDataTable(sql);
            return books;
        }
    }
}
