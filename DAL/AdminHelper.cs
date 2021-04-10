using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class AdminHelper
    {
        public static bool DeleteComment(int CommentID)
        {
            string sql = $"DELETE FROM ThreadComments WHERE commentID = {CommentID}";
            int success = DBHelper.WriteData(sql);
            return success == 1;
        }//deletes comment
        public static bool RemoveThread(int id)
        {
            string sql = $"DELETE FROM Threads WHERE threadID = {id}";
            bool success = DBHelper.WriteData(sql) == 1;
            return success;
        }//deletes thread
    }
}
