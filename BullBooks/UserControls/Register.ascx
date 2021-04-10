<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="BullBooks.UserControls.Register" %>
<div class="RegisterDiv">
        <p>Register</p>

        <div class="RegisterIn">
        
            <div class="InputBox">
                <label for="EmailIn" class="InputLabel">Email</label>
                <asp:TextBox ID="EmailIn" runat="server" CssClass="In"></asp:TextBox> 
                <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" ControlToValidate="EmailIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexEmail" runat="server" ControlToValidate="EmailIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="Email invalid" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="EmailCheckValidator" runat="server" ControlToValidate="EmailIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="Email taken" OnServerValidate="EmailCheck"></asp:CustomValidator>
            </div> 
            
            <div class="InputBox">
                <label for="UsernameIn">Username</label>
                <asp:TextBox ID="UsernameIn" runat="server" CssClass="In"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UsernameIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegexUsername" runat="server" ControlToValidate="UsernameIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="Username invalid" ValidationExpression="^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="UsernameCheckValidator" runat="server" ControlToValidate="UsernameIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="Username taken" OnServerValidate="UsernameCheck"></asp:CustomValidator>
            </div>

            <div class="InputBox">
                <label for="AliasIn">Alias</label>
                <asp:TextBox ID="AliasIn" runat="server" CssClass="In"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegexAlias" runat="server" ControlToValidate="AliasIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="Alias invalid" ValidationExpression="^[A-Za-z0-9]+([ _-][A-Za-z0-9]+)*$"></asp:RegularExpressionValidator>
            </div>

            <div class="InputBox">
                <label for="PasswordIn">Password</label>
                <asp:TextBox ID="PasswordIn" runat="server" CssClass="In" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator" runat="server" ControlToValidate="PasswordIn" ControlToCompare="ConPasswordIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="No match"></asp:CompareValidator>
            </div>

            <div class="InputBox">
                <label for="ConPasswordIn">Confirm Password</label>
                <asp:TextBox ID="ConPasswordIn" runat="server" CssClass="In" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConPasswordIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>

            <div class="InputBox">
                <label for="CalendarIn">Birth Date</label>
                <input type="date" id="CalendarIn" name="CalendarIn" runat="server"/>
                <asp:CustomValidator ID="ValidateDate" runat="server" ControlToValidate="CalendarIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="Please enter a valid date" OnServerValidate="ValidateDate_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="CalendarIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div class="InputBox">
                <label for="GenderIn">Gender</label>
                <asp:DropDownList ID="GenderIn" runat="server">
                    <asp:ListItem Value="0">Male</asp:ListItem>
                    <asp:ListItem Value="1">Female</asp:ListItem>
                    <asp:ListItem Value="2">Other</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="GenderIn" CssClass="Validator" ValidationGroup="Register" ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Register" CssClass="LoginButton" OnClick="RegisterUser" CausesValidation="false"/>

        </div>


    </div>