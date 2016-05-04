<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="SearchResults.aspx.cs" Inherits="DreamCareer.SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <form id="SearchResultsForm" runat="server">
        <%= WriteResults() %>
    </form>
</asp:Content>
