<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="CreateProfile.aspx.cs" Inherits="DreamCareer.CreateProfile" %>

<%--<button onclick="return myFunction()" class="dropbtn">Dropdown</button>        --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/Create Profile.css" rel="stylesheet" type="text/css" />
    <script src="scripts/CreateProfile.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <div>
        <table id="create-new-profile-table">
            <tr id="title-row">
                <th colspan="2">
                    <h2 id="table-header">Create a Profile
                    </h2>
                </th>
            </tr>


            <tr>
                <td>
                    <p id="Name">
                        Name
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" 
                        ID="name" 
                        CssClass="name-input"
                        runat="server"></asp:TextBox>
                </td>

                <td>
                    <label id="name-error-label" class="error-label"></label>
                </td>
            </tr>


            <tr>
                <td>
                    <p id="Gender">
                        Gender
                    </p>
                </td>
                <td>

                    <asp:DropDownList
                        type="dropdownlist"
                        ID="gender"
                        runat="server"
                        CssClass="gender-select">

                        <asp:ListItem Text="Select" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Male" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Prefer not to say" Value="5"></asp:ListItem>

                    </asp:DropDownList>


                </td>
                <td>
                    <label id="gender-not-selected-error" class="error-label"></label>
                </td>
            </tr>

            <tr>
                <td>
                    <p id="Major">
                        Major
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="major" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <p id="Street">
                        Street
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="street" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <p id="City">
                        City
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="city" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <p id="State">
                        State
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="state" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <p id="Zip">
                        Zip
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="zip" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <p id="Experience">
                        Experience
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" ID="experience" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="profile_button" 
                        runat="server" Text="Insert Profile"
                        OnClick="InsertProfileButton_OnClick" 
                        OnClientClick="return checkAll()" />
                </td>

                <td>
                    <asp:Label ID="ProfileAlreadyExistsLabel" 
                        runat="server" CssClass="error-label"></asp:Label>
                </td>
            </tr>
        </table>

    </div>

</asp:Content>
