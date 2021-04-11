<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BullBooks.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Outer" class="OuterBox">
        <div class="UserpageBanner">
            <asp:ImageButton runat="server" ID="EditProfileButton" Visible="false" OnClick="EditProfileButton_Click" ImageUrl="../ControlImages/pencil.png"/>
            <asp:Image runat="server" ID="UserBanner" CssClass="UserBanner"></asp:Image>
        </div>

    <div class="UserContainer">
         <div class="UinfoContainer">
             <asp:Image runat="server" ID="ProfileImage" CssClass="UserProfile"/>
             <asp:Label runat="server" ID="UsernameLabel" CssClass="Header"></asp:Label>
         </div>

        <div class="ReadBooks">
            <label runat="server" id="BlistLabel" for="Blist" visible="false">Read Books</label>
            <ASS:BookList ID="Blist" runat="server" EnableViewState="true" Visible="false"/>
            <label runat="server" id="PublishedLabel" for="PublishedBooks" visible="false">Published Books</label>
            <ASS:BookList ID="PublishedBooks" runat="server" EnableViewState="true" Visible="false" />
            <label runat="server" id="WrittenLabel" for="WrittenBooks" visible="false">Written Books</label>
            <ASS:BookList ID="WrittenBooks" runat="server" EnableViewState="true" Visible="false" />
        </div>
    </div>
        </div>
</asp:Content>
