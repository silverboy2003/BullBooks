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
        ////////////////////////////////////Getters
        public static Dictionary<int, string> GetAllGenresDictionary()
        {
            DataTable genres = DALHelper.GetTable("Genres");
            Dictionary<int, string> genresDic = new Dictionary<int, string>();
            if (genres != null)
                foreach (DataRow item in genres.Rows)
                {
                    int id = (int)item["genreID"];
                    string genre = (string)item["genre"];
                    genresDic.Add(id, genre);
                }
            return genresDic;
        }//returns a dictionary corresponding to all genres in the database
        public static List<int> ConvertStringToList(string genresBool)
        {
            if (string.IsNullOrEmpty(genresBool))
                return null;
            List<int> gList = new List<int>();
            for(int i = 0; i<genresBool.Length; i++)
            {
                if (genresBool[i] == '1')
                    gList.Add(i + 1);
            }
            if (gList.Count < 1)
                return null;
            return gList;
        }//gets a string of 0s and 1s and turns them into a list of genres that are selected
        //////////////////////////////////// Insert
        public static bool UpdateGenreTable(Dictionary<int, string> allGenres)
        {
            return DALHelper.UpdateDatabaseGenresTable(allGenres);
        }//inserts the genres loaded on application start from the web service
    }
}
