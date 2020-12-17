using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class ThreadHelper
    {
        public static DataTable GetAllThreads()
        {
            string sql = "SELECT Threads.*, Books.bookName AS  threadBook, Users.alias AS threadAuthor FROM (Threads INNER JOIN Books ON Books.bookID = Threads.threadBookID) INNER JOIN Users ON Threads.threadAuthorID = Users.userID";
            DataTable allThreads = DBHelper.GetDataTable(sql);
            return allThreads;
        }
    }
}
