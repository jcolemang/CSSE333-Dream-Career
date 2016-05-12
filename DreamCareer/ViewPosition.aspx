<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewPosition.aspx.cs" Inherits="DreamCareer.ViewPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/ViewPosition.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/ViewPosition.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form runat="server">

        <table id="position-info-table">
            <tr>
                <td colspan="2"> 
                    <h3 id="UpdatePosition" class="UpdatePosition" runat="server">
                           Update Position
                    </h3>
                </td>
            </tr>

             <tr>
                    <td>
                        <p id="OldPosTitle">
                           Old Title
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="oldtitle" runat="server"></asp:TextBox>
                    </td>
                     <td>
                        <asp:Label ID="name_dne_error_label"
                            class="error-label asp-name-dne-error-label" 
                            runat="server"></asp:Label>
                    </td>
                </tr>

              <tr>
                    <td>
                        <p id="NewPosTitle">
                            New Title
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="newtitle" runat="server"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td>
                        <p id="PositionType">
                            Position Type
                        </p>
                    </td>
                    <td>

                              <asp:TextBox type="text" ID="typ" runat="server"></asp:TextBox>


                    </td>
                    <td>
                        <label id="gender-not-selected-error"></label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <p id="Street">
                            Street
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="strname" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <p id="City">
                            City
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="cityname" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p id="State">
                            State
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="statename" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p id="Zip">
                            Zip
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="zipcode" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="zip_input_error_label"
                            class="error-label asp-zip-input-error-label" 
                            runat="server"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <p id="Salary">
                            Salary
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="salaryam" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td>
                        <p id="JobDescription">
                            Job Description
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="jobdes" runat="server" MaxLength="1000" style="width: 800px" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="position_button" runat="server" Text="Update Position"
                            OnClick="InsertViewPositionButton_OnClick" />
                    </td>
                </tr>  
            
        </table>

    </form>

</asp:Content>

