﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Rating.ascx.cs" Inherits="BullBooks.Rating" %>
<asp:Panel CssClass="Rating" runat="server" ID="StarPanel">
    <asp:Label runat="server" ID="Star1" style="background: gray; -webkit-background-clip: text;" Text="★"></asp:Label>
    <asp:Label runat="server" ID="Star2" style="background: gray; -webkit-background-clip: text;" Text="★"></asp:Label>
    <asp:Label runat="server" ID="Star3" style="background: gray; -webkit-background-clip: text;" Text="★"></asp:Label>
    <asp:Label runat="server" ID="Star4" style="background: gray; -webkit-background-clip: text;" Text="★"></asp:Label>
    <asp:Label runat="server" ID="Star5" style="background: gray; -webkit-background-clip: text;" Text="★"></asp:Label>
</asp:Panel>