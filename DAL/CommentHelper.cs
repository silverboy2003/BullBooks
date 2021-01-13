using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class CommentHelper 
    {       

        public static DataTable GetAllComments()
        {
            string sql = $"SELECT  ThreadComments.*, Users.alias AS commentAuthorName FROM Users INNER JOIN ThreadComments ON Users.userID = ThreadComments.commentAuthorID ORDER BY ThreadComments.threadID ASC, commentDate ASC";
            DataTable threadComments = DBHelper.GetDataTable(sql);
            return threadComments;
        }
    }
}
