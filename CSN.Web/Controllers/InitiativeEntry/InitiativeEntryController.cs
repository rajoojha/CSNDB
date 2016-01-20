using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSN.Business;
using CSN.ViewModel;

namespace CSN.Web.Controllers.InitiativeEntry
{
    public class InitiativeEntryController : Controller
    {
        //
        // GET: /InitiativeEntry/
        private readonly IInitiativeEntry initiativeEntry;

        public InitiativeEntryController(IInitiativeEntry iinitiativeEntry)
        {
            initiativeEntry = iinitiativeEntry;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InitiativeDataEntry()
        {
            if (Session["CSNID"] == null)
            {
                return base.View("~/Views/Login/Login");
            }
            int CSNID = Convert.ToInt32(Session["CSNID"].ToString());
            var CSNList = initiativeEntry.GetCNSList(CSNID);
            ViewBag.CSNList = CSNList;
            //dynamic obj2 = new ExpandoObject();
            //obj2.CSNID = Convert.ToInt32(Session["CSNID"].ToString());
            //obj2.MfgID = ""; 
            //DataSet set = initiativeEntry.InitiativeEntryList(obj2);
            //set.Tables[0].TableName = "InitiativeEntryListView";
            //((dynamic)base.ViewBag).InitiativeEntryListView = set.Tables["InitiativeEntryListView"];
            return base.View("~/Views/InitiativeEntry/Index.cshtml");
        }
    }
}
