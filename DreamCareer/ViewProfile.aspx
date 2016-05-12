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
               <table id="create-user-profile">
                    <tr id="main-row">
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
                        <th id="description">
                            <h2>
                                Description
                            </h2>
                        </th>
                        <th id="street">
                            <h2>
                                Street
                            </h2>
                        </th>
                         <th id="city">
                            <h2>
                                City
                            </h2>
                        </th>
                         <th id="state">
                            <h2>
                                State
                            </h2>
                        </th>
                         <th id="zipcode">
                            <h2>
                                Zipcode
                            </h2>
                        </th>
                   </tr>
               </table>
           
       

    <asp:Label ID="UsernameLabel" runat="server">
       
    </asp:Label>

    <asp:Label ID="NameLabel" CssClass="profile-label asp-user-profile-label" style="text-align:center" runat="server">
         
    </asp:Label>

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
     <div>
         <table>
             <tr>
                 <td class="buttom-column"></td>
                    <td id="edit-button-container">
                        <asp:Button CssClass="edit-button" ID="Button1" runat="server" Text="Edit Profile" OnClick="EditButton_OnClick"/>
                    </td>
                 <td id="like-button-container">
                        <asp:Button CssClass="like-button" ID="Button2" runat="server" Text="Like" OnClick="LikeButton_OnClick"/>
                    </td>
             </tr>
         </table>
     </div>
         <table id="position-info">
             <tr id="profile-position-info">
                 <th colspan="3">
                      <h1>
                         Position Info
                      </h1>
                  </th>    
             </tr>
                  
         </table>
   </div>
    </form>
</asp:Content>
