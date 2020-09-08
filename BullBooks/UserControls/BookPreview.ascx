<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookPreview.ascx.cs" Inherits="BullBooks.Controllers.BookPreview" %>
<asp:Panel ID="OuterPanel" runat="server" CssClass="PreviewClass">
    <asp:Panel ID="ImagePanel" runat="server">
        <asp:Image CssClass="CoverImage" ID="CoverImage" runat="server" ImageUrl="D:\Users\ASUS\Desktop\Final\BullBooks\CoverPics\00.png"/>
    </asp:Panel>
    <asp:Panel ID="DetailPanel" runat="server" CssClass="DetailClass">
        <asp:Label CssClass="Detail" ID="BookAuthor" runat="server"></asp:Label>
        <asp:Label CssClass="Detail" ID="BookName" runat="server"></asp:Label>
    </asp:Panel>
</asp:Panel>
