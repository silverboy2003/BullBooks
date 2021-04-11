using System;
using System.Data;
using DAL;
using System.Reflection;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace BL
{
    public class User
    {
        const int Unregistered = -1;

        private int id;
        private string username;
        private DateTime birthDate;
        private DateTime creationDate;
        private int gender; //1- male, 2- female, 3- other
        private string email;
        private string banner;//banner picture directory
        private string profile;//profile picture directory
        private bool isAdmin;
        private bool isPublisher;
        private bool isAuthor;
        private string alias;
        private string password;
        //Getters and Setters
        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public int Gender { get => gender; set => gender = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Password { get => password; set => password = Encrypt(value); }//encrypts on set
        public string Banner { get => banner; set => banner = value; }
        public string Profile { get => profile; set => profile = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public string Alias { get => alias; set => alias = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public bool IsPublisher { get => isPublisher; set => isPublisher = value; }
        public bool IsAuthor { get => isAuthor; set => isAuthor = value; }
        //constructors
        public User(DataRow user)
        {
            id = (int)user["userID"];
            email = (string)user["email"];
            username = (string)user["username"];
            gender = (int)user["gender"];
            birthDate = (DateTime)user["birthDate"];
            banner = (string)user["bannerPic"];
            profile = (string)user["profilePic"];
            isAdmin = (bool)user["isAdmin"];
            isPublisher = (bool)user["isPublisher"];
            isAuthor = (bool)user["isAuthor"];
            creationDate = (DateTime)user["creationDate"];
            alias = (string)user["alias"];
            password = (string)user["password"];
        }//user constructor accepting datarow as input
        public User(string email, string username, int gender, DateTime birthDate, string password, DateTime creationDate, string alias)
        {
            this.email = email;
            this.username = username;
            this.gender = gender;
            this.birthDate = birthDate;
            this.creationDate = creationDate;
            this.alias = alias;

            //encrypt password
            this.password = BCrypt.Net.BCrypt.HashPassword(password);

            id = Unregistered;
            isAdmin = false;
            isAuthor = false;
            isPublisher = false;
            banner = "UserImages/Banners/default.png";
            profile = "UserImages/Profile/default.png";
        }//constructor
        //assisting functions
        public static string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }//encrypts user password using bcrypt library
        public static User Login(string username, string password)
         {
            DataRow result = UserHelper.DoLogin(username, password);
            if (result == null)
                return null;
            User user = new User(result);
            return user;
        } //compares username and password input to known user with same username, login
        public int Register()
        {
            if (this.id != Unregistered)
                return -1;
            List<object> inputs = new List<object>();
            inputs.Add(this.email);
            inputs.Add(this.username);
            inputs.Add(this.gender);
            inputs.Add(this.birthDate.ToString());
            inputs.Add(this.password);
            inputs.Add(this.creationDate.ToString());
            inputs.Add(this.alias);
            int newID = UserHelper.DoRegister(inputs);
            this.id = newID;
            return newID;
        }//Inserts new user
        public static bool IsAvailable(string input, string type)
        {
            return UserHelper.ChcekAvailability(input, type);
        }//returns whether username is occupied
        public static Dictionary<int, User> GetAllUsers()
        {
            DataTable UsersTable = DALHelper.GetTable("Users");
            if (UsersTable == null)
                return null;
            Dictionary<int, User> users = new Dictionary<int, User>();
            foreach(DataRow dr in UsersTable.Rows)
            {
                User newUser = new User(dr);
                users.Add(newUser.id, newUser);
            }
            return users;
        }//returns a list of all users
        public static bool DeleteUser(int id)
        {
            return UserHelper.DeleteUser(id);
        }//deletes user from database
        private List<object> CreateList()
        {
            List<object> user = new List<object>();

            user.Add(this.alias);
            user.Add(this.email);
            user.Add(this.username);
            user.Add(this.password);
            user.Add(this.banner);
            user.Add(this.profile);
            return user;
        }//returns a list containing all user details except for id
        public bool UpdateUser()
        {
            return UserHelper.UpdateUser(CreateList(), this.id, Gender, BirthDate, CreationDate, IsAdmin, IsPublisher, IsAuthor);
        }//updates user details in database
    }
}
