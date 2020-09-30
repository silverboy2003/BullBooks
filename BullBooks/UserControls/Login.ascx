<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="BullBooks.UserControls.Login" %>

<%--<div class="ScreenCover" onclick="HideLogin()">
</div>--%>

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

            <asp:Button ID="LoginButton" runat="server" Text="Log In" CssClass="LoginButton" OnClick="LoginUser"/>

        </div>

        <div class="RedirectDiv">
            <p>Don't have an account yet?</p>
            <a Class="RegisterHref" href="../RegisterPage.aspx">Register</a>
        </div>
        

            <a Class="PasswordHref" href="PasswordChange.aspx">Forgot your password?</a>
    </div>


