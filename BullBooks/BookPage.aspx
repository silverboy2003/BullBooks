<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="BullBooks.BookPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="BookPanel" runat="server" CssClass="InformationPanel">
        <asp:Panel runat="server" ID="InformationPanel" CssClass="InformationContainer">
            <div class="BookInfoText" style="display:flex; flex-direction:column;">

                <asp:Label ID="BookName" runat="server"></asp:Label>
                <asp:Label ID="AuthorName" runat="server"></asp:Label>
                <asp:Label ID="PublisherName" runat="server"></asp:Label>
                <asp:Label ID="NumPages" runat="server"></asp:Label>
                <asp:Label ID="NumChapters" runat="server"></asp:Label>
                <asp:Label ID="ReleaseDate" runat="server"></asp:Label>
                <asp:Label ID="ISBN" runat="server"></asp:Label>
                <asp:Label ID="Genres" runat="server"></asp:Label>

                <asp:Label ID="Synopsis" runat="server"></asp:Label>
            </div>

            <div class="CoverAndScore">
                <asp:Image runat="server" ID="BookImage" CssClass="BookImage"/>

                <asp:Panel CssClass="Rating" runat="server" ID="StarPanel">

                </asp:Panel>

            </div>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
