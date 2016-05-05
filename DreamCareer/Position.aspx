<%@ Page Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="Position.aspx.cs" Inherits="DreamCareer.Position" %>
       <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="static/css/Position.css" rel="stylesheet" type="text/css" />
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">

    <form id="form1" runat="server">
        <div>
            <table id="create-new-position-table">
                <tr id="title-row">
                    <th colspan="2">
                        <h2 id="table-header">Create a Position
                        </h2>
                    </th>
                </tr>


                <tr>
                    <td>
                        <p id="PosTitle">
                            Title
                        </p>
                    </td>
                    <td>
                        <asp:TextBox type="text" ID="titl" runat="server"></asp:TextBox>
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
                        <asp:TextBox type="text" ID="zipname" runat="server"></asp:TextBox>
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
                        <asp:TextBox type="text" ID="jobdes" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>

    </form>
</asp:Content>

