<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewCompany.aspx.cs" Inherits="DreamCareer.ViewCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/ViewCompany.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/ViewCompany.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form runat="server">

        <asp:Label runat="server"
            ID="NoCompanyLabel">
        </asp:Label>

        <%-- BLAME ASP FOR MY SELECTORS --%>
        <%-- I dont know why they thought rendering id useless was a good idea --%>
        <%-- In a couple places I use classes instead of ids when I could use ids --%>
        <%-- To keep it a little bit consistent  --%>

        <table id="company-info-table">

            <%-- Table header/Company Name --%>
            <tr>
                <td colspan="2"> 
                    <h3 id="CompanyName" class="CompanyName" runat="server">
                        
                    </h3>
                    <asp:TextBox 
                        runat="server"
                        CssClass="update-value UpdateCompanyName"
                        ID="UpdateCompanyNameTextBox"
                        >
                    </asp:TextBox>

                </td>
                <td>
                    <button type="button" 
                        class="expand-update CompanyNameExpandUpdate" 
                        onclick="toggleCompanyName()">
                        Update Name
                    </button>

                    <%-- Note that this one has runat=server --%>
                    <asp:Button type="button" 
                        CssClass="submit-update CompanyNameSubmitUpdate"
                        ID="UpdateCompanyNameButton"
                        runat="server"
                        OnClick="UpdateCompanyName"
                        Text="Submit">
                    </asp:Button>

                    <button type="button" class="cancel-update CompanyNameCancelUpdate"
                        onclick="toggleCompanyName()">
                        Cancel
                    </button>
                </td>
            </tr>

            <%-- Company size row --%>
            <tr>
                <td>
                    <p runat="server" id="CompanySize">

                    </p>
                </td>
            </tr>

            <%-- Company Description row --%>
            <tr>
                <td>
                    <p runat="server" id="CompanyDescription">

                    </p>
                </td>
            </tr>

            <%-- Company location--%>
            <tr>
                <td>
                    <p runat="server" id="CompanyStreet">

                    </p>
                </td>
            </tr>

            <tr>
                <td>
                    <p runat="server" id="CompanyCity">

                    </p>
                </td>
            </tr>

            <tr>
                <td>
                    <p runat="server" id="CompanyState">

                    </p>
                </td>
            </tr>

            <tr>
                <td>
                    <p runat="server" id="CompanyZipcode"></p>
                </td>
            </tr>
            
        </table>
        <div id="company-info-div">
            <div id="company-location-div">
                <p runat="server" id="Zipcode"></p>
            </div>
        </div>

    </form>

</asp:Content>
