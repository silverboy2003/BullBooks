using System;
using System.Data;

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
        public static bool Login(string email, string password)
        {
            string hashed = BCrypt.Net.BCrypt.HashPassword(password);
            DAL.UserHelper.Login(email, hashed);

        }
        public static User GetUser(int id)//return a type corresponding the the user type in the database. returns null if no user exists with such an id
        {
            DataRow user = DAL.UserHelper.GetUser(id);
            if(user != null)
            {
                if ((bool)user["isAdmin"])
                    return new Admin(user);
                if ((bool)user["isPublisher"])
                    return new Publisher(user);
                return new User(user);
            }
            return null;
        }
        protected virtual DataTable GetAssociatedBooks()
        {
            return DAL.UserHelper.GetReadBooksList(id);
        }
    }
}
