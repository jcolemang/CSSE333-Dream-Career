<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="DreamCareer.CreateProfile" %>

<%--<button onclick="return myFunction()" class="dropbtn">Dropdown</button>        --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/Profile.css" rel="stylesheet" type="text/css" />
    <script src="scripts/Profile.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
    <form id="profile_form" runat="server">
        
        <div id="new-profile-table-div" style="text-align:center">
          
             <table id="user_profile-table">

                <tr id="title-row">
                    <th colspan="2" headers="">
                        <h1>
                            My Profile
                        </h1>
                    </th>
                </tr>

            </table>
        </div>
    </form>
   
</asp:Content>
