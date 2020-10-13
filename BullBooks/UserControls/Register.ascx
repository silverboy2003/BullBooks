<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="BullBooks.UserControls.Register" %>
<div class="RegisterDiv">
        <p>Register</p>

        <div class="RegisterIn">
        
            <div class="InputBox">
                <label for="EmailIn" class="InputLabel">Email</label>
                <asp:CustomValidator ID="EmailValidator" runat="server" ControlToValidate="EmailIn" CssClass="Validator" OnServerValidate="EmailVal"></asp:CustomValidator>
                <asp:TextBox ID="EmailIn" runat="server" CssClass="In"></asp:TextBox> 
            </div>
            
            <div class="InputBox">
                <label for="UsernameIn">Username</label>
                <asp:TextBox ID="UsernameIn" runat="server" CssClass="In"></asp:TextBox>
            </div>

            <div class="InputBox">
                <label for="AliasIn">Alias</label>
                <asp:TextBox ID="AliasIn" runat="server" CssClass="In"></asp:TextBox>
            </div>

            <div class="InputBox">
                <label for="PasswordIn">Password</label>
                <asp:TextBox ID="PasswordIn" runat="server" CssClass="In" TextMode="Password"></asp:TextBox>
            </div>

            <div class="InputBox">
                <label for="ConPasswordIn">Confirm Password</label>
                <asp:TextBox ID="ConPasswordIn" runat="server" CssClass="In" TextMode="Password"></asp:TextBox>
            </div>

            <div class="InputBox">
                <label for="CalendarIn">Birth Date</label>
                <input type="date" id="CalendarIn" name="CalendarIn" runat="server"/>
            </div>
            <div class="InputBox">
                <label for="GenderIn">Gender</label>
                <asp:DropDownList ID="GenderIn" runat="server">
                    <asp:ListItem Value="0">Male</asp:ListItem>
                    <asp:ListItem Value="1">Female</asp:ListItem>
                    <asp:ListItem Value="2">Other</asp:ListItem>
                </asp:DropDownList>
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Register" CssClass="LoginButton" OnClick="RegisterUser"/>

        </div>


    </div>