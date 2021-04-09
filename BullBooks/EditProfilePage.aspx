<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="EditProfilePage.aspx.cs" Inherits="BullBooks.EditProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content  ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Outer" class="OuterBox">


        <div class="BannerUploadContainer">

        <asp:ImageButton runat="server" ID="UpdateProfileButton" ImageUrl="../ControlImages/send.png" OnClick="UpdateProfileButton_Click"/>


            <asp:FileUpload runat="server" ID="BannerFile" ForeColor="White"/>
            <asp:Button runat="server" ID="UploadBanner" OnClick="UploadBanner_Click" Text="Upload"/>
            <asp:Image runat="server" ID="BannerImage" CssClass="UserBanner"/>
        </div>

    <div class="UserContainer">
        
         <div class="UinfoContainer">
             <div class="UploadProfileDiv">
                <asp:FileUpload runat="server" ID="ProfileFile" ForeColor="White" />
                <asp:Button runat="server" ID="UploadProfile" OnClick="UploadProfile_Click" Text="Upload"/>
             </div>

             <asp:Image CssClass="UserProfile" runat="server" ID="ProfileImage" />
             <asp:RegularExpressionValidator ID="RegexAlias" runat="server" ControlToValidate="AliasEdit" CssClass="Validator" ValidationGroup="Alias" ErrorMessage="Alias invalid" ValidationExpression="^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$"></asp:RegularExpressionValidator>
             <div class="EditAlias">
                 <asp:TextBox TextMode="SingleLine" runat="server" ID="AliasEdit"></asp:TextBox>
                 <label class="AliasLabel" for="AliasEdit">'s profile</label>
             </div>
         </div>

    </div>

        <div class="PasswordContainer">
            <asp:TextBox TextMode="Password" runat="server" ID="NewPassword" placeholder="New password..."></asp:TextBox>
            <asp:CompareValidator runat="server" ControlToValidate="NewPassword" ControlToCompare="ConfirmPassword" ErrorMessage="No match" CssClass="Validator" ValidationGroup="Password"></asp:CompareValidator>
            <asp:TextBox TextMode="Password" runat="server" ID="ConfirmPassword" placeholder="Confirm password..."></asp:TextBox>
        </div>

    </div>
</asp:Content>
