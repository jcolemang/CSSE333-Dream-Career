<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="DreamCareer.ViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/ViewProfile.css" rel="stylesheet" type="text/css" />
    <script src="scripts/Profile.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">
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
               <table id="basic-info">
                   <tr id="profile-basic-info">
                       <th colspan="3">
                           <h1>
                               Basic Info
                           </h1>
                       </th>    
                   </tr>
                  
               </table>
               
<table id="profile-info-table">
    <tr>
        <td colspan="2">
             <h3 id="NameText" class="NameText" runat="server"></h3>
    <asp:Textbox ID="UpdateNameTextBox" CssClass="update-value Edit_Click" runat="server">
     </asp:Textbox>
        </td> 
        <td>
             <button type="button" 
                        class="expand-update ProfileExpandUpdate" 
                        onclick="toggleCompanyName()">
                        Update
                    </button>

             <asp:Button type="button" 
                        CssClass="submit-update ProfileSubmitUpdate"
                        ID="Button1"
                        runat="server"
                        OnClick="Edit_Click"
                        Text="Submit">
                    </asp:Button>

             <button type="button" class="cancel-update ProfileCancelUpdate"
                   onclick="toggleProfile()">
                   Cancel
               </button>

        </td>
    </tr>
 
    <tr>
        <td>
             <p runat="server" id="GenderText">

             </p>
         </td>
    </tr>

    <tr>
        <td>
             <p runat="server" id="MajorText">

             </p>
         </td>
    </tr>

    <tr>
        <td>
             <p runat="server" id="ExperienceText">

             </p>
         </td>
    </tr>

    <tr>
        <td>
             <p runat="server" id="StreetText">

             </p>
         </td>
    </tr>

    <tr>
        <td>
             <p runat="server" id="CityText">

             </p>
         </td>
    </tr>

    <tr>
        <td>
             <p runat="server" id="StateText">

             </p>
         </td>
    </tr>

    <tr>
        <td>
             <p runat="server" id="ZipcodeText">

             </p>
         </td>
    </tr>


    <%-- 
    <asp:Label ID="GenderLabel" CssClass="profile-label asp-user-profile-label" runat="server">

    </asp:Label>


    <asp:Label ID="MajorLabel" CssClass="profile-label asp-user-profile-label" runat="server">

    </asp:Label>

    <asp:Label ID="ExperienceLabel" CssClass="profile-label asp-user-profile-label" runat="server">
     
    </asp:Label>

    <asp:Label ID="StreetLabel" CssClass="profile-label asp-user-profile-label" runat="server">
     
    </asp:Label>

    <asp:Label ID="CityLabel" CssClass="profile-label asp-user-profile-label" runat="server">
     
    </asp:Label>

    <asp:Label ID="StateLabel" CssClass="profile-label asp-user-profile-label" runat="server">
     
    </asp:Label>

    <asp:Label ID="ZipcodeLabel" CssClass="profile-label asp-user-profile-label" runat="server">
     
    </asp:Label>
     </table>
         <table id="position-info">
             <tr id="profile-position-info">
                 <th colspan="3">
                      <h1>
                         </h1>
                  </th>    
             </tr>
                  
         </table>       
     --%>         
        <%--        <asp:Button Css-Class="edit-button" ID="Button2" runat="server" Height="30px" OnClick="Edit_Click" Text="Edit Profile" Width="122px" BackColor="#6699FF" BorderStyle="None" Font-Bold="True" Font-Italic="True" Font-Size="Medium" />--%>
              
             
              
   </table>            
   </div>
    </form>
    <h1>Position Info </h1>
</asp:Content>
