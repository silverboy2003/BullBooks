<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="BookCreationPage.aspx.cs" Inherits="BullBooks.BookCreationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="OuterBox">
        <asp:Panel runat="server" ID="InformationPanel" CssClass="InformationContainer BookCreationContainer">

            <div class="CoverAndScore">
                <div>
                    <asp:FileUpload runat="server" ID="BookCoverUpload" CssClass="CoverUpload" />
                    <asp:Button ID="UploadFile" runat="server" OnClick="UploadFile_Click" Text="Upload" />
                </div> 
                <div runat="server" id="BookUploadContainer" class="BookUploadContainer">
                </div>
            </div>

            <div class="BookInfoCreation">

                
                <div><label for="BookName">Title: </label> <asp:TextBox TextMode="SingleLine" ID="BookName" runat="server"></asp:TextBox></div>

                <div><label for="AuthorName">Author: </label> <select class="js-example-basic-single" runat="server" id="AuthorName"></select></div>

                <div><label for="PublisherName">Publisher: </label> <select class="js-example-basic-single" runat="server" id="PublisherName"></select></div>

                <div><label for="NumPages">No. of pages: </label> <asp:TextBox TextMode="SingleLine" ID="NumPages" runat="server"></asp:TextBox></div>

                <div><label for="NumChapters">No. of chapters: </label> <asp:TextBox TextMode="SingleLine" ID="NumChapters" runat="server"></asp:TextBox></div>

                <div><label for="ReleaseDate">Release Date: </label> <asp:TextBox TextMode="SingleLine" ID="ReleaseDate" runat="server"></asp:TextBox></div>

                <div><label for="ISBN">ISBN: </label> <asp:TextBox TextMode="SingleLine" ID="ISBN" runat="server"></asp:TextBox></div>

                 <div><label for="Genres">Genres:</label><select class="js-example-basic-single" runat="server" id="Genres" multiple="true"></select></div>   

                <div><label for="Synopsis">Synopsis:</label><div class="SynopsisTextbox" id="Synopsis" contenteditable="true"></div></div>
                
                <asp:ImageButton runat="server" ID="SendBook" ImageUrl="../ControlImages/send.png" OnClick="SendBook_Click" CssClass="SiteButton"/>
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
        function FileUploadTrigger() {
            $("#BookCoverUpload").click();
        }
    </script>
</asp:Content>
