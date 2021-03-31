    <%@ Page MaintainScrollPositionOnPostback="true" Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadPage.aspx.cs" Inherits="BullBooks.ThreadPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type='text/javascript' src="ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Thread"> 

        <div class="ContentDiv">
            <div class="HeaderContainer">
                <asp:Label runat="server" ID="ThreadHeader" CssClass="ThreadHeader"></asp:Label>
                <div class="PostInformation">
                    <asp:Label runat="server" ID="PostingTime" ></asp:Label>
                    <asp:Label runat="server" ID="AuthorAlias" ></asp:Label>
                </div>
            </div>
        <asp:Label runat="server" ID="ThreadText" CssClass="ThreadText"></asp:Label>
        </div>
        <asp:Panel runat="server" ID="EditorContainer" CssClass="editorContainer">
                <asp:HiddenField ID="HiddenEditor" EnableViewState="true" runat="server"/>
                <asp:TextBox  Visible="false" runat="server" ID="Editor" CssClass="EditorButton CommentEditorButton" onclick="ReplaceCKeditor()"></asp:TextBox>
                    <div class="SendDiv">
                <asp:ImageButton OnClick="SendComment" OnClientClick="return ConfirmComment()" Visible="false" runat="server" ID="CommentSubmit" ImageUrl="../ControlImages/send.png" CssClass="SendButton"/>
                </div>
            </asp:Panel>          
                    <script type="text/javascript">
                        function ClickReplyButton(cancelButton) {
                            if (cancelButton.nextElementSibling == null)
                                return true
                            return false;
                        }
                        function ReplaceReplyEditor(id) {
                            CKEDITOR.addCss('.cke_editable { background-color: black; color: white }');
                            CKEDITOR.replace(id,
                                {
                                    width: '100%'

                                });
                        }
                        function ReplaceCKeditor() {
                            CKEDITOR.replace(<%= Editor.ClientID %>,
                                {
                                    width: '100%'

                                });
                        }

                        function SaveComment() {
                            var temp = (CKEDITOR.instances.ContentPlaceHolder1_Editor.getData()).replace(/&nbsp;/g, ' ');
                            document.getElementById('ContentPlaceHolder1_HiddenEditor').value = temp;
                        }
                        function ConfirmComment() {
                            var text = CKEDITOR.instances.ContentPlaceHolder1_Editor.document.getBody().getText();
                            text = text.trim();
                            if (!text)
                            {
                                window.alert('Please provide content');
                                return false;
                            }
                            if (window.confirm("Select OK if you you would like to submit this comment.")) {
                                SaveComment();
                                document.getElementById('ContentPlaceHolder1_CommentSubmit').click;
                            }
                            else
                                return false;
                        }
                        function ConfirmReply(editor, hidden) {
                            var id = editor.id;
                            var editorID = id.substring(4);
                            var instance = CKEDITOR.instances[editorID];
                            var text = instance.getData().replace(/&nbsp;/g, ' ');
                            hidden.value = text;
                        }
                    </script>
        <asp:Panel ID="CommentContainer" CssClass="ThreadCommentsContainer" runat="server">

            

        </asp:Panel>
    </div>
    
    
</asp:Content>
