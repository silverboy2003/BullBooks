<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BullBooks.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:TextBox ID="TextIn" runat="server" CssClass="TextInClass" EnableViewState="true"></asp:TextBox>
        <asp:CheckBoxList ID="Genres" runat="server" EnableViewState="true">

        </asp:CheckBoxList>
        <asp:Button ID="Submit" runat="server" Text="Button" OnClick="SendSearch"/>
    </div>
    <ASS:BookList ID="Blist" runat="server"/>
</asp:Content>
