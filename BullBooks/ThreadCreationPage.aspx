<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadCreationPage.aspx.cs" Inherits="BullBooks.ThreadCreationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="OuterBox">
            
        <div class="ThreadCreationBar">
            <select class="js-example-basic-single" id="SelectBook" name="SelectBook" runat="server" multiple="false">
            </select>
            <asp:ImageButton ImageUrl="../ControlImages/send.png" CssClass="SendButton" runat="server" ID="ThreadSubmitButton" OnClick="ThreadSubmitButton_Click" OnClientClick="return ConfirmThread()" />
        </div>
        <div class="ThreadCKeditor">
            <asp:TextBox EnableViewState="true" runat="server" ID="ThreadTitle" TextMode="SingleLine" MaxLength="50" placeholder="Thread Title"></asp:TextBox>
            <asp:TextBox runat="server" ID="ThreadEditor" TextMode="MultiLine"></asp:TextBox>
            <asp:HiddenField runat="server" EnableViewState="true" ID="HiddenEditor"/>
        </div>

    </div>
    
    <%--<link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js" defer></script>--%>
    <script src="select2/js//select2.min.js" defer></script>
    <link href="select2/css/select2.min.css" rel="stylesheet" />
    <script src="jquery-3.6.0.min.js"></script>
    <%--<script src="select2Replace.js"></script>--%>
    <script type='text/javascript' src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
            CKEDITOR.replace(<%= ThreadEditor.ClientID %>,
                {
                    width: '100%'
                });
        $(document).ready(function () {
            $(".js-example-basic-single").select2();
        });

        function ConfirmThread() {
            var text = CKEDITOR.instances.ContentPlaceHolder1_ThreadEditor.document.getBody().getText();
            var title = ContentPlaceHolder1_ThreadTitle.value;
            text = text.trim();
            if (!text || !title) {
                window.alert('Please provide content');
                return false;
            }
            if (window.confirm("Select OK if you you would like to submit this Thread.")) {
                var temp = (CKEDITOR.instances.ContentPlaceHolder1_ThreadEditor.getData()).replace(/&nbsp;/g, ' ');
                document.getElementById('ContentPlaceHolder1_HiddenEditor').value = temp;
            }
            else
                return false;
        }
    </script>
</asp:Content>
