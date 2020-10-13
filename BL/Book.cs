using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DAL;
using System.Reflection;

namespace BL
{
    public class Book
    {
        public int ID
        {
            get; set;
        }
        public string BookName
        {
            get; set;
        }
        public string AuthorName
        {
            get; set;
        }
        public string PublisherName
        {
            get;set;
        }
        public int PublisherID
        {
            get; set;
        }
        public int AuthorID
        {
            get; set;
        }
        public string BookSynopsis
        {
            get; set;
        }
        public string BookCover
        {
            get; set;
        }
        public double BookRating
        {
            get; set;
        }
        public int NumReviews
        {
            get; set;
        }
        public int NumPages
        {
            get; set;
        }
        public int NumChapters
        {
            get; set;
        }
        public DateTime BookRelease
        {
            get; set;
        }
        public string ISBN
        {
            get; set;
        }

        public Book(int id, string name, string author, string cover)
        {
            this.ID = id;
            this.BookName = name;
            this.AuthorName = author;
            this.BookCover = cover;
        }
        public Book(DataRow book)
        {
            this.ID = (int)book["bookID"];
            this.BookName = (string)book["bookName"];
            this.AuthorID = (int)book["authorID"];
            this.PublisherID = (int)book["publisherID"];
            this.BookSynopsis = (string)book["bookSynopsis"];
            this.BookCover = (string)book["bookCoverPic"];
            this.NumPages = (int)book["numPages"];
                this.NumChapters = (int)book["numChapters"];
            this.BookRelease = (DateTime)book["bookReleaseDate"];
            this.ISBN = (string)book["ISBN"];
            this.AuthorName = (string)book["authorName"];
            this.PublisherName = (string)book["publisherName"];
            this.BookRating = (double)book["Rating"];
            this.NumReviews = (int)book["NumReviews"]; 
        }
        public static List<Book> GetBooksBySearch(string bookName, List<int> genres)//function that gets a search term and a list of genres that were picked and returns a list of books containing their id, name, author and cover photo path
        {
            if(bookName != null)
                bookName = '%' + bookName + '%';
            DataTable books = DAL.BookHelper.GetBookSearch(bookName, genres);//Books.BookID, bookName, bookAuthor, BookCoverPic
            List<Book> previews = new List<Book>();
            if (books != null) 
            foreach(DataRow book in books.Rows)
            {
                int id = (int)book["bookID"];
                string name = (string)book["bookName"];
                string author = (string)book["bookAuthor"];
                string cover = (string)book["bookCoverPic"];
                Book temp = new Book(id, name, author, cover);
                previews.Add(temp);
            }
            return previews;
        }
        public static List<Book> LoadBooks()
        {
            DataTable books = BookHelper.GetAllBooks();
            List<Book> bookList = null;
            if (books != null)
            {
                bookList = new List<Book>();
                foreach(DataRow bookRow in books.Rows)
                {
                    Book book = new Book(bookRow); //save these in Application
                    bookList.Add(book);
                }
            }
            return bookList;
        }
    }
}
