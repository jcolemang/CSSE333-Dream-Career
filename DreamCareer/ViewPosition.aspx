<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewPosition.aspx.cs" Inherits="DreamCareer.ViewPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/ViewPosition.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/ViewPosition.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">


    <table id="viewposition-info-table">
        <tr>
            <td colspan="2">
                <h3 id="UpdatePosition" class="UpdatePosition" runat="server">Position Info
                </h3>
            </td>
        </tr>

        <tr>
            <td>
                <asp:TextBox type="text" ID="postitle" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="name_dne_error_label"
                    class="error-label asp-name-dne-error-label"
                    runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="info" runat="server" Text="Get Info!"
                    OnClick="ViewPositionButton_OnClick" />
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="positiontitle"
                    class="position-title"
                    runat="server"></asp:Label>
            </td>
        </tr>


        <tr>

            <td>
                <asp:Label ID="positiontype"
                    class="position-type"
                    runat="server"></asp:Label>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Label ID="streetname"
                    class="street-name"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="cityname"
                    class="city-name"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="statename"
                    class="state-name"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="zipcode"
                    class="zip-code"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="salaryamount"
                    class="salary-amount"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="job"
                    class="job-d"
                    runat="server"></asp:Label>
            </td>
        </tr>

    </table>


</asp:Content>
