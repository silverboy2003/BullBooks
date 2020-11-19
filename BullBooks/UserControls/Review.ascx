    <%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Review.ascx.cs" Inherits="BullBooks.Comment" %>
<div class="Review">
    <asp:Image runat="server" ID="ReviewerPic"/>
    <asp:Label runat="server" ID="ReviewerName"></asp:Label>
    <ASS:Rating runat="server" ID="Stars"/>
    <asp:Label runat="server" ID="ReviewContent"></asp:Label>
</div>