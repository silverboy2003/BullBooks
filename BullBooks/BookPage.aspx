<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="BullBooks.BookPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="BookPanel" runat="server" CssClass="InformationPanel">
        <asp:Panel runat="server" ID="InformationPanel" CssClass="InformationContainer">
            <div class="BookInfoText">
                <asp:TextBox ID="BookName" runat="server"></asp:TextBox>
                <asp:TextBox ID="AuthorName" runat="server"></asp:TextBox>
                <asp:TextBox ID="PublisherName" runat="server"></asp:TextBox>
                <asp:TextBox ID="NumPages" runat="server"></asp:TextBox>
                <asp:TextBox ID="NumChapters" runat="server"></asp:TextBox>
                <asp:TextBox ID="ReleaseDate" runat="server"></asp:TextBox>
                <asp:TextBox ID="ISBN" runat="server"></asp:TextBox>
                <asp:TextBox ID="Genres" runat="server"></asp:TextBox>

                <asp:TextBox ID="Synopsis" runat="server"></asp:TextBox>
            </div>

            <div class="CoverAndScore">
                <asp:Image runat="server" ID="BookImage" CssClass="BookImage"/>

                <asp:Panel CssClass="Rating" runat="server" ID="StarPanel">

                </asp:Panel>

            </div>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
