<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="BullBooks.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView OnRowCreated="RemoveColumns" CssClass="UserTable" runat="server" ID="UserTable" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>
