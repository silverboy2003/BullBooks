<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BullBooks.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Outer" class="OuterBox">
        <asp:ImageButton runat="server" ID="EditProfileButton" Visible="false" OnClick="EditProfileButton_Click" ImageUrl="../ControlImages/pencil.png"/>
        <asp:Image runat="server" ID="UserBanner" CssClass="UserBanner"></asp:Image>

    <div class="UserContainer">
         <div class="UinfoContainer">
             <asp:Image runat="server" ID="ProfileImage" CssClass="UserProfile"/>
             <asp:Label runat="server" ID="UsernameLabel" CssClass="Header"></asp:Label>
             <asp:Label runat="server" ID="BooksAmount"></asp:Label>
         </div>

        <div class="ReadBooks">
            <label for="Blist">Read Books</label>
            <ASS:BookList ID="Blist" runat="server" OnLoad="Blist_Load" EnableViewState="true"/>
        </div>
    </div>
        </div>
</asp:Content>
