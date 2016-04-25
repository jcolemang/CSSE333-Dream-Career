<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="DreamCareer.CreateUser" %>

<%-- inerted into head --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%-- css --%>
    <link href="static/css/CreateUser.css" rel="stylesheet" type="text/css" />

    <%-- javascript --%>
    <script src="scripts/jquery-2.2.3.min.js"
        type="text/javascript"></script>
    <script src="scripts/CreateUser.js"
        type="text/javascript"></script>

</asp:Content>

<%-- inserted into body --%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="user_form" runat="server">

        <div id="new-user-table-div">
            <table id="create-new-user-table">

                <tr id="title-row">
                    <th colspan="2">
                        <h2 id="table-header">
                            Create New User

                        </h2>
                    </th>
                </tr>

                <tr id="username-row">
                    <td>
                        <p>
                            Username
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="username" runat="server"></asp:TextBox>
                    </td>

                    <td>

                        <%-- For the client --%>
                        <label id="username-input-error-label">
                        </label>

                        <%-- For the server --%>
                        <asp:Label ID="username_input_error_label"
                            class="error-label" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr id="password-row">

                    <td><p>Password</p></td>

                    <td>
                        <asp:TextBox TextMode="Password" ID="password" 
                            class="password-input" runat="server"></asp:TextBox>
                    </td>

                </tr>

                <tr id="confirm-password-row">

                    <td><p>Confirm Password</p></td>

                    <td>
                        <asp:TextBox TextMode="Password" ID="confirm_password" 
                            class="password-input" runat="server"></asp:TextBox>
                    </td>

                    <td>
                        <label id="password-input-error-label"
                            class="error-label">
                        </label>
                    </td>

                </tr>

                <tr id="email-row">

                    <td><p>Email</p></td>
                    
                    <td>
                        <asp:TextBox type="text" class="email-input"
                            ID="email" runat="server"></asp:TextBox>
                    </td>

                </tr>

                <tr id="confirm-email-row">
                    <td><p>Confirm Email</p></td>

                    <td>
                        <asp:TextBox type="text" class="email-input"
                            ID="confirm_email" runat="server"></asp:TextBox>
                    </td>

                    <td>
                        <%-- For the client --%>
                        <label id="email-input-error-label"
                            class="error-label">
                        </label>

                        <%-- For the server --%>
                        <asp:Label ID="email_input_error_label"
                            class="error-label" runat="server"></asp:Label>
                    </td>
                </tr>

                <tr id="submit-button-row">

                    <td class="dummy-column"></td>

                    <td id="submit-button-container">
                        <asp:Button CssClass="submit-button" 
                            ID="user_button" runat="server" Text="Insert User"
                            OnClick="InsertUserButton_OnClick" />
                    </td>

                </tr>
            </table>
        </div>
    </form>

</asp:Content>
