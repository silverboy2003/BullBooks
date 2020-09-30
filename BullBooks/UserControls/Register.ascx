<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="BullBooks.UserControls.Register" %>
<div class="LoginDiv">
        <p>Login</p>

        <div class="LoginIn">
        
            <div class="InputBox">
                <label for="TextIn">Email</label>
                <asp:TextBox ID="TextIn" runat="server" CssClass="In"></asp:TextBox>
            </div>

            <div class="InputBox">
                <label for="PasswordIn">Password</label>
                <asp:TextBox ID="PasswordIn" runat="server" CssClass="In" TextMode="Password"></asp:TextBox>
            </div>

            <asp:Button ID="LoginButton" runat="server" Text="Log In" CssClass="LoginButton" OnClick="RegisterUser"/>

        </div>

        <a href="RegisterPage.aspx">Register</a>

    </div>