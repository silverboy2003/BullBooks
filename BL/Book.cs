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
        private List<int> genres;
        public List<int> Genres
        {

            get
            {
                if(genres == null)
                    genres = GetGenres();
                return genres;
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

        private List<Review> reviews;
        
        private List<int> GetGenres()
        {
            DataTable genres = BookHelper.GetBookGenres(this.ID);
            List<int> genresList = new List<int>();
            foreach (DataRow genre in genres.Rows)
            {
                int genreID = (int)genre["Genres.genreID"];
                genresList.Add(genreID);
            }
            return genresList;
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
        }
        public static List<Book> GetBooksBySearch(string bookName, List<int> genres, Dictionary<int, Book> allBooks)//function that gets a search term and a list of genres that were picked and returns a list of books containing their id, name, author and cover photo path
        {
            List<Book> books = new List<Book>(allBooks.Values);

            if(bookName != null)
                    books.RemoveAll(i => !(i.BookName.ToLower()).StartsWith(bookName.ToLower()));
            if (genres != null)
                books.RemoveAll(book => book.Genres != null && genres.Any(genre => !book.Genres.Contains(genre)));
            return books;
        }
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
                    bookList.Add(book.ID, book);
                }
            }
            return bookList;
        }
        private void CalculateReviews()//only call while setting review list
        {
            List<Review> reviews = this.reviews;
            double totalScore = 0;
            foreach(Review bookReview in reviews)
            {
                totalScore += bookReview.Rating;
            }
            double calculatedScore = totalScore / NumReviews;
            BookRating = calculatedScore;
        }
        public static List<Book> GetAssociatedBooks(int userID, Dictionary<int, Book> allBooks)
        {
            List<Book> books = new List<Book>(allBooks.Values.ToList());
            books.RemoveAll(book => book.reviews != null && !book.reviews.Exists(review => review.ReviewerID == userID));
            return books;
        }
    }
}
