using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DAL
{
    public class UserHelper
    {
        public static DataRow GetUser(int id)
        {
            string sql = $"SELECT * FROM Users WHERE userID = '{id}'";
            DataTable user = DBHelper.GetDataTable(sql);
            if (user != null)
                return user.Rows[0];
            return null;
        }
        public static DataTable GetReadBooksList(int id)
        {
            string sql = $"SELECT Books.bookID, Books.bookName, Books.bookCoverPic FROM Books INNER JOIN BooksRead ON BooksRead.bookID = Books.bookID WHERE BooksRead.userID = '{id}'";
            //get all books from booksread table where the user id is the parameter
            DataTable books = DBHelper.GetDataTable(sql);
            return books;
        }
        public static DataRow DoLogin(string username, string password)
        {
            string sql = "SELECT * FROM Users WHERE UCASE(username) = UCASE(@Text)";
            DataTable results = DBHelper.GetDataTable(sql, username);
            if (results == null)
                return null;
            DataRow user = results.Rows[0];
            string hashed = (string)(user["password"]);
            if (BCrypt.Net.BCrypt.Verify(password, hashed))
                return user;
            return null;
        }
        public static int DoRegister<T>(List<T> inputs)
        {
            string sql = "INSERT INTO Users ( email, username, gender, birthDate, [password], creationDate, alias) VALUES(@Text1, @Text2, @Text3, @Text4, @Text5, @Text6, @Text7)";
            int newID = DBHelper.InsertWithAutoNumKey(sql, inputs);
            return newID;
        }
        public static bool ChcekAvailability(string input, string type)
        {
            string sql = $"SELECT {type} FROM Users WHERE {type} = @Text";
            DataTable result = DBHelper.GetDataTable(sql, input);
            return result == null;
        }
    }
}
