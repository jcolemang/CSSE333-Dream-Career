<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="DreamCareer.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/ViewProfile.css" rel="stylesheet" type="text/css" />
    <script src="scripts/Profile.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">


    <asp:Label ID="UsernameLabel" runat="server">
       <form id="user_profile" runat="server">
           <div id="new-user-username">
               <table id="title-profile">
                   <tr id="profile-title">
                       <th colspan="3">
                           <h1>
                               Profile
                           </h1>
                       </th>    
                   </tr>
                  
               </table>
               <table id="create-user-profile">
                    <tr id="main-row">
                       <th id="username">
                           <h2>
                               Username            
                           </h2>
                       </th>
                        <th id="name">
                            <h2>
                                Name
                            </h2>
                        </th>
                        <th id="gender">
                            <h2>
                                Gender
                            </h2>
                        </th>
                        <th id="major">
                            <h2>
                                Major
                            </h2>
                        </th>
                   </tr>
               </table>
           </div>
       </form>
    </asp:Label>

    <asp:Label ID="NameLabel" CssClass="profile-label asp-user-profile-label" style="text-align:center" runat="server">
         
    </asp:Label>

    <asp:Label ID="GenderLabel" CssClass="profile-label asp-user-profile-label" runat="server">

    </asp:Label>


    <asp:Label ID="MajorLabel" CssClass="profile-label asp-user-profile-label" runat="server">

    </asp:Label>

    <asp:Label ID="ExperienceLabel" CssClass="profile-label asp-user-profile-label" runat="server">
     
    </asp:Label>

   

</asp:Content>
