using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSN.Business;
using CSN.ViewModel;

namespace CSN.Web.Controllers.Login
{
    public class LoginController : Controller
    {
       
        private readonly ILogin iLogin;

        public LoginController(ILogin ilogin)
        {
            iLogin = ilogin;
        }
        public ActionResult Index()
        {
            TblCSNListVM pTblCSNListVM = new TblCSNListVM();
            return View(pTblCSNListVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostLogin(TblCSNListVM pTblCSNListVM)
        {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                var UserDetails = iLogin.ValidateUser(pTblCSNListVM.UserName, pTblCSNListVM.Password);
                if (UserDetails != null)
                {
                    // status = true;
                    Session["UserId"] = UserDetails.CSNID;
                    Session["CSNID"] = UserDetails.CSNID;
                    Session["UserName"] = UserDetails.FullName;
                    Session["RoleId"] = UserDetails.Roleid;
                    
                    return View("~/Views/Home/Index.cshtml");
                }
                else
                {
                    ModelState.AddModelError("ErrorMessage", "Please enter correct user name and password");
                }
            }


            return View("~/Views/Login/Index.cshtml");
        }

        public ActionResult LeftNavigation()
        {
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
             int userId = (int)Session["UserId"];
             return PartialView("~/Views/Common/_MenuPartial.cshtml", iLogin.GetNavigation(userId));
        }

        public ActionResult LogOff()
        {
            Session["UserId"] = null;
            return RedirectToAction("Login", "Login");
        }

    }
}
