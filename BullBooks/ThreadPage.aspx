    <%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="ThreadPage.aspx.cs" Inherits="BullBooks.ThreadPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Thread"> 

        <div class="ContentDiv">
            <div class="HeaderContainer">
                <asp:Label runat="server" ID="ThreadHeader" CssClass="ThreadHeader"></asp:Label>
                <div class="PostInformation">
                    <asp:Label runat="server" ID="PostingTime" ></asp:Label>
                    <asp:Label runat="server" ID="AuthorAlias" ></asp:Label>
                </div>
            </div>
        <asp:Label runat="server" ID="ThreadText" CssClass="ThreadText"></asp:Label>
        </div>
        <asp:Panel ID="CommentContainer" CssClass="ThreadCommentsComtainer" runat="server">
        
        </asp:Panel>
    </div>
    
    
</asp:Content>
