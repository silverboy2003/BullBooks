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

                
                <div><label for="BookName">Title: </label> <asp:TextBox TextMode="SingleLine" ID="BookName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredTitle" ControlToValidate="BookName" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>

                <div><label for="AuthorName">Author: </label> <select class="js-example-basic-single" runat="server" id="AuthorName"></select>
                <asp:RequiredFieldValidator runat="server" ID="RequiredAuthor" ControlToValidate="AuthorName" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>

                </div>
                
                <div><label for="PublisherName">Publisher: </label> <select class="js-example-basic-single" runat="server" id="PublisherName"></select>
                <asp:RequiredFieldValidator runat="server" ID="RequiredPublisher" ControlToValidate="PublisherName" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>
                </div>

                <div><label for="NumPages">No. of pages: </label> <asp:TextBox TextMode="SingleLine" ID="NumPages" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredPages" ControlToValidate="NumPages" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexPages" runat="server" ControlToValidate="NumPages" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="Invalid Number" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>

                </div>

                <div><label for="NumChapters">No. of chapters: </label> <asp:TextBox TextMode="SingleLine" ID="NumChapters" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredChapters" ControlToValidate="NumChapters" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexChapters" runat="server" ControlToValidate="NumChapters" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="Invalid Number" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>

                </div>

                <div><label for="ReleaseDate">Release Date: </label><input runat="server" type="date" id="ReleaseDate" />
                <asp:RequiredFieldValidator runat="server" ID="RequiredRelease" ControlToValidate="ReleaseDate" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>

                </div>

                <div><label for="ISBN">ISBN: </label> <asp:TextBox TextMode="SingleLine" ID="ISBN" runat="server"></asp:TextBox><asp:Button Text="Fill information by ISBN" runat="server" ID="ISBNService" OnClick="ISBNService_Click"/>
                <asp:RequiredFieldValidator runat="server" ID="RequiredISBN" ControlToValidate="ISBN" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexISBN" runat="server" ControlToValidate="ISBN" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="Invalid Number" ValidationExpression="^[0-9]+$"></asp:RegularExpressionValidator>
                <asp:CustomValidator runat="server" ID="CustomISBN" ControlToValidate="ISBN" ValidationGroup="CreateBook" cssclass="BookValidator" ErrorMessage="ISBN taken" OnServerValidate="CustomISBN_ServerValidate"></asp:CustomValidator>

                </div>

                <div><label for="Genres">Genres:</label><select class="js-example-basic-single" runat="server" id="Genres" multiple="true"></select>
                <asp:RequiredFieldValidator runat="server" ID="RequiredGenres" ControlToValidate="Genres" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator>

                </div>   

                <div><label for="Synopsis">Synopsis:</label><asp:TextBox runat="server" ID="Synopsis" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="RequiredSynopsis" ControlToValidate="Synopsis" cssclass="BookValidator" ValidationGroup="CreateBook" ErrorMessage="*"></asp:RequiredFieldValidator></div>


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
