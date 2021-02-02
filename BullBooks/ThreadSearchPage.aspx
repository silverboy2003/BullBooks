<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadSearchPage.aspx.cs" Inherits="BullBooks.ThreadSearchPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Container" runat="server" CssClass="OuterBox">
        <div class="ThreadSearchContainer">
            <asp:TextBox runat="server" ID="ThreadSearchBox" CssClass="ThreadSearchBox" placeholder="Search for a thread..."></asp:TextBox>
            <asp:TextBox runat="server" ID="BookThreadSearch" CssClass="BookThreadSearch" placeholder="Book name..."></asp:TextBox>
            <asp:Button runat="server" ID="SearchSubmit" CssClass="ThreadSearchSubmit" OnClick="RedirectSearch" Text="Search"/>
        </div>

        <asp:Panel runat="server" CssClass="ThreadResultsContainer" ID="PreviewsContainer"></asp:Panel>

    </asp:Panel>
</asp:Content>
