<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="DreamCareer.SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="static/css/SearchResults.css" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <form id="SearchResultsForm" runat="server">

        <div id="search-results-div">

            <div id="results-title-div">
                <h2 id="results-title">
                    Search results
                </h2>

                <asp:Button ID="RepeatSearchButton"
                    CssClass="repeat-search-button"
                    runat="server" Text="Search"
                    OnClick="RepeatSearchButton_Click">
                </asp:Button>

                <asp:TextBox ID="RepeatSearchTextBox"
                    CssClass="repeat-search-box"
                    runat="server">
                </asp:TextBox>

            </div>

            <div id="results-content-div">
                <%= WriteResults() %>
            </div>
        </div>

    </form>
</asp:Content>
