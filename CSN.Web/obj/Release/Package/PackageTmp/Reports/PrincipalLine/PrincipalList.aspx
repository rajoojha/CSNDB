<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrincipalList.aspx.cs" MasterPageFile="~/Views/Shared/ReportsMaster.Master" 
    Inherits="CSNApplication.Reports.PrincipalLine.PrincipalList" %>

 <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
                    <div style="width:98%; overflow-x:scroll ; overflow-y: scroll; padding-bottom:10px;">
            <table class="table-condensed">
             <tr>
                <td class="captionColumn">
                    Principal
                </td>
                <td align="left">
                    <asp:ListBox ID="lstPrincipal" Height="100px" runat="server" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td class="captionColumn">
                    Dry
                </td>
                <td align="left" class="captionColumn" >
                    <asp:ListBox ID="lstDry" runat="server" Height="50px" SelectionMode="Multiple">
                          <asp:ListItem Value=" " Selected="True">No </asp:ListItem>
                        <asp:ListItem Value="X"  Selected="True">Yes</asp:ListItem>
                    </asp:ListBox>
                </td>
              
                <td class="captionColumn">
                    Ref.
                </td>
                <td align="left" class="captionColumn">
                    <asp:ListBox ID="lstRef" runat="server" Height="50px" SelectionMode="Multiple">
                      <asp:ListItem Value=" " Selected="True">No </asp:ListItem>
                        <asp:ListItem Value="X"  Selected="True">Yes</asp:ListItem>
                    </asp:ListBox>
                </td>


                <td class="captionColumn">
                    Frozen
                </td>
                <td align="left" class="captionColumn">
                    <asp:ListBox ID="lstFrozen" runat="server" Height="50px" SelectionMode="Multiple">
                     <asp:ListItem Value=" " Selected="True">No </asp:ListItem>
                        <asp:ListItem Value="X"  Selected="True">Yes</asp:ListItem>
                    </asp:ListBox>
                </td>
                
                <td class="captionColumn">
                    DOT Foods
                </td>
                <td align="left" class="captionColumn">
                    <asp:ListBox ID="lstDotFoods" runat="server" Height="50px" SelectionMode="Multiple">
                        <asp:ListItem Value=" " Selected="True">No </asp:ListItem>
                        <asp:ListItem Value="X"  Selected="True">Yes</asp:ListItem>
                    </asp:ListBox>
                </td>
                <td class="captionColumn">
                    Platform
                </td>
                <td align="left" class="captionColumn">
                    <asp:ListBox ID="lstPlatform" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>

                <td class="captionColumn">
                    Territory
                </td>
                <td align="left" class="captionColumn">
                    <asp:ListBox ID="lstTerritory" Height="100px" Width="200px" runat="server" SelectionMode="Multiple">
                    </asp:ListBox>
                </td>


                <td class="captionColumn" rowspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Search" class="button" OnClick="btnShow_Click" />
                </td>
            </tr>
            </table>
                      
        <table class="table" >
           
            <tr>
                <td class="captionColumn">
                    Select Column
                </td>
                <td class="captionColumn" valign="top">
                    <asp:CheckBoxList ID="chkColumnList" runat="server" RepeatDirection="Horizontal" Width="1000px"    >
                        <asp:ListItem Value="MfgName">Mfg&nbsp;Name</asp:ListItem>
                        <asp:ListItem Value="Description">Description</asp:ListItem>
                        <asp:ListItem Value="DryOnly">Dry</asp:ListItem>
                        <asp:ListItem Value="Ref">Ref</asp:ListItem>
                        <asp:ListItem Value="Frozen">Frozen</asp:ListItem>
                        <asp:ListItem Value="DOTFoods">DOT&nbsp;Foods</asp:ListItem>
                        <asp:ListItem Value="Address">Address</asp:ListItem>
                        <asp:ListItem Value="PrimaryPhone1">Primary&nbsp;Phone1</asp:ListItem>
                        <asp:ListItem Value="PrimaryPhone2">Primary&nbsp;Phone2</asp:ListItem>
                        <asp:ListItem Value="EMailAddress">EMail&nbsp;Address</asp:ListItem>
                        <asp:ListItem Value="Website">Website</asp:ListItem>
                        <asp:ListItem Value="Contact">Contact</asp:ListItem>
                        <asp:ListItem Value="ContactTitle">ContactTitle</asp:ListItem>
                        <asp:ListItem Value="ContactAddress">Contact&nbsp;Address</asp:ListItem>
                        <asp:ListItem Value="ContactCity">Contact&nbsp;City</asp:ListItem>
                        <asp:ListItem Value="State">State</asp:ListItem>
                        <asp:ListItem Value="Zip">Zip</asp:ListItem>
                        <asp:ListItem Value="OfficePhone">Office&nbsp;Phone</asp:ListItem>
                        <asp:ListItem Value="Fax">Fax</asp:ListItem>
                        <asp:ListItem Value="Email">Email</asp:ListItem>
                        <asp:ListItem Value="PrincipalPlatform">Principal&nbsp;Platform</asp:ListItem>
                        <asp:ListItem Value="PrincipalTerritory">Principal&nbsp;Territory</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
        </table>
                          </div>
        <div id="dvReports">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                Width="100%" ViewStateMode="Enabled" Height="600px" ShowPageNavigationControls="false"  SizeToReportContent="true">
                <LocalReport ReportPath="Reports\PrincipalLine\PrincipalList.rdlc">
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


<script type="text/javascript">
    $(document).ready(function () {
        $('#onflycheckboxes').find('[href]').removeClass();
        $('#onflycheckboxes [href]').removeClass();

        $('#onflycheckboxes [href]').css('height', 'auto');

    });
   
     
</script>
<script type="text/javascript">
    
    $(document).ready(function () {
        $("table td").each(function () {

            alet($(this).html())

        });
    }); 
</script>
    
</asp:Content>
