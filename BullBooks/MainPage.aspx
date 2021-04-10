<%@ Page Title="" Language="C#" MasterPageFile="~/Toolbar.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="BullBooks.MainPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="OuterBox">

        <div class="MainpageContainer">
            <p class="MainpageHeader">WELCOME TO BULLBOOKS</p>
                <div class="MainpageLogin">
                    <p runat="server" id="UserButton">LOGIN</p>
                    <h5>FOR THE BEST EXPERIENCE</h5>
                    <a href="LoginPage.aspx"><span class="MainpageLink"></span></a>
                </div>
            <div class="MainpageInnerDiv">

                    <div class="MainpageBooks">
                        <h4>BROWSE OUR</h4>
                        <h4>BOOKS</h4>
                        <a href="SearchPage.aspx"><span class="MainpageLink"></span></a>
                    </div>

                    <div class="MainpageThreads">
                        <h4>BROWSE OUR</h4>
                        <h4>THREADS</h4>
                        <a href="ThreadSearchPage.aspx"><span class="MainpageLink"></span></a>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
