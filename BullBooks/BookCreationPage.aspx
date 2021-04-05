<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="BookCreationPage.aspx.cs" Inherits="BullBooks.BookCreationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="OuterBox">
        <asp:Panel runat="server" ID="InformationPanel" CssClass="InformationContainer BookCreationContainer">

            <div class="CoverAndScore">
                <div class="BookImageContainer">
                    <asp:Image runat="server" ID="BookImage" CssClass="BookImage"/>
                </div>
            </div>

            <div class="BookInfoCreation">

                
                <div><label for="BookName">Title: </label> <asp:TextBox TextMode="SingleLine" ID="BookName" runat="server"></asp:TextBox></div>

                <div><label for="AuthorName">Author: </label> <asp:TextBox TextMode="SingleLine" ID="AuthorName" runat="server"></asp:TextBox></div>

                <div><label for="PublisherName">Publisher: </label> <asp:TextBox TextMode="SingleLine" ID="PublisherName" runat="server"></asp:TextBox></div>

                <div><label for="NumPages">No. of pages: </label> <asp:TextBox TextMode="SingleLine" ID="NumPages" runat="server"></asp:TextBox></div>

                <div><label for="NumChapters">No. of chapters: </label> <asp:TextBox TextMode="SingleLine" ID="NumChapters" runat="server"></asp:TextBox></div>

                <div><label for="ReleaseDate">Release Date: </label> <asp:TextBox TextMode="SingleLine" ID="ReleaseDate" runat="server"></asp:TextBox></div>

                <div><label for="ISBN">ISBN: </label> <asp:TextBox TextMode="SingleLine" ID="ISBN" runat="server"></asp:TextBox></div>

                 <div><label for="Genres">Genres:</label><select class="js-example-basic-single" runat="server" id="Genres" multiple="true"></select></div>   

                <div><label for="Synopsis">Synopsis:</label><asp:TextBox runat="server" TextMode="MultiLine" ID="Synopsis"></asp:TextBox></div>

            </div>
                     
        </asp:Panel>
        
    </div>
    <script src="select2/js//select2.min.js" defer></script>
    <link href="select2/css/select2.min.css" rel="stylesheet" />
    <script src="jquery-3.6.0.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".js-example-basic-single").select2();
        });
    </script>
</asp:Content>
