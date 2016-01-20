using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSN.Business;
using CSN.ViewModel;

namespace CSN.Web.Controllers.CSNList
{
    public class CSNListController : Controller
    {
        //
        // GET: /CSNList/
        private readonly ICSNList iCSNList;

        public CSNListController(ICSNList icSNList)
        {
            iCSNList = icSNList;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CSNListRequest()
        {
            return View("~/Views/CSNList/EmpList.cshtml", iCSNList.GetCSNList());
        }

        public ActionResult ManageCSNList()
        {
            ViewBag.PageCaption = "Add CSN List";
            TblCSNListVM objTblCSNListVM = new TblCSNListVM();
            return View("~/Views/CSNList/Index.cshtml", objTblCSNListVM);
        }


        
    }
}
