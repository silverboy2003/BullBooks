<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BullBooks.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="SearchPage">
    <div class="Search">
    <asp:TextBox ID="TextIn" runat="server" CssClass="TextInClass" EnableViewState="true"></asp:TextBox>
        <asp:Button ID="Submit" runat="server" Text="Search" OnClick="SendSearch"/>
        <asp:CheckBoxList ID="Genres" runat="server" EnableViewState="true" CssClass="Radio">

        </asp:CheckBoxList>
    </div>
    <ASS:BookList ID="Blist" runat="server" OnLoad="Blist_Load"/>
    </div>
</asp:Content>
