<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="DreamCareer.CreateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Create a Profile</h1>
        <label>
            Username 
            <asp:TextBox type="text" ID="prof_username" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
            Name
            <asp:TextBox type="text" ID="name" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
            Gender
            <asp:TextBox type="text" ID="gender" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
            Major
            <asp:TextBox type="text" ID="major" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
            Address
            <asp:TextBox type="text" ID="address" runat="server"></asp:TextBox>
        </label>
        <br />
        <label>
            Experience
            <asp:TextBox type="text" ID="experience" runat="server"></asp:TextBox>
        </label>
        <br />

        <asp:Button ID="profile_button" runat="server" Text="Insert Profile"
            OnClick="InsertProfileButton_OnClick" />
    </div>
    <div>
        <asp:Label ID="error_label" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
