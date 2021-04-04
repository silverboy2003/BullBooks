<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadCreationPage.aspx.cs" Inherits="BullBooks.ThreadCreationPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="OuterBox">
            
        <div class="ThreadCreationBar">
            <select class="js-example-basic-single" id="SelectBook" name="SelectBook" runat="server" multiple="false">
                <option value="AL">alamaba</option>
                <option value="AdfL">alagsdfgmaba</option>
                <option value="AdsgdsL">alamsgfdgfdsaba</option>
                <option value="AsdgL">alagadsgsmaba</option>
            </select>
            <asp:ImageButton ImageUrl="../ControlImages/send.png" CssClass="SendButton" runat="server" ID="ThreadSubmitButton" OnClick="ThreadSubmitButton_Click" OnClientClick="return ConfirmClick()" />
        </div>

        <div class="ThreadCKeditor">
            <asp:TextBox runat="server" ID="ThreadEditor" TextMode="MultiLine"></asp:TextBox>
        </div>

    </div>
    
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
    <script src="jquery-3.6.0.min.js"></script>
    <%--<script src="select2Replace.js"></script>--%>
    <script type='text/javascript' src="ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
            CKEDITOR.replace(<%= ThreadEditor.ClientID %>,
                {
                    width: '100%'
                });
        $(document).ready(function () {
            $("#SelectBook").select2({
                placeholder: "Select a Subject",
                allowClear: true
            });
        });
        
    </script>
</asp:Content>
