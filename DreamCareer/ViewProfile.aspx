﻿<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="DreamCareer.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/Profile.css" rel="stylesheet" type="text/css" />
    <script src="scripts/Profile.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <asp:Label ID="UsernameLabel" runat="server">
        <form id="username" runat="server">
            <div id="username-table-div" style="text-align:center">
                <h2>
                    <%: Session["username"] %>
                </h2>
            </div>
        </form>
    </asp:Label>


    <asp:Label ID="NameLabel" runat="server">
         
    </asp:Label>

    
    <asp:Label ID="GenderLabel" runat="server">

    </asp:Label>


    <asp:Label ID="MajorLabel" runat="server">

    </asp:Label>


    <asp:Label ID="ExperienceLabel" runat="server">

    </asp:Label>

</asp:Content>
