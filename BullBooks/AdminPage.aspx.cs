﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Text.RegularExpressions;
namespace BullBooks
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //if (Session["User"] == null || !((User)Session["User"]).IsAdmin)
            //    Response.Redirect("mainpage.aspx");
            if (!Page.IsPostBack)
            {
                Dictionary<int, User>  allUsers = (Dictionary<int, User>)(Application["Users"]);
                UserTable.DataSource = allUsers.Values;
                UserTable.DataBind();
            }
        }

        protected void RemoveColumns(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;

        }
        private void Bind()
        {
            UserTable.DataSource = ((Dictionary<int, User>)(Application["Users"])).Values;
            UserTable.DataBind();
        }

        protected void DeleteUser(object sender, GridViewDeleteEventArgs e)
        {
            int userID = int.Parse(e.Values["Id"].ToString());
            ((Dictionary<int, User>)(Application["Users"])).Remove(userID);
            BL.User.DeleteUser(userID);
            Bind();
        }

        protected void EditUser(object sender, GridViewEditEventArgs e)//enables edit mode
        {
            
            int index = e.NewEditIndex;
            UserTable.EditIndex = index;
            Bind();
            //Dictionary<string, string> user = new Dictionary<string, string>();
            ////UserTable.Rows[index].Cells
            //for(int i = 0; i< UserTable.Rows[index].Cells.Count; i++)
            //{
            //    string content = UserTable.Rows[index].Cells[i].Text;
            //    string header = UserTable.Columns[i].HeaderText;
            //    user.Add(header, content);
            //}

        }

        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UserTable.EditIndex = -1;
            Bind();
        }

        protected void RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool parseSuccess= true;

            int userID = -1;
            parseSuccess = parseSuccess && int.TryParse(e.NewValues["Id"].ToString(), out userID);

            string email = e.NewValues["Email"].ToString();
            Regex emailCheck = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}");
            parseSuccess = parseSuccess && emailCheck.IsMatch(email);

            string username = e.NewValues["Username"].ToString();
            Regex usernameCheck = new Regex(@"^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$");
            parseSuccess = parseSuccess && usernameCheck.IsMatch(username);

            int gender = -1;
            parseSuccess = parseSuccess && int.TryParse(e.NewValues["Gender"].ToString(), out gender) && gender <2 && gender > -1 ;

            DateTime birthDate = new DateTime();
            parseSuccess = parseSuccess && DateTime.TryParse(e.NewValues["BirthDate"].ToString(), out birthDate);

            DateTime CreationDate = new DateTime();
            parseSuccess = parseSuccess && DateTime.TryParse(e.NewValues["CreationDate"].ToString(), out CreationDate);

            string alias = e.NewValues["Alias"].ToString();
            Regex aliasCheck = new Regex(@"^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$");
            aliasCheck.IsMatch(alias);

            bool isAdmin = (bool)e.NewValues["IsAdmin"];
            bool isPublisher = (bool)e.NewValues["IsPublisher"];
            bool isAuthor = (bool)e.NewValues["IsAuthor"];

            if (parseSuccess)
            {
                User user = (User)((Dictionary<int, User>)(Application["Users"]))[userID];
                user.Email = email;
                user.Username = username;
                user.Gender = gender;
                user.BirthDate = birthDate;
                user.CreationDate = CreationDate;
                user.Alias = alias;
                user.IsAdmin = isAdmin;
                user.IsPublisher = isPublisher;
                user.IsAuthor = isAuthor;

                bool success = user.UpdateUser();
            }
            Bind();
        }

    }
}