<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyersList.aspx.cs" Inherits="CSNApplication.Reports.Buyers.BuyersList" MasterPageFile="~/Views/Shared/ReportsMaster.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
             <div style="width:98%; overflow-x:scroll ; overflow-y: scroll; padding-bottom:10px;">
            <table class="table-condensed">

                <tr> 
                    <td align="left">
                        <asp:ListBox ID="lstAccountType" Height="100px" Width="200px"  class="captionColumn" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstAccountType_SelectedIndexChanged" SelectionMode="Multiple">
                            <asp:ListItem Value="Distributor" Selected="True">Distributor</asp:ListItem>
                            <asp:ListItem Value="Retailer" Selected="True">Retailer</asp:ListItem>
                        </asp:ListBox>

                        <td class="captionColumn">
                            <asp:Label ID="lblAcc" runat="server" Text="Account 1"></asp:Label></td>
                        <td align="left">
                            <asp:ListBox ID="lstAccount" Height="100px" Width="200px" class="captionColumn" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                        <td class="captionColumn">Account2
                        </td>
                        <td align="left">
                            <asp:ListBox ID="lstAccount2" class="captionColumn" Height="100px" Width="200px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                        </td>
                    </td>


                    <td class="captionColumn">CSN Rep
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstCSN" Width="150px" Height="100px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    </td>


                    <td class="captionColumn">State
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstState" Width="150px" Height="100px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    </td>

                    <td class="captionColumn">Territory
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstTerritory" Width="150px" Height="100px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    </td>
                    <td class="captionColumn">DO NOT Send Mass Email
                    </td>
                    <td align="left" class="captionColumn">
                        <asp:ListBox ID="lstMassMail" runat="server" Height="50px" SelectionMode="Multiple">
                            <asp:ListItem Value=" " Selected="True">No </asp:ListItem>
                            <asp:ListItem Value="X" Selected="True">Yes</asp:ListItem>
                        </asp:ListBox>
                    </td>
                    <td class="captionColumn">Platform
                    </td>
                    <td align="left" class="captionColumn">
                        <asp:ListBox ID="lstPlatform" Height="100px" Width="200px" runat="server" SelectionMode="Multiple"></asp:ListBox>
                    </td>


                </tr>
                </table>
                    <table class="table-striped ">
                <tr>
                    <td width="20%" class="captionColumn">Select Column 
                    </td>
                    <td width="100%" class="captionColumn" colspan="10">
                        <asp:CheckBoxList ID="chkColumnList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                            <asp:ListItem Value="LastName">Last Name</asp:ListItem>
                            <asp:ListItem Value="ContactTitle">Contact Title</asp:ListItem>
                            <asp:ListItem Value="Address">Address</asp:ListItem>
                            <asp:ListItem Value="City">City</asp:ListItem>
                            <asp:ListItem Value="State">State</asp:ListItem>
                            <asp:ListItem Value="Zip">Zip</asp:ListItem>
                            <asp:ListItem Value="Country">Country</asp:ListItem>
                            <asp:ListItem Value="OfficePhone">Office Phone</asp:ListItem>
                            <asp:ListItem Value="PhoneExt">Phone Ext</asp:ListItem>
                            <asp:ListItem Value="CellNumber">Cell Number</asp:ListItem>
                            <asp:ListItem Value="FaxNumber">Fax Number</asp:ListItem>
                            <asp:ListItem Value="ContactEmail">Contact Email</asp:ListItem>
                            <asp:ListItem Value="MassMail">DO NOT Send Mass Email</asp:ListItem>

                        </asp:CheckBoxList>
                    </td>

                    <td class="captionColumn">
                        <asp:Button ID="btnShow" runat="server" Text="Search" class="button" OnClick="btnShow_Click" />
                    </td>
                </tr>
            </table>
                 </div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                Height="800px" InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                WaitMessageFont-Size="14pt" Width="100%" ShowPageNavigationControls="false" SizeToReportContent="true">
                <LocalReport ReportPath="Reports\Buyers\BuyersList.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="up" runat="server">
        <ProgressTemplate>
            Update in Progress……..
        </ProgressTemplate>
    </asp:UpdateProgress>


</asp:Content>


