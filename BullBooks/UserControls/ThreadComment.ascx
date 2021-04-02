<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreadComment.ascx.cs" Inherits="BullBooks.UserControls.ThreadComment" %>
<asp:Panel runat="server" CssClass="Comment" ID="CommentContainer">
   
    <div class="CommentMargin">
        <div class="UserInfo">
        
        <asp:Image runat="server" ID="CommenterPic"/>
        <asp:Label runat="server" ID="CommenterName"></asp:Label>
        <asp:Label runat="server" ID="CommentDate"></asp:Label>

    </div>

    <asp:Panel runat="server" cssClass="CommentContent" ID="CommentContentContainer">

        <div class="CommentTextContainer" runat="server" id="CommentTextContainer">
            <%--<asp:Label runat="server" ID="CommentContent" CssClass="CommenteText"></asp:Label>--%>
        </div>
        <div class="ReplyButtons">
        <asp:ImageButton OnClick="Unnamed_Click" runat="server" ID="RemoveCommentButton" Visible="false" ImageUrl="../ControlImages/trash.png"/>
        <asp:ImageButton  OnClientClick="return ClickReplyButton(this.nextSibling)" ID="ReplyButton"  OnClick="ReplyButtonPress" runat="server" ImageUrl="../ControlImages/reply.png"/>
        <asp:ImageButton OnClick="CancelButtonPress" runat="server" ID="CancelButton" ImageUrl="../ControlImages/x.png" Visible="false"/>
        </div>
    </asp:Panel>

    </div>
    <asp:Panel runat="server" ID="EditorContainer" CssClass="replyEditorContainer">
        <asp:HiddenField runat="server" ID="HiddenReply" EnableViewState="true"/>
        <asp:TextBox TextMode="MultiLine" Visible="false" runat="server" ID="ReplyEditor" CssClass="EditorButton"></asp:TextBox>
        <asp:LinkButton OnClientClick="ConfirmReply(this.previousElementSibling, ((this.previousElementSibling).previousElementSibling).previousElementSibling)" OnClick="SendReply" ID="SendReplyButton" CssClass="SendReplyButton" runat="server" Visible="false" Text="Send Reply"></asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" ID="Replies" CssClass="repliesContainer">

    </asp:Panel>
</asp:Panel>