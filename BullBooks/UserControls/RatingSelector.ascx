<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RatingSelector.ascx.cs" Inherits="BullBooks.RatingSelector" %>
<asp:Panel CssClass="Rating" runat="server" ID="StarPanel">
    <asp:Button OnClick="SendEvent" runat="server" ID="Star5" CommandArgument="5" style="color: gray;" Text="★"></asp:Button>
    <asp:Button OnClick="SendEvent" runat="server" ID="Star4" CommandArgument="4" style="color: gray;" Text="★"></asp:Button>
    <asp:Button OnClick="SendEvent" runat="server" ID="Star3" CommandArgument="3" style="color: gray;" Text="★"></asp:Button>
    <asp:Button OnClick="SendEvent" runat="server" ID="Star2" CommandArgument="2" style="color: gray;" Text="★"></asp:Button>
    <asp:Button OnClick="SendEvent" runat="server" ID="Star1" CommandArgument="1" style="color: gray;" Text="★"></asp:Button>
</asp:Panel>