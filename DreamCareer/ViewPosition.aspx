<%@ Page Title="" Language="C#" MasterPageFile="~/base.Master" AutoEventWireup="true" CodeBehind="ViewPosition.aspx.cs" Inherits="DreamCareer.ViewPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="scripts/ViewPosition.js" type="text/javascript"></script>

    <link rel="Stylesheet" type="text/css" href="static/css/ViewPosition.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderBody" runat="server">


    <table id="viewposition-info-table">
        <tr>
            <td colspan="2">
                <h3 id="UpdatePosition" class="UpdatePosition" runat="server">Position Info
                </h3>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="positiontitle"
                    class="position-title"
                    runat="server"></asp:Label>
            </td>
        </tr>


        <tr>

            <td>
                <asp:Label ID="positiontype"
                    class="position-type"
                    runat="server"></asp:Label>
            </td>

        </tr>

        <tr>

            <td>
                <asp:Label ID="streetname"
                    class="street-name"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="cityname"
                    class="city-name"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="statename"
                    class="state-name"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>

            <td>
                <asp:Label ID="zipcode"
                    class="zip-code"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="salaryamount"
                    class="salary-amount"
                    runat="server"></asp:Label>
            </td>
        </tr>

        <tr>

            <td>
                <asp:Label ID="job"
                    class="job-d"
                    runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
        <td>

                <%-- Note that this one has runat=server --%>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />
                <hr />
                <asp:GridView ID="GridView1" runat="server" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White"
                    RowStyle-BackColor="#A1DCF2" AlternatingRowStyle-BackColor="White" AlternatingRowStyle-ForeColor="#000"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Name" HeaderText="File Name"/>
                        <asp:TemplateField ItemStyle-HorizontalAlign = "Center">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkDownload" runat="server" 
                                    Text="Download" 
                                    OnClick="DownloadFile"
                                    CommandArgument='<%#Eval("id")%>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
          
                <asp:Button ID="Apply" runat="server" Text="Apply!"
                    OnClick="ApplyButton_OnClick" />
          

            </td>
        </tr> 
    </table>


</asp:Content>
