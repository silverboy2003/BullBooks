using System;
using System.Data;
using DAL;

namespace BL
{
    public class User
    {
        protected int id;
        protected string username;
        protected DateTime date;
        protected int gender; //1- male, 2- female, 3- other
        protected string email;
        protected string banner;//banner picture directory
        protected string profile;//profile picture directory

        //there is no need for isAdmin and Is Publisher because there are special classes for these
         
        public User(DataRow userDataRow)
        {
            id = (int)userDataRow["userID"];
            username = (string)userDataRow["username"];
            date = (DateTime)userDataRow["creationDate"];
            gender = (int)userDataRow["gender"];
            email = (string)userDataRow["email"];
            banner = (string)userDataRow["bannerPic"];
            profile = (string)userDataRow["profilePic"];
        }
        public static User Login(string username, string password)
        {
            DataRow result = UserHelper.DoLogin(username, password);
            if (result == null)
                return null;
            User user = CreateUserByDataRow(result);
            return user;
        } 
        public static User GetUser(int id)//return a type corresponding the the user type in the database. returns null if no user exists with such an id
        {
            DataRow user = DAL.UserHelper.GetUser(id);
            return CreateUserByDataRow(user);
        }
        public static User CreateUserByDataRow(DataRow user)
        {
            if (user == null)
                return null;
            bool isAdmin = (bool)user["isAdmin"];
            bool isPublisher = (bool)user["isPublisher"];
            if (isAdmin && isPublisher)
                return new AdminPublisher(user);
            if (isAdmin)
                return new Admin(user);
            return new Publisher(user);
        }
        protected virtual DataTable GetAssociatedBooks()
        {
            return DAL.UserHelper.GetReadBooksList(id);
        }
    }
}
