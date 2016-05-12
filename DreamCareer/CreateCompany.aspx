<%@ Page ValidateRequest="false" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="CreateCompany.aspx.cs" Inherits="DreamCareer.CreateCompany" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/CreateCompany.css" rel="Stylesheet" type="text/css" />

    <script src="scripts/CreateCompany.js"
        type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="form1" runat="server">
        <%-- Table with a bunch of rows and columns and such --%>


        <%-- The title row --%>
        <table id="create-new-company-table">
            <tr id="title-row">
                <th colspan="2">
                    <h2 id="table-header">Create a Company
                    </h2>
                </th>
            </tr>

            <%-- Name input row --%>
            <tr>
                <td>
                    <label id="name-label">
                        Company Name
                    </label>
                </td>
                <td>
                    <asp:TextBox type="text" 
                        ID="CompanyName" 
                        CssClass="CompanyName"
                        runat="server"></asp:TextBox>
                </td>

                <%-- Because users can't figure it out on their own --%>
                <td class="error-row">
                    <label id="name-input-error-label"
                        class="error-label">
                    </label>
                    <asp:Label runat="server" 
                        ID="CompanyNameErrorLabel"
                        CssClass="error-label CompanyNameErrorLabel">
                    </asp:Label>
                </td>
            </tr>

            <%-- Size input row --%>
            <tr>
                <td>
                    <label id="company-size-label">
                        Size
                    </label>
                </td>
                <td>
                    <asp:TextBox ID="CompanySize" 
                        CssClass="CompanySize"
                        runat="server">
                    </asp:TextBox>
                </td>
                <td>
                    <label id="company-size-error-label"
                        class="error-label"></label>
                </td>

            </tr>

            <%-- Street input row --%>
            <tr>
                <td>
                    <label id="street-label">
                        Street
                    </label>
                </td>
                <td>
                    <asp:TextBox type="text" ID="CompanyStreet" runat="server"></asp:TextBox>
                </td>
            </tr>

            <%-- City input row --%>
            <tr>
                <td>
                    <label id="city-label">
                        City
                    </label>
                </td>
                <td>
                    <asp:TextBox type="text" ID="CompanyCity" runat="server"></asp:TextBox>
                </td>
            </tr>

            <%-- State input row --%>
            <tr>
                <td>
                    <label id="state-label">
                        State
                    </label>
                </td>
                <td>
                    <asp:TextBox type="text" ID="CompanyState" runat="server"></asp:TextBox>
                </td>
            </tr>

            <%-- Zipcode input row --%>
            <tr>
                <td>
                    <label id="Zip">
                        Zip
                    </label>
                </td>
                <td>
                    <asp:TextBox type="text" ID="CompanyZipcode" runat="server"></asp:TextBox>
                </td>
            </tr>

            <%-- Description input row (large) --%>
            <tr>
                <td>
                    <label id="company-description-label">
                        Company Description
                    </label>
                </td>
                <td colspan="2">
                    <%-- Big ol' textbox for the description --%>
                    <asp:TextBox type="text"
                        ID="CompanyDescription"
                        runat="server"
                        MaxLength="1000"
                        TextMode="MultiLine"
                        Width="250"
                        Height="300"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <%-- Just so the button is in the second column --%>
                <td class="dummy-column"></td>
                <td>
                    <asp:Button ID="company_button"
                        runat="server"
                        Text="Insert Company"
                        OnClick="InsertCompanyButton_OnClick"
                        OnClientClick="return validateCompany()" />
                </td>
            </tr>
        </table>


    </form>
</asp:Content>


