<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewCompany.aspx.cs" Inherits="DreamCareer.ViewCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/ViewCompany.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/ViewCompany.css" />
    <link rel="Stylesheet" type="text/css" href="static/css/SearchResults.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">


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

            <% if (this.UserOwnsCompany)
                {%>

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

            <% } %>
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

            <% if (this.UserOwnsCompany)
                { %>
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
            <% } %>

            <td>
                <asp:Label runat="server"
                    ID="CompanySizeErrorLabel"
                    CssClass="CompanySizeErrorLabel error-label">
                </asp:Label>
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
                    CssClass="update-value UpdateCompanyDescription"
                    TextMode="MultiLine"
                    Height="200">
                </asp:TextBox>

            </td>

            <% if (this.UserOwnsCompany)
                { %>
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
            <% } %>
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

            <% if (this.UserOwnsCompany)
                { %>
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
            <% } %>
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

            <% if (this.UserOwnsCompany)
                { %>
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
            <% } %>
        </tr>

        <%-- State --%>
        <tr id="company-state-row">

            <td id="company-state-label-column">
                <h3>Company State</h3>
            </td>

            <td>

                <p runat="server"
                    id="CompanyState"
                    class="CompanyState">
                </p>

                <asp:TextBox runat="server"
                    ID="UpdateCompanyStateTextBox"
                    CssClass="UpdateCompanyState update-value">
                </asp:TextBox>

            </td>

            <% if (this.UserOwnsCompany)
                { %>
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
            <% } %>
        </tr>

        <%-- Zipcode --%>
        <tr id="company-zipcode-row">

            <td id="company-zipcode-label-column">
                <h3>Company Zipcode</h3>
            </td>

            <td>

                <p runat="server"
                    id="CompanyZipcode"
                    class="CompanyZipcode">
                </p>

                <asp:TextBox runat="server"
                    ID="UpdateCompanyZipcodeTextBox"
                    CssClass="UpdateCompanyZipcode update-value">
                </asp:TextBox>

            </td>

            <% if (this.UserOwnsCompany)
                { %>
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
            <% } %>

            <td>
                <asp:Label runat="server"
                    ID="CompanyZipcodeErrorLabel"
                    CssClass="error-label CompanyZipcodeErrorLabel">
                </asp:Label>
            </td>
        </tr>

        <%-- Viewing tags --%>
        <tr id="tag-row">
            <td>
                <h3>Company Tags</h3>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="CompanyTagsLabel">
                </asp:Label>
            </td>

            <td>
                <asp:Label runat="server"
                    ID="CompanyTagsErrorLabel"
                    CssClass="error-label">
                </asp:Label>
            </td>
        </tr>

        <%-- Open positions --%>
        <tr>
            <td>
                <h3>Company Positions
                </h3>
            </td>

            <td>
                <%= GetCompanyPositions() %>
            </td>

            <% if (this.UserOwnsCompany)
                { %>
            <td>
                <asp:Button runat="server"
                    ID="InsertPositionButton"
                    Text="Create Position"
                    OnClick="AddPosition" />
            </td>
            <% } %>
        </tr>


    </table>

    <% if (this.UserOwnsCompany)
        { %>
    <%-- Adding tags --%>
    <div id="add-tags-div">
        <asp:TextBox runat="server"
            ID="TagInput">
        </asp:TextBox>

        <asp:Button runat="server"
            ID="SubmitTagButton"
            Text="Add Tag"
            OnClick="InsertCompanyTag" />

    </div>

    <%-- Deleting the company --%>
    <div id="delete-button-div">
        <asp:Button runat="server"
            ID="DeleteCompanyButton"
            OnClick="DeleteCompany"
            Text="Delete Company" />
    </div>
    <% } %>
</asp:Content>
