<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="EditProfilePage.aspx.cs" Inherits="BullBooks.EditProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Outer" class="OuterBox">
        <div>
            <asp:FileUpload runat="server" ID="BannerFile" ForeColor="White"/>
            <asp:Button runat="server" ID="UploadBanner" OnClick="UploadBanner_Click" Text="Upload"/>
            <asp:Image runat="server" ID="BannerImage" CssClass="UserBanner"/>
        </div>

    <div class="UserContainer">
         <div class="UinfoContainer">
             <asp:FileUpload runat="server" ID="ProfileFile" ForeColor="White" />
             <asp:Button runat="server" ID="UploadProfile" OnClick="UploadProfile_Click" Text="Upload"/>
             <asp:Image runat="server" ID="ProfileImage" />
             <div class="EditAlias">
                 <asp:TextBox TextMode="SingleLine" runat="server" ID="AliasEdit"></asp:TextBox>
                 <label for="AliasEdit">'s profile</label>
             </div>
         </div>

    </div>
        </div>
</asp:Content>
