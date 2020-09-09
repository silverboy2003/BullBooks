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
        }
    }
}
