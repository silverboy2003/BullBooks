﻿using System;
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
            string genresSQL = @"SELECT Books.BookID, bookName, bookAuthor, BookCoverPic FROM";
            if (genres == null)
                genresSQL += " Books";
            else
                genresSQL += "(Books INNER JOIN GenreToBook ON Books.bookID = GenreToBook.bookID)";

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
                genresSQL += $") GROUP BY Books.bookID, bookName, bookAuthor, BookCoverPic HAVING COUNT(Books.bookID) ={genres.Count}";
            }
            else
                genresSQL += " GROUP BY Books.bookID, bookName, bookAuthor, BookCoverPic";
            DataTable books;
            if (bookName != null)
                books = DBHelper.GetDataTable(genresSQL, bookName);//Books.BookID, bookName, bookAuthor, BookCoverPic
            else
                books = DBHelper.GetDataTable(genresSQL);
            return books;
        }
    }
}
