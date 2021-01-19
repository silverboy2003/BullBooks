<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadSearchPage.aspx.cs" Inherits="BullBooks.ThreadSearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Container" runat="server" CssClass="OuterBox">

        <asp:Panel runat="server" CssClass="ThreadResultsContainer" ID="PreviewsContainer"></asp:Panel>

    </asp:Panel>
</asp:Content>
