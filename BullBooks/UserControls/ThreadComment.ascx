﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreadComment.ascx.cs" Inherits="BullBooks.UserControls.ThreadComment" %>
<asp:Panel runat="server" CssClass="Comment" ID="CommentContainer">
   
    <div class="CommentMargin">
        <div class="UserInfo">
        
        <asp:Image runat="server" ID="CommenterPic"/>
        <asp:Label runat="server" ID="CommenterName"></asp:Label>
        <asp:Label runat="server" ID="CommentDate"></asp:Label>

    </div>

    <asp:Panel runat="server" cssClass="CommentContent" ID="CommentContentContainer">

        <div class="CommentTextContainer">
            <asp:Label runat="server" ID="CommentContent" CssClass="CommenteText"></asp:Label>
        </div>

    </asp:Panel>

    </div>
    
    <asp:Panel runat="server" ID="Replies" CssClass="repliesContainer">

    </asp:Panel>
</asp:Panel>