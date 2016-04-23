<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="DreamCareer.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form runat="server">
        <table id="insert-data-table">
            <tr>
                <th colspan="2">
                    <h2>
                        Insert Data
                    </h2>
                </th>
            </tr>

            <%-- Generating random users --%>
            <tr>
                <td>
                    <asp:Button ID="GenerateUsersButton" 
                        runat="server" Text="Insert Users"
                        OnClick="GenerateUsersButton_OnClick" />
                </td>

                <td>
                    <asp:Label ID="GenerateUsersText"
                        runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <%-- Generating random profiles --%>
            <tr>
                <td>
                    <asp:Button ID="GenerateProfilesButton"
                        runat="server" Text="Insert Profiles"
                        OnClick="GenerateProfilesButton_OnClick" />
                </td>

                <td>
                    <asp:Label ID="GenerateProfilesText"
                        runat="server" Text=""></asp:Label>
                </td>
            </tr>

            <%-- Generating random companies --%>
            <tr>
                <td>
                    <asp:Button ID="GenerateCompaniesButton"
                        runat="server" Text="Insert Companies"
                        OnClick="GenerateCompaniesButton_OnClick" />
                </td>

                <td>
                    <asp:Label ID="GenerateCompaniesLabel"
                        runat="server" Text=""></asp:Label>
                </td>

            </tr>

            <%-- Generating random positions --%>
            <tr>
                <td>
                    <asp:Button ID="GeneratePositionsButton"
                        runat="server" Text="Insert Positions"
                        OnClick="GeneratePositionsButton_OnClick" />
                </td>

                <td>
                    <asp:Label ID="GeneratePositionsLabel"
                        runat="server" Text=""></asp:Label>
                </td>
            </tr>

        </table>
    </form>
</asp:Content>
