<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThreadPreview.ascx.cs" Inherits="BullBooks.UserControls.ThreadPreview" %>
<div class="ThreadPreview">

    <asp:Button runat="server" CssClass="InvisibleButton" OnClick="RedirectSearch"/>

    <div class="PreviewInfo">
        <div class="ThreadPreviewTitle">
            <asp:Label runat="server" ID="ThreadTitle" CssClass="PreviewTitle"></asp:Label>
        </div>

        <div class="ThreadPreviewInfo">
            <asp:Label runat="server" ID="BookName" CssClass="PreviewName"></asp:Label>
            <asp:Label runat="server" ID="PostingDate" CssClass="PreviewDate"></asp:Label>
        </div>
    </div>

</div>