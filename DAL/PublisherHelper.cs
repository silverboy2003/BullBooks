using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class PublisherHelper
    {
        public static DataTable GetPublishedBooksList(int id)
        {
            string sql = $"SELECT bookID, bookName, bookCoverPic FROM Books WHERE publisherID = '{id}'";
            //get all books from booksread table where the publisher id is the parameter
            DataTable books = DBHelper.GetDataTable(sql);
            return books;
        }
    }
}
