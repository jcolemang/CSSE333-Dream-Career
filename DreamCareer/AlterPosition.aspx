<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="AlterPosition.aspx.cs" Inherits="DreamCareer.AlterPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/AlterPosition.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/AlterPosition.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">


    <table id="position-info-table">
        <tr>
            <td colspan="2">
                <h3 id="UpdatePosition" class="UpdatePosition" runat="server">Update Position
                </h3>
            </td>
        </tr>

        <tr>
            <td>
                <p id="OldPosTitle">
                    Old Title
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="oldtitle" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="name_dne_error_label"
                    class="error-label asp-name-dne-error-label"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p id="NewPosTitle">
                    New Title
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="newtitle" runat="server"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="TitleErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>


        <tr>
            <td>
                <p id="PositionType">
                    Position Type
                </p>
            </td>
            <td>

                <asp:TextBox type="text" ID="typ" runat="server"></asp:TextBox>

            </td>
            <td>
                <asp:Label runat="server"
                    ID="TypeErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p id="Street">
                    Street
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="strname" runat="server"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="StreetErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p id="City">
                    City
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="cityname" runat="server"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="CityErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <p id="State">
                    State
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="statename" runat="server"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="StateErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <p id="Zip">
                    Zip
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="zipcode" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="zip_input_error_label"
                    class="error-label asp-zip-input-error-label"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p id="Salary">
                    Salary
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="salaryam" runat="server"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="SalaryErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>
                <p id="JobDescription">
                    Job Description
                </p>
            </td>
            <td>
                <asp:TextBox type="text" ID="jobdes" runat="server" MaxLength="1000" Style="width: 800px"></asp:TextBox>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="DescriptionErrorLabel"
                    CssClass="error-label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="position_button" runat="server" Text="Update Position"
                    OnClick="InsertAlterPositionButton_OnClick" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="delete_position" runat="server" Text="Delete Position"
                    OnClick="DeletePositionButton_OnClick" />
            </td>
        </tr>

    </table>


</asp:Content>

