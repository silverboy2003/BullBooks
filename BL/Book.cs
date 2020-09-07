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
        public string BookAuthor
        {
            get; set;
        }
        public int PublisherID
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
        public int BookRating
        {
            get; set;
        }
        public int Numviews
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
            this.BookAuthor = author;
            this.BookCover = cover;
        }
        public static List<Book> GetBooksBySearch(string bookName, List<int> genres)//function that gets a search term and a list of genres that were picked and returns a list of books containing their id, name, author and cover photo path
        {
            DataTable books = DAL.BookHelper.GetBookSearch(bookName, genres);//Books.BookID, bookName, bookAuthor, BookCoverPic
            List<Book> previews = new List<Book>();
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
    }
}
