﻿<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewProfile.aspx.cs" Inherits="DreamCareer.ViewProfile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/ViewProfile.css" rel="stylesheet" type="text/css" />
    <link href="static/css/SearchResults.css" rel="stylesheet" type="text/css" />
    <script src="scripts/Profile.js" type="text/javascript"></script>
    <style type="text/css">
        .auto-style1 {
            height: 38px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

        <table id="title-profile">
            <tr id="profile-title">
                <th colspan="3">
                    <h1>&nbsp;&nbsp;&nbsp; Profile
                    </h1>
                </th>
            </tr>
        </table>

        <table id="profile-info-table" style="height: 618px; width: 634px">
            <tr>
                <td colspan="2" class="auto-style1">
                    
                    <h1 id="NameText" class="NameText" runat="server"></h1>
                    
                </td>
               
            </tr>
            <%--gender --%>
            <tr>
                <td id="Profile-gender-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Gender</h2>
                </td>
                <td>
                    <p runat="server" id="GenderText" class="GenderText"></p>
                    <asp:TextBox runat="server"
                        ID="UpdateGenderTextBox"
                        CssClass="update-value UpdateGender" Width="104px"></asp:TextBox>
                </td>

                <td>
                <%--    <button type="button"
                        id="profile-gender-expand-update"
                        class="expand-update"
                        onclick="toggleProfileGender()">
                        Update
                    </button> --%>

                    <asp:Button runat="server"
                        CssClass="submit-update GenderSubmitUpdate"
                        ID="UpdateGenderButton"
                        OnClick="UpdateGender"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>
            <%-- major --%>
            <tr>
                <td id="Profile-major-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Major</h2>
                </td>
                <td>
                    <p runat="server" id="MajorText" class="MajorText"></p>
                    <asp:TextBox runat="server"
                        ID="UpdateMajorTextBox"
                        CssClass="update-value UpdateMajor" Width="104px"></asp:TextBox>
                </td>

                <td>
              <%--      <button type="button"
                        id="profile-major-expand-update"
                        class="expand-update"
                        onclick="toggleProfileMajor()">
                        Update
                    </button> --%>

                    <asp:Button runat="server"
                        CssClass="submit-update MajorSubmitUpdate"
                        ID="UpdateMajorButton"
                        OnClick="UpdateMajor"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>
            <%-- experience --%>
            <tr>
                <td id="Profile-experience-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Experience</h2>
                </td>
                <td>
                    <p runat="server" id="ExperienceText" class="ExperienceText">&nbsp;</p>
                    <asp:TextBox runat="server"
                        ID="UpdateExperienceTextBox"
                        CssClass="update-value UpdateExperience" Width="104px"></asp:TextBox>
                </td>
                <td>
              <%--      <button type="button"
                        id="profile-experience-expand-update"
                        class="expand-update"
                        onclick="toggleProfileExperience()">
                        Update
                    </button>   --%>

                    <asp:Button runat="server"
                        CssClass="submit-update ExperienceSubmitUpdate"
                        ID="UpdateExperienceButton"
                        OnClick="UpdateExperience"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>
            <%-- street --%>
            <tr>
                <td id="Profile-street-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Street</h2>
                </td>
                <td>
                    <p runat="server" id="StreetText" class="StreetText"></p>
                    <asp:TextBox runat="server"
                        ID="UpdateStreetTextBox"
                        CssClass="update-value UpdateStreet" Width="104px"></asp:TextBox>
                </td>
                <td>
              <%--      <button type="button"
                        id="profile-street-expand-update"
                        class="expand-update"
                        onclick="toggleProfileStreet()">
                        Update
                    </button>  --%>
                    <asp:Button runat="server"
                        CssClass="submit-update StreetSubmitUpdate"
                        ID="UpdateStreetButton"
                        OnClick="UpdateStreet"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>
            <%-- city --%>
            <tr>
                <td id="Profile-city-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; City</h2>
                </td>
                <td>
                    <p runat="server" id="CityText" class="CityText"></p>
                    <asp:TextBox runat="server"
                        ID="UpdateCityTextBox"
                        CssClass="update-value UpdateCity" Width="104px"></asp:TextBox>
                </td>
                <td>
               <%--     <button type="button"
                        id="profile-city-expand-update"
                        class="expand-update"
                        onclick="toggleProfileCity()">
                        Update
                    </button> --%>
                    <asp:Button runat="server"
                        CssClass="submit-update CitySubmitUpdate"
                        ID="UpdateCityButton"
                        OnClick="UpdateCity"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>
            <%-- state --%>
            <tr>
                <td id="Profile-state-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; State</h2>
                </td>
                <td>
                    <p runat="server" id="StateText" class="StateText"></p>
                    <asp:TextBox runat="server"
                        ID="UpdateStateTextBox"
                        CssClass="update-value UpdateState" Width="104px"></asp:TextBox>
                </td>
                <td>
                <%--    <button type="button"
                        id="profile-state-expand-update"
                        class="expand-update"
                        onclick="toggleProfileState()">
                        Update
                    </button>  --%>
                    <asp:Button runat="server"
                        CssClass="submit-update StateSubmitUpdate"
                        ID="UpdateStateButton"
                        OnClick="UpdateState"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>
            <%-- zipcode --%>
            <tr>
                <td id="Profile-zipcode-label-column">
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Zipcode</h2>
                </td>
                <td>
                    <p runat="server" id="ZipcodeText" class="ZipcodeText"></p>
                    <asp:TextBox runat="server"
                        ID="UpdateZipcodeTextBox"
                        CssClass="update-value UpdateZipcode" Width="104px"></asp:TextBox>
                </td>
                <td>
                <%--    <button type="button"
                        id="profile-zipcode-expand-update"
                        class="expand-update"
                        onclick="toggleProfileZipcode()">
                        Update
                    </button>  --%>
                    <asp:Button runat="server"
                        CssClass="submit-update ZipcodeSubmitUpdate"
                        ID="UpdateZipcodeButton"
                        OnClick="UpdateZipcode"
                        Text="Submit" Height="38px" Width="97px" />
                </td>
            </tr>

            <tr>
                <td>
                    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Companies</h2>
                </td>

                <td>
                    <%= WriteUserCompanies() %>
                </td>
            </tr>
        </table>


        <%--name --%>
        &nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Delete" Height="38px" Width="94px" />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Like" Height="38px" Width="94px" />



</asp:Content>
