<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="DreamCareer.ErrorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <form runat="server">
        <asp:Label runat="server"
            ID="ErrorMessage">
            There was an error :(
        </asp:Label>
    </form>
</asp:Content>
