using System;
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

            if (Session["User"] == null || !((User)Session["User"]).IsAdmin)
                Response.Redirect("mainpage.aspx");
            if (!Page.IsPostBack)
            {
                Dictionary<int, User>  allUsers = (Dictionary<int, User>)(Application["Users"]);
                UserTable.DataSource = allUsers.Values;
                UserTable.DataBind();
            }
        }

        protected void RemoveColumns(object sender, GridViewRowEventArgs e)
        {
            //e.Row.Cells[1].Visible = false; //id
            e.Row.Cells[5].Visible = false; //birth
            e.Row.Cells[9].Visible = false; //creation
            //e.Row.Cells[8].Visible = false;
            //e.Row.Cells[6] password
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

            User user = (User)((Dictionary<int, User>)(Application["Users"]))[userID];

            string password = e.NewValues["Password"].ToString();
            if (!password.Equals(user.Password))
                password = BL.User.Encrypt(password);

            string email = e.NewValues["Email"].ToString();
            Regex emailCheck = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}");
            parseSuccess = parseSuccess && emailCheck.IsMatch(email);

            string username = e.NewValues["Username"].ToString();
            Regex usernameCheck = new Regex(@"^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$");
            parseSuccess = parseSuccess && usernameCheck.IsMatch(username);

            int gender = -1;
            parseSuccess = parseSuccess && int.TryParse(e.NewValues["Gender"].ToString(), out gender) && gender <2 && gender > -1 ;

            string alias = e.NewValues["Alias"].ToString();
            Regex aliasCheck = new Regex(@"^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$");
            aliasCheck.IsMatch(alias);

            string banner = e.NewValues["Banner"].ToString();

            string profile = e.NewValues["Profile"].ToString();

            bool isAdmin = (bool)e.NewValues["IsAdmin"];
            bool isPublisher = (bool)e.NewValues["IsPublisher"];
            bool isAuthor = (bool)e.NewValues["IsAuthor"];

            if (parseSuccess)
            {
                if (!password.Equals(user.Password))
                    user.Password = password;
                user.Banner = banner;
                user.Profile = profile;
                user.Email = email;
                user.Username = username;
                user.Gender = gender;
                user.Alias = alias;
                user.IsAdmin = isAdmin;
                user.IsPublisher = isPublisher;
                user.IsAuthor = isAuthor;

                bool success = user.UpdateUser();
            }
            Bind();
        }

        protected void SearchSubmit_Click(object sender, ImageClickEventArgs e)
        {
            bool isAdmin = false;
            bool isPublisher = false;
            bool isAuthor = false;
            if (UserType.Items[0].Selected)
                isAuthor = true;
            if (UserType.Items[1].Selected)
                isAdmin = true;
            if (UserType.Items[2].Selected)
                isPublisher = true;

            string searchQuery = SearchBar.Text;
            string searchBy = SearchBy.Value;

            Dictionary<int, User> allUsers = new Dictionary<int, User>((Dictionary<int, User>)Application["Users"]);
            List<User> usersList = allUsers.Values.ToList();
            if (searchBy == "Id")
            {
                int id = 0;
                int.TryParse(searchQuery, out id);
                if (allUsers.ContainsKey(id))
                {
                    usersList.RemoveAll(user => user.Id != id);
                }
                UserTable.DataSource = usersList;
            }
            else
            {
                usersList.RemoveAll(user => (user.GetType().GetProperty(searchBy).GetValue(user)).ToString().StartsWith(searchQuery));
                UserTable.DataSource = usersList;
            }
            UserTable.DataBind();
        }
    }
}