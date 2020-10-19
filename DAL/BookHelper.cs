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
        public static DataTable GetBookSearch(string bookName, List<int> genres)
        {
            string genresSQL = @"SELECT Books.bookID, bookName, authorName, bookCoverPic FROM";
            if (genres == null)
                genresSQL += " Books";
            else
                genresSQL += "(Books INNER JOIN GenresToBooks ON Books.bookID = GenresToBooks.bookID)";

            if (bookName != null) 
                genresSQL += @" WHERE Books.bookName LIKE @Text ";

            if (genres != null)
            {
                if (bookName != null)
                    genresSQL += "AND genreID IN (";
                else
                    genresSQL += "WHERE genreID IN(";
                foreach (int genre in genres)
                {
                    genresSQL += $"{genre}, ";
                }
                genresSQL += $") GROUP BY Books.bookID, bookName, authorName, bookCoverPic HAVING COUNT(Books.bookID) ={genres.Count}";
            }
            else
                genresSQL += " GROUP BY Books.bookID, bookName, authorName, bookCoverPic";
            DataTable books;
            if (bookName != null)
                books = DBHelper.GetDataTable(genresSQL, bookName);//Books.BookID, bookName, bookAuthor, BookCoverPic
            else
                books = DBHelper.GetDataTable(genresSQL);
            return books;
        }
        public static DataTable GetAllBooks()
        {
            string sql = "SELECT Books.* FROM(SELECT AuthorT.*, PublisherT.publisherName FROM(SELECT Books.*, alias AS authorName FROM Books INNER JOIN Users ON Books.authorID = Users.userID)  AS AuthorT INNER JOIN(SELECT Books.bookID, alias AS publisherName FROM Books INNER JOIN Users ON Books.publisherID = Users.userID)  AS PublisherT ON AuthorT.bookID = PublisherT.bookID)  AS Books;";
            DataTable Books = DBHelper.GetDataTable(sql);
            return Books;
        }
        public static DataTable GetBookGenres(int bookID)
        {
            string sql = $"SELECT * FROM (Genres INNER JOIN GenresToBooks ON GenresToBooks.genreID = Genres.genreID) WHERE bookID = {bookID}";
            DataTable genres = DBHelper.GetDataTable(sql);
            return genres;
        }
    }
}
