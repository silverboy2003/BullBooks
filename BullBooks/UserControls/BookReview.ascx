<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookReview.ascx.cs" Inherits="BullBooks.BookReview" %>
<asp:panel runat="server" cssClass="Review" ID="ReviewContainer">
    <asp:Image runat="server" ID="ReviewerPic"/>
    <asp:Label runat="server" ID="ReviewerName"></asp:Label>
    <asp:Label runat="server" ID="ReviewContent"></asp:Label>
    <asp:Label runat="server" ID="ReviewDate"></asp:Label>
</asp:panel>