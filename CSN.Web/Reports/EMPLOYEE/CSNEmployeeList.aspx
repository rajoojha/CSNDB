<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CSNEmployeeList.aspx.cs"  MasterPageFile="~/Views/Shared/ReportsMaster.Master"
    Inherits="CSNApplication.Reports.EMPLOYEE.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
 
 <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   
 
   
        <asp:UpdatePanel ID="up" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                	<div class="content-wrapper">
                        	<div class="panel panel-flat">
                <table class="table-condensed">
                  
                    <tr>
                        <td class="captionColumn">
                            Department
                        </td>
                        <td align="left"> 
                            <asp:ListBox   Height="100px" Width="200px"  ID="ddlCaption"  runat="server" SelectionMode="Multiple">
                                <asp:ListItem Value="Admin" Selected="True">Admin</asp:ListItem>
                                <asp:ListItem Value="Sales" Selected="True">Sales</asp:ListItem>
                            </asp:ListBox>
                        </td>


                        <td class="captionColumn">
                            State
                        </td>
                        <td align="left" class="captionColumn">
                            <asp:ListBox ID="lstState" Height="100px" Width="200px"  runat="server" SelectionMode="Multiple">
                            </asp:ListBox>
                        </td>
                        
                                                
                        <td class="captionColumn">
                            Territory
                        </td>
                        <td align="left" class="captionColumn">
                            <asp:ListBox ID="lstTerritory" Height="100px" Width="200px"    runat="server" SelectionMode="Multiple">
                            </asp:ListBox>
                        </td>
                    </tr>


                    </table>
                <table class="table-striped">
                    <tr>
                        <td>
                            Select Column
                        </td>
                        <td>
                            <asp:CheckBoxList ID="chkColumnList" runat="server"  class="table-condensed" RepeatDirection="Horizontal">
                                <asp:ListItem Value="FirstName">First Name</asp:ListItem>
                                <asp:ListItem Value="LastName">Last Name</asp:ListItem>
                                <asp:ListItem Value="Dept">Dept</asp:ListItem>
                                <asp:ListItem Value="Title">Title</asp:ListItem>
                                <asp:ListItem Value="Email">Email</asp:ListItem>
                                <asp:ListItem Value="CellPhone">Cell Phone</asp:ListItem>
                                <asp:ListItem Value="Phone">Phone</asp:ListItem>
                                <asp:ListItem Value="Ext">Ext</asp:ListItem>
                                <asp:ListItem Value="Fax">Fax</asp:ListItem>
                                <asp:ListItem Value="Address">Address</asp:ListItem>
                                <asp:ListItem Value="City">City</asp:ListItem>
                                <asp:ListItem Value="State">State</asp:ListItem>
                                <asp:ListItem Value="Zip">Zip</asp:ListItem>
                                <asp:ListItem Value="Territory">Territory</asp:ListItem>
                            </asp:CheckBoxList>
                        </td>
                        <td width="20%" class="captionColumn">
                            <asp:Button ID="btnShow" runat="server" Text="Search" class="btn btn-primary" OnClick="btnShow_Click" />
                        </td>
                    </tr>
                </table>
                                </div>

</div>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                    InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                    Width="100%" Height="800px"  ExportContentDisposition="AlwaysAttachment" 
                    ViewStateMode="Enabled" ShowPageNavigationControls="false"  SizeToReportContent="true">
                    <LocalReport ReportPath="Reports\EMPLOYEE\CSNEmployeeList.rdlc" EnableExternalImages="true">
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
 