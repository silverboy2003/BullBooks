<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="BullBooks.UserControls.Login" %>

<%--<div class="ScreenCover" onclick="HideLogin()">
</div>--%>

    <div class="LoginDiv">
        <p>Login</p>

        <div class="LoginIn">
        
            <div class="InputBox">
<<<<<<< HEAD
                <label for="UsernameIn">Username</label>
                <asp:TextBox ID="UsernameIn" runat="server" CssClass="In"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredUsername" ControlToValidate="UsernameIn" runat="server" ErrorMessage="Field cannot be empty" CssClass="Validator"></asp:RequiredFieldValidator>
=======
                <label for="TextIn">Email</label>
                <asp:TextBox ID="TextIn" runat="server" CssClass="In"></asp:TextBox>
>>>>>>> parent of 2b9368b... Designed Register
            </div>

            <div class="InputBox">
                <label for="PasswordIn">Password</label>
                <asp:TextBox ID="PasswordIn" runat="server" CssClass="In" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredPassword" ControlToValidate="PasswordIn" runat="server" ErrorMessage="Field cannot be empty" CssClass="Validator"></asp:RequiredFieldValidator>
            </div>

            <asp:Button ID="LoginButton" runat="server" Text="Log In" CssClass="LoginButton" OnClick="LoginUser"/>

        </div>

        <div class="RedirectDiv">
            <p>Don't have an account yet?</p>
            <a Class="RegisterHref" href="../RegisterPage.aspx">Register</a>
        </div>
        

            <a Class="PasswordHref" href="PasswordChange.aspx">Forgot your password?</a>
    </div>


