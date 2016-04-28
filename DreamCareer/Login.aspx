<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DreamCareer.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <%-- css --%>
    <link rel="stylesheet"  href="static/css/login.css" />

    <%-- javascript --%>
    <script src="scripts/jquery-2.2.3.min.js"
        type="text/javascript"></script>
    <script src="scripts/Login.js"
        type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <!-- Body -->

    <form id="user_form" runat="server">
        <div id="login-table-div">        
            <table id="user-login-table">
                <tr id="table-row">
                    <th colspan ="2">
                        <h1 id="table header">
                            Login to your account!
                        </h1>
                    </th>
                 </tr>

                <tr id="username-row">
                    <td>
                        <p>
                            Username
                        </p>
                    </td>
                    <td>
                         <asp:TextBox type="text" ID="username" CssClass="asp-username-input" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <label id="login_username_input_error"></label>
                        <asp:Label ID="login_username_input_error" CssClass="error-label asp-username-input-error-label" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr id="password-row">
                    <td>
                        <p>
                            Password
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" TextMode="Password"
                            ID="password" runat="server"></asp:TextBox>
                    </td>
                </tr>

 <%--           <label>
                Password:
                <asp:TextBox type="text" ID="password" runat="server"></asp:TextBox>
            </label>--%>
                <tr id="login_button-row">
                    <td class="dummy-column"></td>
                    <td id="login-button-container">
                        <asp:Button CssClass="login-button" ID="Button1" runat="server" Text="Login" OnClick="LoginButton_OnClick"/>
                    </td>
                </tr>
            </table>

        </div>

    </form>

</asp:Content>
