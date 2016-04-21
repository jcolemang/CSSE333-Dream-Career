<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="DreamCareer.CreateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="user_form" runat="server">

        <div>
            <h1>Create a user</h1>
            <label>
                Username:
                <asp:TextBox type="text" ID="username" runat="server"></asp:TextBox>
            </label>

            <label>
                Password:
                <asp:TextBox type="text" ID="password" runat="server"></asp:TextBox>
            </label>

            <label>
                Email:
                <asp:TextBox type="text" ID="email" runat="server"></asp:TextBox>
            </label>

            <asp:Button ID="user_button" runat="server" Text="Insert User"
                OnClick="InsertUserButton_OnClick" />
        </div>

    </form>

    <div>
        <asp:Label ID="error_label" runat="server"></asp:Label>
    </div>

</asp:Content>
