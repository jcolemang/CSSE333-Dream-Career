<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewCompany.aspx.cs" Inherits="DreamCareer.ViewCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/ViewCompany.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/ViewCompany.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form runat="server">

        <%-- BLAME ASP FOR MY SELECTORS --%>
        <%-- I dont know why they thought rendering id useless was a good idea --%>
        <%-- In a couple places I use classes instead of ids when I could use ids --%>
        <%-- To keep it a little bit consistent  --%>

        <table id="company-info-table">

            <%-- Table header/Company Name --%>
            <tr>
                <td colspan="2">
                    <h3 id="CompanyName" class="CompanyName" runat="server"></h3>
                    <asp:TextBox
                        runat="server"
                        CssClass="update-value UpdateCompanyName"
                        ID="UpdateCompanyNameTextBox">
                    </asp:TextBox>

                </td>
                <td>
                    <button type="button"
                        class="expand-update"
                        id="company-name-expand-update"
                        onclick="toggleCompanyName()">
                        Update Name
                    </button>

                    <%-- Note that this one has runat=server --%>
                    <asp:Button
                        ID="UpdateCompanyNameButton"
                        CssClass="submit-update CompanyNameSubmitUpdate"
                        runat="server"
                        OnClick="UpdateCompanyName"
                        Text="Submit"></asp:Button>

                    <button type="button"
                        id="company-name-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanyName()">
                        Cancel
                    </button>

                </td>
            </tr>

            <%-- Company size row --%>
            <tr>
                <td id="company-size-label-column">
                    <h3>Company Size</h3>

                </td>
                <td>
                    <p runat="server"
                        id="CompanySize"
                        class="CompanySize">
                    </p>

                    <asp:TextBox runat="server"
                        ID="UpdateCompanySizeTextBox"
                        CssClass="update-value UpdateCompanySize">
                    </asp:TextBox>
                </td>

                <td>
                    <button type="button"
                        id="company-size-expand-update"
                        class="expand-update"
                        onclick="toggleCompanySize()">
                        Update Size
                    </button>

                    <asp:Button runat="server"
                        CssClass="submit-update CompanySizeSubmitUpdate"
                        ID="UpdateCompanySizeButton"
                        OnClick="UpdateCompanySize"
                        Text="Submit" />

                    <button type="button"
                        id="company-size-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanySize()">
                        Cancel
                    </button>

                </td>

            </tr>

            <%-- Company Description row --%>
            <tr id="company-description-row">

                <td id="company-description-label-column">
                    <h3>Company Description</h3>
                </td>

                <td>

                    <p runat="server"
                        id="CompanyDescription"
                        class="CompanyDescription">
                    </p>

                    <asp:TextBox runat="server"
                        ID="UpdateCompanyDescriptionTextBox"
                        CssClass="update-value UpdateCompanyDescription">
                    </asp:TextBox>

                </td>

                <td>

                    <button type="button"
                        id="company-description-expand-update"
                        class="expand-update"
                        onclick="toggleCompanyDescription()">
                        Update Description
                    </button>

                    <asp:Button runat="server"
                        ID="UpdateCompanyDescriptionButton"
                        CssClass="submit-update CompanyDescriptionSubmitUpdate"
                        OnClick="UpdateCompanyDescription"
                        Text="Submit" />

                    <button type="button"
                        id="company-description-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanyDescription()">
                        Cancel
                    </button>

                </td>
            </tr>

            <%-- Company location--%>

            <%-- Street --%>
            <tr id="company-street-row">
                <td id="company-street-label-column">
                    <h3>Company Street</h3>
                </td>

                <td>

                    <p runat="server"
                        id="CompanyStreet"
                        class="CompanyStreet">
                    </p>

                    <asp:TextBox runat="server"
                        ID="UpdateCompanyStreetTextBox"
                        CssClass="update-value UpdateCompanyStreet">
                    </asp:TextBox>

                </td>

                <td>

                    <button type="button"
                        id="company-street-expand-update"
                        class="expand-update"
                        onclick="toggleCompanyStreet()">
                        Update Street
                    </button>

                    <asp:Button runat="server"
                        ID="UpdateCompanyStreetButton"
                        CssClass="submit-update CompanyStreetSubmitUpdate"
                        OnClick="UpdateCompanyStreet"
                        Text="Submit" />

                    <button type="button"
                        id="company-street-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanyStreet()">
                        Cancel
                    </button>

                </td>
            </tr>

            <%-- City --%>
            <tr id="company-city-row">
                <td id="company-city-label-column">
                    <h3>Company City</h3>
                </td>
                <td>

                    <p runat="server"
                        id="CompanyCity"
                        class="CompanyCity">
                    </p>

                    <asp:TextBox runat="server"
                        ID="UpdateCompanyCityTextBox"
                        class="UpdateCompanyCity update-value">
                    </asp:TextBox>

                </td>

                <td>

                    <button type="button"
                        id="company-city-expand-update"
                        class="expand-update"
                        onclick="toggleCompanyCity()">
                        Update City
                    </button>

                    <asp:Button runat="server"
                        CssClass="submit-update CompanyCitySubmitUpdate"
                        OnClick="UpdateCompanyCity"
                        Text="Submit" />

                    <button type="button"
                        id="company-city-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanyCity()">
                        Cancel
                    </button>

                </td>

            </tr>

            <%-- State --%>
            <tr id="company-state-row">

                <td id="company-state-label-column">
                    <h3>Company State</h3>
                </td>

                <td>

                    <p runat="server" id="CompanyState"></p>

                    <asp:TextBox runat="server"
                        ID="UpdateCompanyStateTextBox"
                        CssClass="UpdateCompanyState update-value">
                    </asp:TextBox>

                </td>

                <td>

                    <button type="button"
                        id="company-state-expand-update"
                        class="expand-update"
                        onclick="toggleCompanyState()">
                        Update State
                    </button>

                    <asp:Button runat="server"
                        OnClick="UpdateCompanyState"
                        CssClass="submit-update CompanyStateSubmitUpdate"
                        Text="Submit" />

                    <button type="button"
                        id="company-state-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanyState()">
                        Cancel
                    </button>

                </td>
            </tr>

            <%-- Zipcode --%>
            <tr id="company-zipcode-row">

                <td id="company-zipcode-label-column">
                    <h3>Company Zipcode</h3>
                </td>

                <td>

                    <p runat="server" id="CompanyZipcode"></p>

                    <asp:TextBox runat="server"
                        ID="UpdateCompanyZipcodeTextBox"
                        CssClass="UpdateCompanyZipcode update-value">
                    </asp:TextBox>

                </td>

                <td>

                    <button type="button"
                        id="company-zipcode-expand-update"
                        class="expand-update"
                        onclick="toggleCompanyZipcode()">
                        Update Zipcode
                    </button>

                    <asp:Button runat="server"
                        OnClick="UpdateCompanyZipcode"
                        CssClass="submit-update CompanyZipcodeSubmitUpdate"
                        Text="Submit" />

                    <button type="button"
                        id="company-zipcode-cancel-update"
                        class="cancel-update"
                        onclick="toggleCompanyZipcode()">
                        Cancel
                    </button>

                </td>
            </tr>

        </table>

    </form>

</asp:Content>
