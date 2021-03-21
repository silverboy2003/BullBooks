<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="BullBooks.BookPage" %>
<%@ Register TagPrefix="ASS" TagName="Rating" Src="~/UserControls/Rating.ascx" %>
<%@ Register TagPrefix="ASS" TagName="RatingSelector" Src="~/UserControls/RatingSelector.ascx" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type='text/javascript' src="ckeditor/ckeditor.js"></script> <%--Rich text editor--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="BookPanel" runat="server" CssClass="InformationPanel">
        <asp:Panel runat="server" ID="InformationPanel" CssClass="InformationContainer">

            <div class="CoverAndScore">
                <div class="BookImageContainer">
                    <asp:Image runat="server" ID="BookImage" CssClass="BookImage"/>
                </div>
                <ASS:Rating runat="server" ID="StarsRating"/>
            </div>

            <div class="BookInfoText" style="display:flex; flex-direction:column;">

                
                <div><label for="BookName">Title: </label> <asp:Label ID="BookName" runat="server"></asp:Label></div>

                <div><label for="AuthorName">Author: </label> <asp:Label ID="AuthorName" runat="server"></asp:Label></div>

                <div><label for="PublisherName">Publisher: </label> <asp:Label ID="PublisherName" runat="server"></asp:Label></div>

                <div><label for="NumPages">No. of pages: </label> <asp:Label ID="NumPages" runat="server"></asp:Label></div>

                <div><label for="NumChapters">No. of chapters: </label> <asp:Label ID="NumChapters" runat="server"></asp:Label></div>

                <div><label for="ReleaseDate">Release Date: </label> <asp:Label ID="ReleaseDate" runat="server"></asp:Label></div>

                <div><label for="ISBN">ISBN: </label> <asp:Label ID="ISBN" runat="server"></asp:Label></div>

                <div><label for="Genres">Genres: </label> <asp:Label ID="Genres" runat="server"></asp:Label></div>

                <div><label for="Synopsis">Synopsis:</label><asp:Label ID="Synopsis" runat="server"></asp:Label></div>
            </div>
            
            <asp:Panel runat="server" ID="EditorContainer" CssClass="editorContainer">
                <asp:HiddenField ID="HiddenEditor" EnableViewState="true" runat="server"/>
                <asp:TextBox  Visible="false" runat="server" ID="Editor" CssClass="EditorButton" onclick="ReplaceCKeditor()"></asp:TextBox>
                <div class="SendDiv">
                    <ASS:RatingSelector Visible="false" runat="server" ID="RatingSelect" />
                    <asp:ImageButton OnClick="SendReview" OnClientClick="return ConfirmReview()" Visible="false" runat="server" ID="ReviewSubmit" ImageUrl="../ControlImages/send.png" CssClass="ReviewButton"/>
                </div>
            </asp:Panel>          
                    <script type="text/javascript">
                        function ReplaceCKeditor() {
                            CKEDITOR.replace(<%= Editor.ClientID %>,
                                {
                                    width: '100%'

                                });
                        }
                    </script>
            <script type="text/javascript">
                function SaveReview() {
                    var temp = (CKEDITOR.instances.ContentPlaceHolder1_Editor.getData()).replace(/&nbsp;/g, ' ');
                    document.getElementById('ContentPlaceHolder1_HiddenEditor').value = temp;
                }
                function ConfirmReview() {
                    if (window.confirm("Select OK if you you would like to submit this review.")) {
                        SaveReview();
                        document.getElementById('ContentPlaceHolder1_ReviewSubmit').click;
                    }
                    else
                        return false;
                }
            </script>

            <asp:Panel  runat="server" ID="Reviews_Container" CssClass="ReviewsContainer"></asp:Panel>
        </asp:Panel>
        
    </asp:Panel>
</asp:Content>
