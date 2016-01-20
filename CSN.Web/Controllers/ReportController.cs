using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSN.Web.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CSNReport()
        {
            ViewBag.PageCaption = "Report CSN List";

            return Redirect("~/Reports/EMPLOYEE/CSNEmployeeList.aspx");
        }
        public ActionResult CSNBuyers()
        {
            ViewBag.PageCaption = "Buyers List";

            return Redirect("~/Reports/Buyers/BuyersList.aspx");
        }
        public ActionResult MfgContact()
        {
            ViewBag.PageCaption = "CSN Principal Contact List";

            return Redirect("~/Reports/PrincipalLine/MfgContactList.aspx");
        }

        public ActionResult MfgList()
        {
            ViewBag.PageCaption = "CSN Principal List";

            return Redirect("~/Reports/PrincipalLine/PrincipalList.aspx");
        }

        public ActionResult CSNAccount()
        {
            ViewBag.PageCaption = "CSN Account Directory";
            return Redirect("~/Reports/Accounts/AccountList.aspx");
        }

        public ActionResult InitiatiDataEntryReport()
        {
            ViewBag.PageCaption = "Initiative Data Entry Report";
            return Redirect("~/Reports/Initiative/InitiativeList.aspx");
        }
        public ActionResult GeneralActivitiesReport()
        {
            ViewBag.PageCaption = "General Activities Report";
            return Redirect("~/Reports/GeneralActivities/GeneralActivities.aspx");
        }


    }
}
