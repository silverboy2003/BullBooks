<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookPreview.ascx.cs" Inherits="BullBooks.Controllers.BookPreview" %>
<asp:Panel ID="OuterPanel" runat="server">
    <asp:Panel ID="ImagePanel" runat="server">
        <asp:ImageButton ID="Image" runat="server" />
    </asp:Panel>
    <asp:Panel ID="DetailPanel" runat="server">
        <asp:TextBox ID="BookAuthor" runat="server"></asp:TextBox>
        <asp:TextBox ID="BookName" runat="server"></asp:TextBox>
    </asp:Panel>
</asp:Panel>
