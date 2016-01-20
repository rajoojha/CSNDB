using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Collections;
using System.Data;
using CSN.DAL;
using CSN.ViewModel;
namespace CSNApplication.Reports.Buyers
{
    public partial class BuyersList : System.Web.UI.Page
    {

        UnitOfWork unitOfwork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                for (int i = 0; i < chkColumnList.Items.Count; i++)
                {
                    chkColumnList.Items[i].Selected = true;
                }
                BindList(); 
                BindPlatform();
           
                BindReport();
            }
        }
        
        public void BindPlatform()
        {

            dynamic Platform;
            
                Platform = (from x1 in unitOfwork.TblPlatformsRepository.Get().OrderBy(e => e.Platform)
                            select new
                            {
                                Text = x1.Platform,
                                Value = x1.PlatformID
                            }).ToList(); 

            lstPlatform.DataSource = Platform;
            lstPlatform.DataTextField = "Text";
            lstPlatform.DataValueField = "Value";
            lstPlatform.DataBind();
            lstPlatform.Items.Insert(0, "");
            for (int i = 0; i < lstPlatform.Items.Count; i++)
            {

                lstPlatform.Items[i].Selected = true;
            }



        }

        public void BindList()
        {
            dynamic State, Accounts;
            
           
                State = (from x1 in unitOfwork.TblStatesRepository.Get().OrderBy(e => e.StateName)
                         select new
                         {
                             Text = x1.StateName,
                             Value = x1.State
                         }).ToList();
          
            
            lstState.DataSource = State;
            lstState.DataTextField = "Text";
            lstState.DataValueField = "Value";
            lstState.DataBind();
            lstState.Items.Insert(0,"");

            for (int i = 0; i < lstState.Items.Count; i++)
            {
                lstState.Items[i].Selected = true;
            }
 
                Accounts = (from x1 in unitOfwork.TblAccountListsRepository.Get().OrderBy(e => e.Company)
                         select new
                         {
                             Text = x1.Company,
                             Value = x1.AccountCode
                         }).ToList().Distinct(); 

            lstAccount.DataSource = Accounts;
            lstAccount.DataTextField = "Text";
            lstAccount.DataValueField = "Value";
            lstAccount.DataBind();


            for (int i = 0; i < lstAccount.Items.Count; i++)
            {
                lstAccount.Items[i].Selected = true;
            }


            dynamic AccountType, csnlist, Territory,  PrimaryDistributor; ;
          
                AccountType = (from x1 in unitOfwork.tblAccountTypesRepository.Get().OrderBy(e => e.TypeName)
                               select new
                               {
                                   Text = x1.TypeName,
                                   Value = x1.AccountTypeID
                               }).ToList();


                csnlist = (from x1 in unitOfwork.TblCSNListsRepository.Get().OrderBy(e => e.FirstName)
                           select new
                           {
                               Text = x1.FullName,
                               Value = x1.CSNID
                           }).ToList();


                Territory = (from x1 in unitOfwork.TblTerritoriesRepository.Get().OrderBy(e => e.TerrDesc)
                               select new
                               {
                                   Text = x1.TerrDesc,
                                   Value = x1.Territory
                               }).ToList(); 
            lstAccount2.DataSource = AccountType;
            lstAccount2.DataTextField = "Text";
            lstAccount2.DataValueField = "Value";
            lstAccount2.DataBind();
            

            for (int i = 0; i < lstAccount2.Items.Count; i++)
            {
                lstAccount2.Items[i].Selected = true;
            }

            lstCSN.DataSource = csnlist;
            lstCSN.DataTextField = "Text";
            lstCSN.DataValueField = "Value";
            lstCSN.DataBind();

            for (int i = 0; i < lstCSN.Items.Count; i++)
            {
                lstCSN.Items[i].Selected = true;
            }

            lstTerritory.DataSource = Territory;
            lstTerritory.DataTextField = "Text";
            lstTerritory.DataValueField = "Value";
            lstTerritory.DataBind();

            for (int i = 0; i < lstTerritory.Items.Count; i++)
            {
                lstTerritory.Items[i].Selected = true;
            }

        }
      
        private void BindReport()
        {           
            IList<TblContactMaster> values1;
            dynamic result;
            DataSet ds = new DataSet();
            string sAccoutList = String.Join(";", lstAccountType.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sStateList = String.Join(";", lstState.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());           
            string sPlatform = String.Join(";", lstPlatform.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            //string sAccount = String.Join(";", lstAccount.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sAccount2 = String.Join(";", lstAccount2.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sCSN = String.Join(";", lstCSN.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sTerritory = String.Join(";", lstTerritory.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sMassMail = String.Join(";", lstMassMail.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());

            string sAccount = String.Join(";", lstAccount.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray()); 

            clsReports obclsReports = new clsReports();
            ds = obclsReports.BuyersList(sAccoutList, sStateList, sPlatform, sAccount, sAccount2, sCSN, sTerritory, sMassMail);
            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]); 
            ReportViewer1.LocalReport.DataSources.Clear(); 
            ReportParameter[] rParam = new ReportParameter[chkColumnList.Items.Count]; 
            for (Int32 i = 0; i < chkColumnList.Items.Count; i++)
            {
                rParam[i] = new ReportParameter(chkColumnList.Items[i].Value, (chkColumnList.Items[i].Selected == true ? "True" : "false"));
            } 


            ReportViewer1.LocalReport.SetParameters(rParam);
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();


            
        }

        protected void lstAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic Accounts, AccountType;
            string pAccountType = String.Join(";", lstAccountType.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());

            if (pAccountType == "")
            {
                pAccountType = "Distributor"; 
            }

            if (pAccountType == "Distributor")
            {
               
                    Accounts = (from x1 in unitOfwork.TblAccountListsRepository.Get()
                                               .Where(e1 => e1.CustType1 == "Distributor").Distinct()
                                               .OrderBy(e1 => e1.Company)
                                select new
                                {
                                    Text = x1.Company,
                                    Value = x1.AccountCode
                                }).ToList().Distinct();

                    AccountType = (from x1 in unitOfwork.tblAccountTypesRepository.Get().OrderBy(e1 => e1.TypeName)
                                   where x1.AccountType == "Distributor"
                                   select new
                                   {
                                       Text = x1.TypeName,
                                       Value = x1.AccountTypeID
                                   }).ToList();
                }
         
            else  if (pAccountType == "Retailer") 
            {

                Accounts = (from x1 in unitOfwork.TblAccountListsRepository.Get().OrderBy(e1 => e1.Company).Distinct()
                                .Where(e1 => e1.CustType1 == "Retailer")
                                select new
                                {
                                    Text = x1.Company,
                                    Value = x1.AccountCode
                                }).ToList().Distinct();

                AccountType = (from x1 in unitOfwork.tblAccountTypesRepository.Get().OrderBy(e1 => e1.TypeName)
                                   where x1.AccountType == "Retailer"
                                   select new
                                   {
                                       Text = x1.TypeName,
                                       Value = x1.AccountTypeID
                                   }).ToList();

              

            }
            else  
            {
 
                    Accounts = (from x1 in unitOfwork.TblAccountListsRepository.Get().OrderBy(e1 => e1.Company).Distinct()
                                select new
                                {
                                    Text = x1.Company,
                                    Value = x1.AccountCode
                                }).ToList().Distinct();

                    AccountType = (from x1 in unitOfwork.tblAccountTypesRepository.Get().OrderBy(e1 => e1.TypeName)
                                 
                                   select new
                                   {
                                       Text = x1.TypeName,
                                       Value = x1.AccountTypeID
                                   }).ToList();


              

            }
            lstAccount.DataSource = Accounts;
            lstAccount.DataTextField = "Text";
            lstAccount.DataValueField = "Value";
            lstAccount.DataBind();


            for (int i = 0; i < lstAccount.Items.Count; i++)
            {

                lstAccount.Items[i].Selected = true;
            }

            lstAccount2.DataSource = AccountType;
            lstAccount2.DataTextField = "Text";
            lstAccount2.DataValueField = "Value";
            lstAccount2.DataBind();


            for (int i = 0; i < lstAccount2.Items.Count; i++)
            {
                lstAccount2.Items[i].Selected = true;
            }
             

              BindReport();

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindReport();
        }
    }
}