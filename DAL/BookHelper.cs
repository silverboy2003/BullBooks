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
        public static int InsertBook(List<object> inputs, int author, int publisher, int numPages, int numChapters, DateTime releaseDate, string isbn, string bookCover)
        {
            string sql = $@"INSERT INTO Books (bookName, authorID, publisherID, bookSynopsis, bookCoverPic, numPages, numChapters, bookReleaseDate, ISBN) VALUES (@Text1, {author}, {publisher}, @Text2, '{bookCover}', {numPages}, {numChapters}, '{releaseDate}', {isbn})";
            int newID = DBHelper.InsertWithAutoNumKey(sql, inputs);
            return newID;
        }
        /// <summary>
        /// a recursive function that returns true if at least on genre was inserted successfully
        /// </summary>
        /// <param name="bookID">id correlating to the book</param>
        /// <param name="genres">list of genres identified by an int id</param>
        /// <returns></returns>
        public static bool InsertGenres(int bookID, List<int> genres)
        {
            if (genres.Count == 0)
                return false;
            string sql = $"INSERT INTO GenresToBooks (bookID, genreID) VALUES ({bookID}, {genres[0]})";
            bool success = DBHelper.WriteData(sql) == 1;
            genres.RemoveAt(0);
            return InsertGenres(bookID, genres) || success ;
        }
    }
}
