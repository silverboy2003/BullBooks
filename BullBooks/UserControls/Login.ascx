<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="BullBooks.UserControls.Login" %>
<div class="LoginDiv">
    <p>Login</p>

    <div class="LoginIn">
        
        <div class="InputBox">
            <label for="TextIn">Email</label>
            <asp:TextBox ID="TextIn" runat="server" CssClass="In"></asp:TextBox>
        </div>

        <div class="InputBox">
            <label for="PasswordIn">Password</label>
            <asp:TextBox ID="PasswordIn" runat="server" CssClass="In"></asp:TextBox>
        </div>

        <div>
            <asp:Button ID="LoginButton" runat="server" Text="Log In" OnClick="SendLogin" />
        </div>
    </div>

</div>
