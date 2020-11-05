<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookPreview.ascx.cs" Inherits="BullBooks.Controllers.BookPreview" %>
<div class="PreviewContainer">
    
<div Class="PreviewClass">
        <asp:Button ID="CoverImage" runat="server" CssClass="CoverImage" />
</div>
    <div Class="DetailClass">
        <asp:Label CssClass="Detail" ID="BookAuthor" runat="server"></asp:Label>
        <asp:Label CssClass="Detail" ID="BookName" runat="server"></asp:Label>
    </div>

</div>