using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class DALHelper
    {
        public static DataTable GetTable(string table)
        {
            string sql = $"SELECT * FROM {table}";
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }//Returns a datatable returning all values of table 'table'
        public static bool UpdateDatabaseGenresTable(Dictionary<int, string> genres)
        {
            if (genres == null || genres.Count == 0)
                return false;
            string sql = $"INSERT INTO Genres (genreID, genre) VALUES({genres.Keys.ToList()[0]}, '{genres.Values.ToList()[0]}')";
            bool success = DBHelper.WriteData(sql) != -1;
            genres.Remove(genres.Keys.ToList()[0]);
            return UpdateDatabaseGenresTable(genres) || success;
        }//recursively inserts all genres from ws database in order to stay updated on all genres of books
    }
}
