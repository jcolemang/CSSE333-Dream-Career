<%@ Page Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="CreateCompany.aspx.cs" Inherits="DreamCareer.CreateCompany" %>

       <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/CreateCompany.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="form1" runat="server">
        <div>
            <table id="create-new-company-table">
                <tr id="title-row">
                    <th colspan="2">
                        <h2 id="table-header">Create a Company
                        </h2>
                    </th>
                </tr>


                <tr>
                    <td>
                        <p id="Name">
                            Company Name
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="compname" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="name_input_error_label"
                            class="error-label asp-name-input-error-label" 
                            runat="server"></asp:Label>
                    </td>
                </tr>


                <tr>
                    <td>
                        <p id="CompSize">
                            Size
                        </p>
                    </td>
                    <td>
                       <asp:DropDownList
                            type="dropdownlist"
                            ID="comsize"
                            runat="server"
                            CssClass="size-select">

                            <asp:ListItem Text="Select" Value="1" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Small" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Medium" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Big" Value="4"></asp:ListItem>
                        </asp:DropDownList>
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
                        <p id="CompanyDescription">
                            Company Description
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="compdes" runat="server" MaxLength="1000" style="width: 800px" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="company_button" runat="server" Text="Insert Company"
                            OnClick="InsertCompanyButton_OnClick" />
                    </td>
                </tr>
            </table>

        </div>

    </form>
</asp:Content>


