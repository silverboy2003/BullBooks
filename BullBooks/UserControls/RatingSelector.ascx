<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatingSelector.ascx.cs" Inherits="BullBooks.RatingSelector" %>

<asp:Panel CssClass="Rating" runat="server" ID="StarPanel">
    <asp:RadioButton runat="server" AccessKey="5" Text="★" GroupName="Stars"/>
    <asp:RadioButton runat="server" AccessKey="4" Text="★" GroupName="Stars"/>
    <asp:RadioButton runat="server" AccessKey="3" Text="★" GroupName="Stars"/>
    <asp:RadioButton runat="server" AccessKey="2" Text="★" GroupName="Stars"/>
    <asp:RadioButton runat="server" AccessKey="1" Text="★" GroupName="Stars"/>
</asp:Panel>