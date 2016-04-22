<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DreamCareer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <!-- Body -->

    <form id="user_form" runat="server">

        <div>
            <h1>Login to your account!</h1>
            <label>
                Username:
                <asp:TextBox type="text" ID="username" runat="server"></asp:TextBox>
            </label>

            <label>
                Password:
                <asp:TextBox type="text" ID="password" runat="server"></asp:TextBox>
            </label>

            <asp:Button ID="login_button" runat="server" Text="Login" OnClick="LoginButton_Onclick"/>

        </div>

    </form>

</asp:Content>
