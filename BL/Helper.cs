using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL
{
    public class Helper
    {
        public static void SetDBConnString(string conn)
        {
            DAL.DBHelper.SetConnString(conn);
        }
    }
}
