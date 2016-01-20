<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftNavigation.ascx.cs" Inherits="CSN.Web.Reports.UserControl.LeftNavigation" %>

<div class="navbar navbar-default" id="navbar-second">
    <ul class="nav navbar-nav no-border visible-xs-block">
        <li>
            <a class="text-center collapsed" data-toggle="collapse" data-target="#navbar-second-toggle">
                <i class="icon-menu7"></i>
            </a>
        </li>
    </ul>

    <div class="navbar-collapse collapse" id="navbar-second-toggle">
        <ul class="nav navbar-nav">

            <% 
                CSN.Business.Login onjLohin = new CSN.Business.Login();
                int Userid = Convert.ToInt32(3);
                var navigationList = onjLohin.GetNavigation(Userid);
                if (navigationList.Count() > 0)
                {
                    foreach (var menu in navigationList)
                    {
             
            %>

            <li class="dropdown">

                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                    <%= menu.PageName  %> <span class="caret"></span>
                </a>
                 <ul class="dropdown-menu width-200"> 

                      <% 
                        var SubnavigationList = onjLohin.GetSubNavigation(Userid, menu.PageID);
                        if (SubnavigationList != null)
                        {
                            foreach (var smenu in SubnavigationList)
                            {     %> 
                         <li class="">
                                 <a href='../../<%=smenu.Controller.ToString()%>/<%=smenu.Action.ToString()%>'><%=smenu.PageName.ToString() %></a>  
                             </li>
                             <%   }

                        }
                       %>
                     </ul>
            </li>

            <%  
                }
            }
        
            %>
        </ul>
    </div>
</div>
