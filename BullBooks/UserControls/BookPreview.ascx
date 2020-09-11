<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookPreview.ascx.cs" Inherits="BullBooks.Controllers.BookPreview" %>
<div Class="PreviewClass">
    <asp:Panel ID="ImagePanel" runat="server">
        <asp:Button ID="CoverImage" runat="server" CssClass="CoverImage" />
    </asp:Panel>
    <div Class="DetailClass">
        <asp:Label CssClass="Detail" ID="BookAuthor" runat="server"></asp:Label>
        <asp:Label CssClass="Detail" ID="BookName" runat="server"></asp:Label>
    </div>
</div>