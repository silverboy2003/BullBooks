﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DAL
{
    public class UserHelper
    {
        public static DataRow DoLogin(string username, string password)
        {
            string sql = "SELECT * FROM Users WHERE UCASE(username) = UCASE(@Text)";
            DataTable results = DBHelper.GetDataTable(sql, username);
            if (results == null)
                return null;
            DataRow user = results.Rows[0];
            string hashed = (string)(user["password"]);
            if (BCrypt.Net.BCrypt.Verify(password, hashed))
                return user;
            return null;
        }//compares password in database to password sent and logs and returns user
        public static int DoRegister<T>(List<T> inputs)
        {
            string sql = "INSERT INTO Users ( email, username, gender, birthDate, [password], creationDate, alias) VALUES(@Text1, @Text2, @Text3, @Text4, @Text5, @Text6, @Text7)";
            int newID = DBHelper.InsertWithAutoNumKey(sql, inputs);
            return newID;
        }//inserts new user to database
        public static bool ChcekAvailability(string input, string type)
        {
            string sql = $"SELECT {type} FROM Users WHERE {type} = @Text";
            DataTable result = DBHelper.GetDataTable(sql, input);
            return result == null;
        }//chceks if field is already taken in database (field is parameter 'type')
        public static bool DeleteUser(int id)
        {
            string sql = $"DELETE FROM Users WHERE userID = {id}";

            return DBHelper.WriteData(sql) == 1;
        }//deletes user from database
        public static bool UpdateUser(List<object> user, int id, int gender, DateTime birthDate, DateTime creationDate, bool isAdmin, bool isPublisher, bool isAuthor)
        {
            //string sqdl = $"UPDATE Users SET email = @Text1, username = @Text2, gender = {user[2]}, birthDate = '{user[3]}', [password] = @Text5, bannerPic = @Text6, profilePic = @Text7, creationDate = '{user[7]}', alias = @Text9, isAdmin = {user[9]}, isPublisher = {user[10]}, isAuthor = {user[11]} WHERE userID = {id}";
            string sql = $"UPDATE Users SET alias = @Text1, email = @Text2, username = @Text3, gender = {gender}, birthDate = '{birthDate}', [password] = @Text4, bannerPic = @Text5, profilePic = @Text6, creationDate = '{creationDate}',isAdmin = {isAdmin}, isPublisher = {isPublisher}, isAuthor = {isAuthor} WHERE userID = {id}";
            //string sql = $"UPDATE Users SET email = 'meow', username = 'meow', gender = 0, birthDate = @Text4, [password] = 'meow', bannerPic = 'meow', profilePic = 'meow', creationDate = @Text8, alias = 'meow', isAdmin = True, isPublisher = True, isAuthor = True WHERE userID = 88";

            return DBHelper.WriteData(sql, user) == 1;
            //return DBHelper.WriteData(sql) == 1;
        }//updates user details
    }
}
