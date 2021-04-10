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
        }//returns all thread comments 
        public static int SendComment(List<object> inputs)
        {
            string sql = $"INSERT INTO ThreadComments (threadID, commentText, commentAuthorID, commentDate) VALUES ('{inputs[0]}', @Text, '{inputs[2]}', '{inputs[4]}')";
            int newID = DBHelper.InsertWithAutoNumKey(sql, (string)inputs[1]);
            if ((int)inputs[3] == 0) //meaning it's directed to itself
                inputs[3] = newID;
            string updateSql = $"UPDATE ThreadComments SET replyTo = {inputs[3]} WHERE commentID = {newID}";
            DBHelper.WriteData(updateSql);
            return newID;
        }//inserts new comment to database
    }
}
