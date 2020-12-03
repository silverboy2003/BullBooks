<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="BullBooks.BookPage" %>



    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type='text/javascript' src="ckeditor/ckeditor.js"></script> <%--Rich text editor--%>
     <script type='text/javascript'>
         function ReplaceCKeditor(clientID) {
             CKEDITOR.replace(clientID,
                 {
                     width: '100%'
                 });
         }
     </script>
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
                <%--<asp:TextBox ID="editor1" runat="server" TextMode="MultiLine" CssClass="textEditor"></asp:TextBox>
                 <script>
                         CKEDITOR.replace('<%=editor1.ClientID%>',
                         {
                             width: '100%'
                         });
                     
                 </script>--%>
            </asp:Panel>          

            <asp:Panel runat="server" ID="Reviews_Container" CssClass="ReviewsContainer"></asp:Panel>
            
        </asp:Panel>
        
    </asp:Panel>
</asp:Content>
