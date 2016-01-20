<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MfgContactList.aspx.cs"  MasterPageFile="~/Views/Shared/ReportsMaster.Master"  Inherits="CSNApplication.Reports.PrincipalLine.MfgContactList" %>

  <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <table class="table-condensed">
                  
     <tr>
                    
                    
                    <td class="captionColumn">
                    Principal
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstPrincipal" Width="200px" Height="100px"  runat="server" SelectionMode="Multiple">
                        </asp:ListBox>
                    </td> 
                    <td class="captionColumn" rowspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Search" class="button" OnClick="btnShow_Click" />
                    </td>
                </tr>
                    <tr>
                        <td width="20%" class="captionColumn">
                            Select Column
                        </td>
                        <td width="60%" class="captionColumn" colspan="3">
                     <asp:CheckBoxList ID="chkColumnList" runat="server"    RepeatDirection="Horizontal">
                                <asp:ListItem Value="Platform">Platform</asp:ListItem>
                                <asp:ListItem Value="Contact">Contact</asp:ListItem>
                                <asp:ListItem Value="ContactTitle">Contact Title</asp:ListItem> 
                                <asp:ListItem Value="CSNTERRITORY">CSN TERRITORY</asp:ListItem>
                                <asp:ListItem Value="Address">Address</asp:ListItem> 
                                <asp:ListItem Value="City">City</asp:ListItem> 
                                 <asp:ListItem Value="State">State</asp:ListItem>
                                <asp:ListItem Value="Zip">Zip</asp:ListItem>
                                <asp:ListItem Value="Phone">Phone</asp:ListItem> 
                                <asp:ListItem Value="PhoneExt">Phone Ext</asp:ListItem>
                                 <asp:ListItem Value="CellNumber">Cell Number</asp:ListItem>
                                <asp:ListItem Value="ContactEmail">Contact Email</asp:ListItem>
                                <asp:ListItem Value="FaxNumber">Fax Number</asp:ListItem>  
                            </asp:CheckBoxList>
                        </td> 
                    </tr>
                    </table>
    
  <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" 
            Height="600px" ShowPageNavigationControls="false"  SizeToReportContent="true">
            <LocalReport ReportPath="Reports\PrincipalLine\MfgContactMaster.rdlc">
            <DataSources>
            <rsweb:ReportDataSource DataSourceId="DataSet1" Name="DataSet11" />
            </DataSources>
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

