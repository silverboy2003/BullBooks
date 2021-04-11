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
        private List<int> genres;

        private List<Review> reviews;
        ////////////////////////////////////Getters and Setters
        public int Id
        {
            get; set;
        }
        public string BookName
        {
            get; set;
        }//num of pages in book
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
        public List<int> Genres
        {

            get
            {
                if(genres == null)
                    genres = GetGenres();
                return genres;
            }
            set
            {
                genres = value;
            }
        }

        public List<Review> Reviews
        {
            get => reviews;
            set
            {
                reviews = value;
                NumReviews = reviews.Count;
                CalculateReviews();
            }
        }
        
        private List<int> GetGenres()
        {
            DataTable genres = BookHelper.GetBookGenres(this.Id);
            List<int> genresList = new List<int>();
            foreach (DataRow genre in genres.Rows)
            {
                int genreID = (int)genre["Genres.genreID"];
                genresList.Add(genreID);
            }
            return genresList;
        }//returns all genres corresponding to this book
        public static List<Book> GetBooksBySearch(string bookName, List<int> genres, Dictionary<int, Book> allBooks)//function that gets a search term and a list of genres and returns a list of books containing their id, name, author and cover photo path
        {
            List<Book> books = new List<Book>(allBooks.Values);

            if(bookName != null)
                    books.RemoveAll(i => !(i.BookName.ToLower()).StartsWith(bookName.ToLower()));
            if (genres != null)
                books.RemoveAll(book => book.Genres != null && genres.Any(genre => !book.Genres.Contains(genre)));
            return books;
        }
        public static List<Book> GetReadBooks(int userID, Dictionary<int, Book> allBooks)
        {
            List<Book> books = new List<Book>(allBooks.Values.ToList());
            books.RemoveAll(book => book.reviews != null && !book.reviews.Exists(review => review.ReviewerID == userID));
            return books;
        }//gets all books containing a review belonging to the id provided
        public static List<Book> GetPublishedBook(int userID, Dictionary<int, Book> allBooks)
        {
            List<Book> books = new List<Book>(allBooks.Values.ToList());
            books.RemoveAll(book => book.PublisherID != userID);
            return books;
        }//gets all books with a publisher id identical to one provided
        public static List<Book> GetWrittenBooks(int userID, Dictionary<int, Book> allBooks)//gets all books with an author id identical to one provided
        {
            List<Book> books = new List<Book>(allBooks.Values.ToList());
            books.RemoveAll(book => book.AuthorID != userID);
            return books;
        }
        public void CalculateReviews()//calculated book rating score based on reviews list
        {
            List<Review> reviews = this.reviews;
            double totalScore = 0;
            foreach (Review bookReview in reviews)
            {
                totalScore += bookReview.Rating;
            }
            double calculatedScore = totalScore / reviews.Count;
            BookRating = calculatedScore;
        }
        //////////////////////////////////// Constructors
        public Book(DataRow book)
        {
            this.Id = (int)book["bookID"];
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
        }//constructor with a datarow as a parameter
        public Book(int iD, string bookName, string authorName, string publisherName, int publisherID, int authorID, string bookSynopsis,
        string bookCover, double bookRating, int numReviews, int numPages, int numChapters, DateTime bookRelease, string iSBN, List<int> genres, List<Review> reviews)
        {
            Id = iD;
            BookName = bookName;
            AuthorName = authorName;
            PublisherName = publisherName;
            PublisherID = publisherID;
            AuthorID = authorID;
            BookSynopsis = bookSynopsis;
            BookRating = bookRating;
            NumReviews = numReviews;
            NumPages = numPages;
            NumChapters = numChapters;
            BookRelease = bookRelease;
            ISBN = iSBN;
            this.genres = genres;
            this.reviews = reviews;
            if (string.IsNullOrEmpty(bookCover))
                bookCover = "CoverPics/00.png";
            BookCover = bookCover;
        }//a constuctor with all of Book's properties as parameters
        //////////////////////////////////// Read Data
        public static Dictionary<int, Book> LoadBooks()
        {
            DataTable books = BookHelper.GetAllBooks();
            Dictionary<int, Book> bookList = null;
            if (books != null)
            {
                bookList = new Dictionary<int, Book>();
                foreach (DataRow bookRow in books.Rows)
                {
                    Book book = new Book(bookRow); //save these in Application
                    book.GetGenres();
                    bookList.Add(book.Id, book);
                }
            }
            return bookList;
        }//returns all books in database
        //////////////////////////////////// Insert
        public int CommitBook()
        {
            List<object> inputs = new List<object>();
            inputs.Add(BookName);
            inputs.Add(BookSynopsis);
            int newID = DAL.BookHelper.InsertBook(inputs, AuthorID, PublisherID, NumPages, NumChapters, BookRelease, ISBN, BookCover);
            this.Id = newID;
            return newID;
        }//inserts a new book into the table
        public bool UpdateBook()
        {
            List<object> inputs = new List<object>();
            inputs.Add(BookName);
            inputs.Add(BookSynopsis);
            bool success = DAL.BookHelper.UpdateBook(inputs, AuthorID, PublisherID, NumPages, NumChapters, BookRelease, BookCover, Id);
            return success;
        }//Update all of the book's fields
        public bool CommitGenres()
        {
            List<int> bookGenres = new List<int>(this.genres); //so i dont remove from original list
            bool success = BookHelper.InsertGenres(Id, bookGenres);
            return success;
        }//sends the list of genres the book contains and inserts them into GenresToBooks table
        //////////////////////////////////// Delete
        public bool DeleteSelf()
        {
            return BookHelper.DeleteBook(Id);
        }//removes book from database
    }
}
