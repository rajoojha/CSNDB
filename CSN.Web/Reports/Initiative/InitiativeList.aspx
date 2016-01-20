<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InitiativeList.aspx.cs" MasterPageFile="~/Views/Shared/ReportsMaster.Master" Inherits="CSNApplication.Reports.Initiative.InitiativeList" %>

  <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
               <div style="width:98%; overflow-x:scroll ; overflow-y: scroll; padding-bottom:10px;">
            <table class="table-condensed">
                <tr>
       
    <td class="captionColumn">
                      Initiative Status 
                    </td>
                    <td align="left">
                        <asp:ListBox   Height="100px" ID="lstInitiativeStatus" class="captionColumn" runat="server" 
                            SelectionMode="Multiple" AutoPostBack="True" onselectedindexchanged="lstInitiativeStatus_SelectedIndexChanged" >
                            <asp:ListItem Value="1" Selected="True">Active</asp:ListItem>
                            <asp:ListItem Value="0" Selected="True">InActive</asp:ListItem>
                        </asp:ListBox>
                    </td>

        <td class="captionColumn">
         CSN Rep.
        </td>
         <td align="left">
         
         <asp:ListBox ID="lstCSNRep"    Height="100px"  runat="server" 
                 SelectionMode="Multiple" AutoPostBack="True" 
                 onselectedindexchanged="lstCSNRep_SelectedIndexChanged" 
                 ontextchanged="lstCSNRep_TextChanged" >  
             
        </asp:ListBox> 
     
             
        </td>

        <td class="captionColumn">
   Principal
        </td>
         <td align="left">
         <asp:ListBox ID="lstPrincipal"   Height="100px"  runat="server" SelectionMode="Multiple" >  
             
        </asp:ListBox> 
             
        </td>

         <td class="captionColumn">
     Account
        </td>
         <td align="left">
         <asp:ListBox ID="lstAccount"   Height="100px"  runat="server" SelectionMode="Multiple" >  
             
        </asp:ListBox> 
             
        </td>
         

         
     

        <td class="captionColumn">
 Initiative Description
        </td>
         <td align="left">
         <asp:ListBox ID="lstInitiativeDescription"   Height="100px"  runat="server" SelectionMode="Multiple" >  
             
        </asp:ListBox> 
             
        </td>

     
       <td class="captionColumn">
        Initiative Result
        </td>
       <td align="left">
         <asp:ListBox ID="lstInitiativeResult"   Height="100px"  runat="server" SelectionMode="Multiple" >  
             
        </asp:ListBox> 
             
        </td>

       <td>
       Inititative Entry Status
       </td>

       <td align="left">
         <asp:ListBox ID="lstInitiativeEntryStatus" class="captionColumn" runat="server"   Height="100px"
           SelectionMode="Multiple" AutoPostBack="True" onselectedindexchanged="lstInitiativeEntryStatus_SelectedIndexChanged" >
          <asp:ListItem Value="0" Selected="True">QUALIFIED</asp:ListItem>
           <asp:ListItem Value="1" Selected="True">DISQUALIFIED</asp:ListItem>
         </asp:ListBox>
       </td>
      <td  class="captionColumn">
         <asp:Button ID="btnShow" runat="server" Text="Search" class="button"  onclick="btnShow_Click" />
       </td>
    </tr>


    <tr>
     <td width="20%" class="captionColumn">
                            Select Column
                        </td>
     <td width="100%" class="captionColumn" colspan="8">
                     <asp:CheckBoxList ID="chkColumnList" runat="server"   RepeatDirection="Horizontal">                               
                               <asp:ListItem Value="BuyersName">Buyers Name</asp:ListItem>
                                <asp:ListItem Value="PresentDate">Present Date</asp:ListItem> 
                                <asp:ListItem Value="PresentTo">Present To</asp:ListItem> 
                                 <asp:ListItem Value="Response">Response</asp:ListItem> 
                                 <asp:ListItem Value="FollowupDate">Followup Date</asp:ListItem> 
                                <asp:ListItem Value="Comments">Comments</asp:ListItem>  

                            </asp:CheckBoxList>
                        </td> 
  </tr>
    </table>
        </div>     
      <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
        Font-Size="8pt" Height="800px" InteractiveDeviceInfos="(Collection)" 
        WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="100%" ShowPageNavigationControls="false"  SizeToReportContent="true">
        <LocalReport ReportPath="Reports\Initiative\InitiativeReport.rdlc">
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
