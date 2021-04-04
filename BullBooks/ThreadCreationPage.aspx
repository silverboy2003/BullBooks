<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadCreationPage.aspx.cs" Inherits="BullBooks.ThreadCreationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ThreadCKeditor">
        <asp:TextBox runat="server" ID="ThreadEditor" TextMode="MultiLine"></asp:TextBox>
    </div>

    <script type='text/javascript' src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
            CKEDITOR.replace(<%= ThreadEditor.ClientID %>,
                {
                    width: '100%'
                });
    </script>
</asp:Content>
