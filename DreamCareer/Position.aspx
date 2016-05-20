<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Position.aspx.cs" Inherits="DreamCareer.Position" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/Position.css" rel="stylesheet" type="text/css" />
    <script src="scripts/CreatePosition.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <div>
        <table id="create-new-position-table">
            <tr id="title-row">
                <th colspan="2">
                    <h2 id="table-header">Create a Position
                    </h2>
                </th>
            </tr>

            <tr>
                <td>
                    <p id="PosTitle">
                        Title
                    </p>
                </td>
                <td>
                    <asp:TextBox type="text" 
                        ID="titl" 
                        runat="server"
                        CssClass="PositionTitle"></asp:TextBox>
                </td>
                <td>
                    <asp:Label ID="name_input_error_label"
                        class="error-label asp-name-input-error-label"
                        runat="server"></asp:Label>
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
                        ID="PositionTypeErrorLabel"
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
                    <asp:TextBox type="text" 
                        ID="jobdes" 
                        runat="server" 
                        MaxLength="1000" 
                        Width="400"
                        Height="200"></asp:TextBox>
                </td>

                <td>
                    <asp:Label runat="server"
                        ID="DescriptionErrorLabel"
                        CssClass="error-label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server"
                        ID="position_button"  
                        Text="Insert Position"
                        OnClick="InsertPositionButton_OnClick" 
                        OnClientClick="return checkAll()" />
                </td>
            </tr>
        </table>

    </div>

</asp:Content>

