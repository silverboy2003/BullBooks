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
        }//returns all threads in a datatable 
        public static int SubmitThread(List<object> inputs, int bookID, int threadAuthorID, DateTime submissionDate)
        {
            string sql = $"INSERT INTO Threads (threadTitle, threadText, threadBookID, threadAuthorID, threadDate) VALUES (@Text1, @Text2, {bookID}, {threadAuthorID}, '{submissionDate}')";
            int newID = DBHelper.InsertWithAutoNumKey(sql, inputs);
            return newID;
        }//Inserts new thread
    }
}
