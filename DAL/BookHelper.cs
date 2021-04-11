using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class BookHelper
    {
        public static DataTable GetAllBooks()
        {
            string sql = "SELECT Books.* FROM(SELECT AuthorT.*, PublisherT.publisherName FROM(SELECT Books.*, alias AS authorName FROM Books INNER JOIN Users ON Books.authorID = Users.userID)  AS AuthorT INNER JOIN(SELECT Books.bookID, alias AS publisherName FROM Books INNER JOIN Users ON Books.publisherID = Users.userID)  AS PublisherT ON AuthorT.bookID = PublisherT.bookID)  AS Books;";
            DataTable Books = DBHelper.GetDataTable(sql);
            return Books;
        }//Gets a datatable of all books from database
        public static DataTable GetBookGenres(int bookID)
        {
            string sql = $"SELECT * FROM (Genres INNER JOIN GenresToBooks ON GenresToBooks.genreID = Genres.genreID) WHERE bookID = {bookID}";
            DataTable genres = DBHelper.GetDataTable(sql);
            return genres;
        }//gets all genres corresponding to book id
        public static int InsertBook(List<object> inputs, int author, int publisher, int numPages, int numChapters, DateTime releaseDate, string isbn, string bookCover)
        {
            string sql = $@"INSERT INTO Books (bookName, authorID, publisherID, bookSynopsis, bookCoverPic, numPages, numChapters, bookReleaseDate, ISBN) VALUES (@Text1, {author}, {publisher}, @Text2, '{bookCover}', {numPages}, {numChapters}, '{releaseDate}', {isbn})";
            int newID = DBHelper.InsertWithAutoNumKey(sql, inputs);
            return newID;
        }//inserts new book into databse
        public static bool InsertGenres(int bookID, List<int> genres)
        {
            if (genres.Count == 0)
                return false;
            string sql = $"INSERT INTO GenresToBooks (bookID, genreID) VALUES ({bookID}, {genres[0]})";
            bool success = DBHelper.WriteData(sql) == 1;
            genres.RemoveAt(0);
            return InsertGenres(bookID, genres) || success ;
        }//recursively inserts into genrestobooks all genres and returns if at least one insert was succesfull
        public static bool UpdateBook(List<object> inputs, int author, int publisher, int numPages, int numChapters, DateTime releaseDate, string bookCover, int bookID)
        {
            string sql = $@"UPDATE Books SET bookName = @Text1, authorID = {author}, publisherID = {publisher}, bookSynopsis = @Text2, bookCoverPic = '{bookCover}', numPages = {numPages}, numChapters = {numChapters}, bookReleaseDate = '{releaseDate}' WHERE bookID = {bookID}";
            bool success = DBHelper.WriteData(sql, inputs) == 1;
            return success;
        }//updates book details
        public static bool DeleteBook(int id)
        {
            string sql = $"DELETE FROM Books WHERE bookID = {id}";
            bool success = DBHelper.WriteData(sql) == 1;
            return success;
        }//deletes entry from database
    }
}
