<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="DreamCareer.CreateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="static/css/Create Profile.css" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="form1" runat="server">
        <div>
            <table id="create-new-profile-table">
<tr id="title-row">
                    <th colspan="2">
                        <h2 id="table-header">
                            Create a Profile
                        </h2>
                    </th>
                </tr>
            <tr>
                <td>
                    <p id = "Username">
                        Username 
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="prof_username" runat="server"></asp:TextBox>
                </td>
            </tr>

            <br />

            <tr>
                <td>
                    <p id = "Name">
                        Name
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="name" runat="server"></asp:TextBox>
                </td>
            </tr>

            <br />

            <tr>
                <td>
                    <p id = "Gender">
                        Gender
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="gender" runat="server"></asp:TextBox>
                </td>
            </tr>

            <br />

            <tr>
                <td>
                    <p id = "Major">
                        Major
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="major" runat="server"></asp:TextBox>
                </td>
            </tr>

            <br />

            <tr>
                <td>
                    <p id = "Address">
                        Address
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="address" runat="server"></asp:TextBox>
                </td>
            </tr>

            <br />

            <tr>
                <td>
                    <p id = "Experience">
                        Experience
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="experience" runat="server"></asp:TextBox>
                </td>
            </tr>

            <br />

            <tr>
                <td>
                    <asp:Button ID="profile_button" runat="server" Text="Insert Profile"
                        OnClick="InsertProfileButton_OnClick" />
                </td>
            </tr>
        </div>
        <div>
            <asp:Label ID="error_label" runat="server"></asp:Label>
        </div>
    </form>
</asp:Content>
