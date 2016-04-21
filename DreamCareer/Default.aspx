<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DreamCareer.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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

    <form id="profile_form" runat="server">

        <div>
        </div>

    </form>

    <div>
        <asp:Label ID="error_label" runat="server"></asp:Label>
    </div>

</body>
</html>
