using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Reflection;
using System.Data;

namespace BL
{
    public class Genre
    {
        private int genreID;
        private string genreName;

        public Genre(int genreID, string gennreName)
        {
            this.genreID = genreID;
            this.genreName = gennreName;
        }

        public int GenreID { get => genreID; set => genreID = value; }
        public string GenreName { get => genreName; set => genreName = value; }

        public static List<Genre> GetAllGenres()
        {
            DataTable genres = DALHelper.GetTable("Genre");
            List<Genre> gList = new List<Genre>();
            foreach(DataRow item in genres.Rows)
            {
                int id = (int)item["genreID"];
                string genre = (string)item["genre"];
                Genre temp = new Genre(id, genre);
                gList.Add(temp);
            }
            return gList;
        }
        public static List<int> ConvertStringToList(string genresBool)
        {
            if (string.IsNullOrEmpty(genresBool))
                return null;
            List<int> gList = new List<int>();
            for(int i = 0; i<genresBool.Length; i++)
            {
                if (genresBool[i] == 1)
                    gList.Add(i + 1);
            }
            return gList;
        }
    }
}
