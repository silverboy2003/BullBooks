<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="BullBooks.SearchResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:TextBox ID="TextIn" runat="server" CssClass="TextInClass"></asp:TextBox>
        <asp:CheckBoxList ID="Genres" runat="server">

        </asp:CheckBoxList>
    </div>
    <ASS:BookList ID="Blist" runat="server"/>
</asp:Content>
