<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DreamCareer.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" href="static/css/home.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <div id="page-title-div">
        <h1 id="page-header-text">Welcome to Dream Career
        </h1>


        <p>
            Created by Aaradhana, Coleman, and Joyce for CSSE333 Databases
        </p>
        <asp:TextBox ID="SearchBar" runat="server"
            CssClass="search-bar-class" Height="46px" Width="690px"></asp:TextBox>
    </div>

    <div id="button-div">
        <asp:Button ID="SearchPositionButton" runat="server"
            Text="Search Positions"
            OnClick="SearchPositionButton_OnClick" Height="50px" Width="205px" />

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

        <asp:Button ID="SearchCompanyButton" runat="server"
            Text="Search Companies"
            OnClick="SearchCompanyButton_OnClick" Height="50px" Width="205px" />

        <br />
        <br />

        <asp:Button ID="SearchProfileButton" runat="server"
            Text="Search Profiles"
            OnClick="SearchProfileButton_OnClick" Height="50px" Width="205px" />
    </div>



</asp:Content>
