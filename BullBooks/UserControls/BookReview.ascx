<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookReview.ascx.cs" Inherits="BullBooks.BookReview" %>
<asp:Panel runat="server" CssClass="Review" ID="ReviewContainer">
    <div class="UserInfo">
        
        <asp:Image runat="server" ID="ReviewerPic"/>
        <asp:Label runat="server" ID="ReviewerName"></asp:Label>
        <asp:Label runat="server" ID="ReviewDate"></asp:Label>

    </div>

    <asp:Panel runat="server" cssClass="ReviewContent" ID="ReviewContentContainer">

        <div class="ReviewTextContainer">
            <asp:Label runat="server" ID="ReviewContent" CssClass="ReviewText"></asp:Label>
        </div>

    </asp:Panel>

</asp:Panel>