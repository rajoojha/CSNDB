<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountList.aspx.cs" Inherits="CSNApplication.Reports.Accounts.AccountList"  MasterPageFile="~/Views/Shared/ReportsMaster.Master" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:content id="Content1" contentplaceholderid="MainContent" runat="server">
   
        <asp:UpdatePanel ID="up" runat="server">
            <ContentTemplate>
                <div style="width:98%; overflow-x:scroll ; overflow-y: scroll; padding-bottom:10px;">
                <table class="table-striped">
                    <tr>
                    <td class="captionColumn">
                        Department
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstAccountType" class="captionColumn" runat="server"  Height="100px" Width="200px"  AutoPostBack=true onselectedindexchanged="lstAccountType_SelectedIndexChanged"  SelectionMode="Multiple">
                            <asp:ListItem Value="Distributor" Selected="True">Distributor</asp:ListItem>
                            <asp:ListItem Value="Retailer" Selected="True">Retailer</asp:ListItem>
                        </asp:ListBox>
                    </td>
                    <td class="captionColumn">Primary Distributor</td>
                     <td align="left">
                        <asp:ListBox ID="lstPrimaryDistributor"  Height="100px" Width="200px" class="captionColumn" runat="server" SelectionMode="Multiple">
                           
                        </asp:ListBox>
                    </td>
                    <td class="captionColumn">
                        Account2
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstAccount2" class="captionColumn" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                           
                        </asp:ListBox>
                    </td>

                    <td class="captionColumn">
                        CSN Rep
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstCSNRep" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                        </asp:ListBox>
                    </td>
                    <td class="captionColumn">
                        State
                    </td>
                    <td align="left">
                        <asp:ListBox ID="lstState" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                        </asp:ListBox>
                    </td>
                  <td class="captionColumn">
                            Territory
                  </td>
                  <td align="left" class="captionColumn">
                   <asp:ListBox ID="lstTerritory" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                    </asp:ListBox>
                   </td>


                     <td class="captionColumn">
                            Platform
                  </td>
                  <td align="left" class="captionColumn">
                   <asp:ListBox ID="lstPlatform" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                    </asp:ListBox>
                   </td>


                </tr>
                    </table>
                         <table class="table-condensed">
                 <tr>
                        <td width="20%" class="captionColumn">
                            Select Column 
                        </td>
                        <td width="100%" class="captionColumn" colspan="4">
                     <asp:CheckBoxList ID="chkColumnList" runat="server"    RepeatDirection="Horizontal"> 
                                <asp:ListItem Value="Address">Address</asp:ListItem>
                                <asp:ListItem Value="City">City</asp:ListItem> 
                                <asp:ListItem Value="Zip">Zip</asp:ListItem>
                                <asp:ListItem Value="Phone">Phone</asp:ListItem> 
                                <asp:ListItem Value="Fax">Fax</asp:ListItem> 
                                 <asp:ListItem Value="Acct">#Accts/Stores</asp:ListItem>
                                <asp:ListItem Value="DistributorType">Distributor&nbsp;Type</asp:ListItem>
                                <asp:ListItem Value="Territories">Territories</asp:ListItem> 
                                <asp:ListItem Value="ShippingAddress">Shipping&nbsp;Address</asp:ListItem> 
                            </asp:CheckBoxList>
                        </td> 

                          <td class="captionColumn">
                        <asp:Button ID="btnShow" runat="server" Text="Search" class="button" OnClick="btnShow_Click" />
                    </td>
                    </tr>
            </table>
                     </div>
                  
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                  InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana"
                WaitMessageFont-Size="14pt" Width="100%"    ShowPageNavigationControls="false"  SizeToReportContent="true"   >
                <LocalReport ReportPath="Reports\Accounts\AccountDirectory.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
                
               </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="up" runat="server">
            <ProgressTemplate>
                Update in Progress……..
            </ProgressTemplate>
        </asp:UpdateProgress>

 
</asp:content>
