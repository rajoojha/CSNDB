using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSN.ViewModel;
using CSN.Common;
using CSN.DAL;
using System.Data;
using System.Dynamic;
using System.Data.Entity.Validation;
using System.Configuration;
namespace CSN.Web.Controllers.Accounts
{
    public class Accounts 
    {

        /// <summary>
        ///  
        /// </summary>
        public DataSet getAccounsDDL(int AccountCode, int CSNID)
        {
            ManageAccounts objManageAccounts = new ManageAccounts();
            return objManageAccounts.getAccounsDDL(AccountCode, CSNID);
        }
        public static DataSet SaveAccountsList(dynamic pParameters)
        {
            return new ManageAccounts().SaveAccountsList(pParameters);

        }
    }

    public class ManageContactsDetails  
    {
        /// <summary>
        /// Get The Required Data to Add a New Contact List And To Show already enterd Contact.
        /// </summary>
        public DataSet getContactList(dynamic values)
        {
            ManageContacts objManageContacts = new ManageContacts();
            return objManageContacts.getContactList(values);
        }

        public DataSet SaveBuyerline(string EA_XML_String, int ContactID)
        {
            ManageContacts objManageContacts = new ManageContacts();
            return objManageContacts.saveBuyerline(EA_XML_String, ContactID);
        }

        public DataTable GetBuyerline(string pContactId)
        {
            ManageContacts objManageContacts = new ManageContacts();
            return objManageContacts.GetBuyerLine(pContactId);
        }


    }
    public class AccountsController : Controller
    {
        UnitOfWork unitOfwork = new UnitOfWork();
        //
        // GET: /Accounts/

        public ActionResult Index()
        {
            return View();
        }


        ///<summary>
        ///Binding Period dropdown list on  Parameter ID selection changing
        ///</summary> 
        public ActionResult getAccount2(string pAccountType1)
        {

            dynamic values1; 
            values1 = (from item in unitOfwork.tblAccountTypesRepository.Get()
                 .Where(e => e.AccountType == pAccountType1)
                 .OrderBy(e => e.TypeName)
                           select new
                           {
                               Value = item.AccountTypeID,
                               Text = item.TypeName
                           }).ToList(); 
            return Json(new { Account2 = values1 }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AccountInfo(int AccountCode)
        {
            dynamic values = new ExpandoObject();
            ViewBag.PageCaption = "View/Edit Account Details";
            Accounts objAccounts = new Accounts();
            DataSet dsAccountsddl = objAccounts.getAccounsDDL(AccountCode, Convert.ToInt32(Session["CSNID"]));

            dsAccountsddl.Tables[0].TableName = "AccountList";
            ViewBag.AccountList = dsAccountsddl.Tables["AccountList"];

            dsAccountsddl.Tables[1].TableName = "AccountType";
            ViewBag.AccountType = dsAccountsddl.Tables["AccountType"];

            dsAccountsddl.Tables[2].TableName = "States";
            ViewBag.States = dsAccountsddl.Tables["States"];


            dsAccountsddl.Tables[3].TableName = "csnlist";
            ViewBag.csnlist = dsAccountsddl.Tables["csnlist"];


            dsAccountsddl.Tables[4].TableName = "AcctStatus";
            ViewBag.AcctStatus = dsAccountsddl.Tables["AcctStatus"];


            dsAccountsddl.Tables[5].TableName = "AccountsDetails";
            ViewBag.AccountsDetails = dsAccountsddl.Tables["AccountsDetails"];


            dsAccountsddl.Tables[6].TableName = "AcctType";
            ViewBag.AcctType = dsAccountsddl.Tables["AcctType"];

            //  ContactList
            dynamic values1;
            using (var db = new CSN.DAL.CSNDBEntities())
            {
                values1 = db.TblContactMasters.Include("TblAccountList")
               .Where(e => e.AccountCode == AccountCode)
               .OrderBy(e => e.FirstName)
               .ToList();
            }

            ViewBag.ContactList = values1;
            ViewBag.AccountCode = AccountCode;
            return PartialView("~/Views/Shared/Partial/Accounts/AccountInfo.cshtml");
        }
        public ActionResult BuyersList(int AccountCode)
        {
            //  ContactList
            dynamic values1;
            using (var db = new CSN.DAL.CSNDBEntities())
            {
                values1 = db.TblContactMasters.Include("TblAccountList")
               .Where(e => e.AccountCode == AccountCode)
               .OrderBy(e => e.FirstName)
               .ToList();
            }

            ViewBag.ContactList = values1;
            return PartialView("Views/Shared/Partial/Contacts/ContactListView.cshtml");
        }

        public ActionResult ManageAccount(int? AccountCode)
        {
            if (AccountCode == null)
            {
                AccountCode = -1;
            }
            dynamic values = new ExpandoObject();
            ViewBag.PageCaption = "View/Edit Account Details";
            Accounts objAccounts = new Accounts();
            DataSet dsAccountsddl = objAccounts.getAccounsDDL((int)AccountCode, Convert.ToInt32(Session["CSNID"]));

            dsAccountsddl.Tables[0].TableName = "AccountList";
            ViewBag.AccountList = dsAccountsddl.Tables["AccountList"];

            dsAccountsddl.Tables[1].TableName = "AccountType";
            ViewBag.AccountType = dsAccountsddl.Tables["AccountType"];

            dsAccountsddl.Tables[2].TableName = "States";
            ViewBag.States = dsAccountsddl.Tables["States"];


            dsAccountsddl.Tables[3].TableName = "csnlist";
            ViewBag.csnlist = dsAccountsddl.Tables["csnlist"];


            dsAccountsddl.Tables[4].TableName = "AcctStatus";
            ViewBag.AcctStatus = dsAccountsddl.Tables["AcctStatus"];


            dsAccountsddl.Tables[5].TableName = "AccountsDetails";
            ViewBag.AccountsDetails = dsAccountsddl.Tables["AccountsDetails"];


            dsAccountsddl.Tables[6].TableName = "AcctType";
            ViewBag.AcctType = dsAccountsddl.Tables["AcctType"];

            //  ContactList
            dynamic values1;
            using (var db = new CSN.DAL.CSNDBEntities())
            {
                values1 = db.TblContactMasters.Include("TblAccountList")
               .Where(e => e.AccountCode == AccountCode)
               .OrderBy(e => e.FirstName)
               .ToList();
            }

            ViewBag.ContactList = values1;
            ViewBag.AccountCode = AccountCode;
            return View("~/Views/Accounts/ManageAccount.cshtml");
        }

        public ActionResult SearchAccounts(string pCompanyName, int? pCSNDirID, string pAccountType1, string pAccountType2, string pState, bool? pDryOnly, bool? pFreezer,
        bool? pFood, string pZip)
        {
            IList<TblAccountList> objAcccount;
            using (var db = new CSN.DAL.CSNDBEntities())
            {

                objAcccount = db.TblAccountLists.Include("TblCSNList")
                    .Where((e => e.Company.Contains(pCompanyName) && (pCSNDirID == null ? e.CSNDirID == e.CSNDirID : e.CSNDirID == pCSNDirID)
                       && (pAccountType1 == "" ? e.CustType1 == e.CustType1 : e.CustType1 == pAccountType1)
                       && (pAccountType2 == "" ? e.CustType2 == e.CustType2 : e.CustType2 == pAccountType2)
                       && (pState == "" ? e.State == e.State : e.State == pState)
                       && (e.Zip.Contains(pZip))
                    ))
                    .OrderBy(e => e.Company)
                    .ToList();
            }
            ViewBag.AccountList1 = objAcccount;
            ViewBag.sAccCSNREF = pCSNDirID;
            return PartialView("~/Views/Shared/Partial/Accounts/AccountListView.cshtml");
        }


        public ActionResult SearchBuyers()
        {

            dynamic values1;

            dynamic values = new ExpandoObject();
            ViewBag.PageCaption = "View/Edit Buyers List";
            Accounts objAccounts = new Accounts();
            DataSet dsAccountsddl = objAccounts.getAccounsDDL(-1, Convert.ToInt32(Session["CSNID"]));

            dsAccountsddl.Tables[0].TableName = "AccountList";
            ViewBag.AccountList = dsAccountsddl.Tables["AccountList"];

            dsAccountsddl.Tables[1].TableName = "AccountType";
            ViewBag.AccountType = dsAccountsddl.Tables["AccountType"];

            dsAccountsddl.Tables[2].TableName = "States";
            ViewBag.States = dsAccountsddl.Tables["States"];


            dsAccountsddl.Tables[3].TableName = "csnlist";
            ViewBag.csnlist = dsAccountsddl.Tables["csnlist"];


            dsAccountsddl.Tables[4].TableName = "AcctStatus";
            ViewBag.AcctStatus = dsAccountsddl.Tables["AcctStatus"];


            dsAccountsddl.Tables[5].TableName = "AccountsDetails";
            ViewBag.AccountsDetails = dsAccountsddl.Tables["AccountsDetails"];


            dsAccountsddl.Tables[6].TableName = "AcctType";
            ViewBag.AcctType = dsAccountsddl.Tables["AcctType"];

            using (var db = new CSN.DAL.CSNDBEntities())
            {
                values1 = db.TblContactMasters.Include("TblAccountList")
               //.OrderBy(e => e.TblAccountList.Company)
               .ToList();
            }

            ViewBag.ContactList = values1;
            return View("~/Views/Contacts/ViewContacts.cshtml");
        }


        public ActionResult ViewAccounts()
        {
            int AccountCode = -1;
            dynamic values = new ExpandoObject();
            ViewBag.PageCaption = "View/Edit Account Details";
            Accounts objAccounts = new Accounts();
            int? CSNID = Convert.ToInt32(Session["CSNID"]);
            DataSet dsAccountsddl = objAccounts.getAccounsDDL(AccountCode, Convert.ToInt32(Session["CSNID"].ToString()));


            dsAccountsddl.Tables[0].TableName = "AccountList";
            ViewBag.AccountList = dsAccountsddl.Tables["AccountList"];

            dsAccountsddl.Tables[1].TableName = "AccountType";
            ViewBag.AccountType = dsAccountsddl.Tables["AccountType"];

            dsAccountsddl.Tables[2].TableName = "States";
            ViewBag.States = dsAccountsddl.Tables["States"];


            //dsAccountsddl.Tables[3].TableName = "csnlist";
            // ViewBag.csnlist = dsAccountsddl.Tables["csnlist"];


            dsAccountsddl.Tables[4].TableName = "AcctStatus";
            ViewBag.AcctStatus = dsAccountsddl.Tables["AcctStatus"];


            dsAccountsddl.Tables[5].TableName = "AccountsDetails";
            ViewBag.AccountsDetails = dsAccountsddl.Tables["AccountsDetails"];


            dsAccountsddl.Tables[6].TableName = "AcctType";
            ViewBag.AcctType = dsAccountsddl.Tables["AcctType"];


            ViewBag.PageCaption = "View Account Details";


            IList<TblAccountList> objAcccount;

            dynamic vCsnList;
            using (var db = new CSN.DAL.CSNDBEntities())
            {

                if (Session["RoleID"].ToString() == "1" || Session["RoleId"].ToString() == "28")
                {
                    objAcccount = db.TblAccountLists//.Include("TblCSNLists")
                        .OrderBy(e => e.Company)
                        .ToList();



                    vCsnList = (from x1 in db.TblCSNLists.OrderBy(e => e.FullName)
                                select new
                                {
                                    Text = x1.FullName,
                                    Value = x1.CSNID
                                }).ToList();

                }
                else
                {
                    objAcccount = db.TblAccountLists//.Include("TblCSNLists")
                                   .Where(e => e.CSNDirID == CSNID)
                                          .OrderBy(e => e.Company)
                                          .ToList();

                    vCsnList = (from x1 in db.TblCSNLists.Where(e => e.CSNID == CSNID).OrderBy(e => e.FullName)
                                select new
                                {
                                    Text = x1.FullName,
                                    Value = x1.CSNID
                                }).ToList();
                }


            }


            ViewBag.AccountList1 = objAcccount;
            ViewBag.csnlist = vCsnList;
            return View("~/Views/Accounts/ViewAccounts.cshtml");

        }


        public ActionResult DeleteAccount(int AccountCode)
        {
            ViewBag.PageCaption = "Delete Account List";
            int sResult = 0;
            string vResult = string.Empty;
            string vMessage = string.Empty;
            using (var context = new CSN.DAL.CSNDBEntities())
            {
                try
                {


                    var TblContactMastersList = context.TblContactMasters.Where(d => d.AccountCode == AccountCode);
                    if (TblContactMastersList != null)
                    {
                        foreach (var ContactMastersList in TblContactMastersList)
                        {
                            //var BuyersLineCarryList = context.TblBuyersLineCarrys.Where(d => d.ContactID == ContactMastersList.ContactID);
                            //if (BuyersLineCarryList != null)
                            //{
                            //    foreach (TblBuyersLineCarry BuyersLineCarry in BuyersLineCarryList)
                            //    {
                            //        context.TblBuyersLineCarrys.Remove(BuyersLineCarry);
                            //    }
                            //}

                            context.TblContactMasters.Remove(ContactMastersList);
                        }
                    }

                    var TblInitiativeResultsList = context.TblInitiativeResults.Where(d => d.AccountID == AccountCode);
                    if (TblInitiativeResultsList != null)
                    {
                        foreach (var InitiativeResults in TblInitiativeResultsList)
                        {
                            context.TblInitiativeResults.Remove(InitiativeResults);
                        }

                    }



                    var Account = context.TblAccountLists.FirstOrDefault(e => e.AccountCode == AccountCode);
                    context.TblAccountLists.Remove(Account);
                    sResult = context.SaveChanges();
                    vResult = "S";
                    vMessage = "S";
                }
                catch
                {
                    vResult = "error";
                    vMessage = "error";

                }



            }

            return Json(new { Status = vResult, Message = vMessage });
        }


        public ActionResult ManageAccount11(int AccountCode)
        {
            ViewBag.PageCaption = "Manage CSN List";

            /*  CSNList objCSNList = new CSNList();
              DataSet dsCSNList = objCSNList.GETCSNListByID(AccountCode);
              dsCSNList.Tables[0].TableName = "CSNList";
              dsCSNList.Tables[1].TableName = "StateMaster";
              ViewBag.CSNList = dsCSNList.Tables["CSNList"];
              ViewBag.StateMaster = dsCSNList.Tables["StateMaster"];
              return View("~/Views/Shared/Partial/CSNList/ManageCSNList.cshtml");*/

            using (var db = new CSN.DAL.CSNDBEntities())
            {
                return View(db.TblAccountLists.Find(AccountCode));
            }

        }



        /// <summary>
        /// Save New Entered General Review in Database.
        [HttpPost]
      
        public ActionResult SaveAccounts(string pAccountCode, string pCompanyName, string pCompanyPhone, string pCompanyExt, string pCompanyFax, bool? pDryOnly, bool? pFreezer,
        bool? pFood, string pAccountType1, int? pPrimaryAcctCode, int? pNuberOfStores, string pAccountType2, string pTerritory, string pDivision, int? pCSNDirID,
            string pAddress1, string pAddress2, string pCity, string pState, string pZip, string pCountry, string pShipToName, string pShipToAddress1, string pShipToAddress2,
            string pShipToCity, string pShipToState, string pShipZip, bool? pHotProgram, string pRollerGrid, string pGasBand, string pPrimaryDistributor, string pShipToCountry)
        {
            int sResult = 0;
            string vResult = string.Empty;
            string vMessage = string.Empty;
            int vAccountCode = 0;
            dynamic values = new TblAccountList();
            values.Company = pCompanyName;
            values.CompanyPhone = pCompanyPhone;
            values.CompanyExt = pCompanyExt;
            values.CompanyFax = pCompanyFax;
            values.DryOnly = pDryOnly;
            values.Freezer = pFreezer;
            values.Food = pFood;
            values.CustType1 = pAccountType1;
            values.PrimaryAcctCode = pPrimaryAcctCode;
            values.NumStores = pNuberOfStores;
            values.CustType2 = pAccountType2;
            values.Territory = pTerritory;
            values.Division = pDivision;
            values.CSNDirID = pCSNDirID;
            values.AcctStatusID = "ACTIVE";
            values.Address1 = pAddress1;
            values.Address2 = pAddress2;
            values.City = pCity;
            values.State = pState;
            values.Zip = pZip;
            values.Country = pCountry;
            values.ShipToName = pShipToName;
            values.ShipToAddress1 = pShipToAddress1;
            values.ShipToAddress2 = pShipToAddress2;
            values.ShipToCity = pShipToCity;
            values.ShipToState = pShipToState;
            values.ShipToMailCode = pShipZip;
            values.ShipToCountry = pShipToCountry;
            values.RollerGrid = pRollerGrid;
            values.FoodProgram = pHotProgram;
            values.GasBrand = pGasBand;
            values.PrimaryAcctCode = pPrimaryAcctCode;
            using (var db = new CSN.DAL.CSNDBEntities())
            {



                try
                {
                    if (pAccountCode == "")
                    {
                        var User = db.TblAccountLists.OrderByDescending(u => u.AccountCode).FirstOrDefault();
                        if (User == null)
                        {
                            values.AccountCode = 1;
                        }
                        else
                        {
                            values.AccountCode = User.AccountCode + 1;
                        }

                        db.TblAccountLists.Add(values);
                        sResult = db.SaveChanges();
                    }
                    else
                    {
                        values.AccountCode = Convert.ToInt32(pAccountCode);
                        db.Entry(values).State = EntityState.Modified;
                        sResult = db.SaveChanges();
                    }
                    if (sResult == 1)
                    {
                        vResult = "S";
                        vMessage = "S";
                        vAccountCode = values.AccountCode;
                    }


                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }

                }


            }

            ViewBag.AccountCode = vAccountCode;
            return Json(new { Status = vResult, Message = vMessage, AccountCode = vAccountCode });
        }



        /// <summary>
        /// Submit the Request to Fetch Data For Excel.
        /// </summary>  
    
        public ActionResult ExportToExcel()
        {
            dynamic objAcccount;
            using (var db = new CSN.DAL.CSNDBEntities())
            {
                objAcccount = (from x in db.TblAccountLists.OrderBy(e => e.Company)
                               join y in db.TblCSNLists on x.CSNDirID equals y.CSNID 
                               select new
                               {
                                   Company = x.Company,
                                   Address = x.Address1 + " " + x.Address2 + " " + x.City,
                                   CompanyPhone = x.CompanyPhone,
                                   CompanyFax = x.CompanyFax,
                                   State = x.State,
                                   Zip = x.Zip,
                                   Country = x.Country,
                                   ShippingAddress = x.ShipToAddress1 + " " + x.ShipToAddress2 + " " + x.ShipToCity,
                                   CSNRef = y.FullName,
                                   AccountType = x.CustType1,
                                   NumberOfStore = x.NumStores
                               }).ToList();


            }

            var grid = new System.Web.UI.WebControls.GridView();

            grid.AutoGenerateColumns = true;
            grid.AllowPaging = false;

            grid.DataSource = objAcccount;
            grid.DataBind();
            grid.HeaderStyle.BackColor = System.Drawing.Color.FromName("#fff8cf");
            grid.HeaderStyle.Font.Bold = true;

            System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);

            grid.RenderControl(oHtmlTextWriter);

            ShowXLS(oStringWriter.ToString(), "AccountList");
            return null;
        }

        /// <summary>
        /// Render Excel.
        /// </summary>  
        private void ShowXLS(string datagridstring, string FileName)
        {
            string tmpChartName = "header_s.jpg";
            string imgPath = ConfigurationManager.AppSettings["ImagePath"].ToString() + tmpChartName;
            string htmlstring = @"
            <html>
            <head>
            </head>
            <body> 
            <table cellspacing='0' rules='all' border='1' style='border-collapse: collapse;'>
            <tr style='background-color: #fff8cf; font-weight: bold;'>
           <td style= 'height:100px'>  
            <img width='60%'  src=" + imgPath + " ></td><td align='left'colspan='5'><h1>Accounts List</h1></td></tr><tr><td colspan='6'><br/><br/><br/><br/>";

            string html = htmlstring + datagridstring + "</body></html>";
            Response.Clear();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(1));
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Cache-Control", "no-Cache");
            Response.Charset = "";
            Response.Write(html);
            Response.AppendHeader("content-disposition", "attachment;filename=" + FileName + ".xls");

            Response.Flush();
            Response.End();
        }

        public ActionResult ViewContacts()
        {
            dynamic values = new ExpandoObject();

            values.PageSize = 1000;
            values.PageNumber = 1;
            values.CSNID = null;
            values.FirstName = null;
            values.LastName = null;
            values.Status = null;
            ViewBag.PageCaption = "View/Edit Contact List";
            ManageContactsDetails objManageContactsDetails = new ManageContactsDetails();
            DataSet dsContactList = objManageContactsDetails.getContactList(values);
            dsContactList.Tables[0].TableName = "ContactList";
            ViewBag.ContactList = dsContactList.Tables["ContactList"];
            return View();
        }


    }
}
