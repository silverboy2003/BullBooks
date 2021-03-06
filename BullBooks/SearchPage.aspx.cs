﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using System.Collections.Specialized;
using System.Security.Policy;
using System.Security.Principal;

namespace BullBooks
{
    public partial class SearchResults : System.Web.UI.Page
    {
        protected string name;
        protected string genreIDs;
        private void Page_PreInit(object sender, EventArgs e)
        {
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_Radio();
            }
            User currentUser = (User)Session["User"];
            if (currentUser != null && (currentUser.IsAdmin || currentUser.IsPublisher || currentUser.IsAuthor))
                AddBookRedirect.Visible = true;
        }
        protected string CreateQuery()//generates query string
        {
            string genres = CreateGenreString();
            string searchText = TextIn.Text;
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            if(!string.IsNullOrEmpty(searchText))
            queryString.Add("input", searchText);
            queryString.Add("genres", genres);
            return queryString.ToString();
        }
        protected string CreateGenreString() //generates string made up of 0's and 1's each representing a genre. 1 is true 0 is false
        {
            string gString = "";
            foreach(ListItem li in Genres.Items)
            {
                if (li.Selected)
                    gString += '1';
                else
                    gString += '0';
            }
            return gString;
        }
        protected void RedirectSearch(object sender, EventArgs e)
        {
            string query = CreateQuery();
            string current = Request.Url.GetLeftPart(UriPartial.Path);
            string newString = current + '?' + query;
            Response.Redirect(newString);
        }
        protected void Load_Radio()
        {
            Dictionary<int, string> genres= (Dictionary<int, string>)Application["Genres"];
            foreach(KeyValuePair<int, string> entry in genres)
            {
                ListItem genre = new ListItem();
                genre.Text = entry.Value;
                genre.Value = entry.Key.ToString();
                ((CheckBoxList)Genres).Items.Add(genre);
            }
        }

        protected void Blist_Load(object sender, EventArgs e)
        {
            name = Request.QueryString["input"];
            genreIDs = Request.QueryString["genres"];
            Blist.LoadBooks(name, Genre.ConvertStringToList(genreIDs));
        }

        protected void AddBookRedirectClick(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("BookCreationPage.aspx");
        }
    }
}