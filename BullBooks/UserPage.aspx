<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="BullBooks.UserPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Outer" class="OuterBox">
        <asp:Panel runat="server" ID="UserBanner" CssClass="UserBanner"></asp:Panel>

    <div class="UserContainer">
        <asp:HyperLink ID="EditProfile" runat="server" CssClass="Hyperlink EditProfile">Edit Profile</asp:HyperLink>
         <div class="UinfoContainer"></div>

        <div class="ReadBooks">
            <ASS:BookList ID="Blist" runat="server" OnLoad="Blist_Load" EnableViewState="true"/>
        </div>
    </div>
        </div>
</asp:Content>
