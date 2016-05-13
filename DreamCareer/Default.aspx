<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DreamCareer.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="static/css/home.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <div id="page-title-div">
        <h1 id="page-header-text">
            Welcome to Dream Career
        </h1>


        <p>
            Created by Aaradhana, Coleman, and Joyce for CSSE333 Databases
        </p>
    </div>

    <div id="search-bar-div">

        <form id="search_bar_form" runat="server">
            <asp:TextBox ID="SearchBar" runat="server" 
                CssClass="search-bar-class" >
            </asp:TextBox>

            <asp:Button ID="SearchPositionButton" runat="server"
                Text="Search Positions" 
                OnClick="SearchPositionButton_OnClick"/>

            <asp:Button ID="SearchCompanyButton" runat="server"
                Text="Search Companies" 
                OnClick="SearchCompanyButton_OnClick"/>

            <asp:Button ID="SearchProfileButton" runat="server"
                Text="Search Companies" 
                OnClick="SearchProfileButton_OnClick"/>

        </form>

    </div>

</asp:Content>
