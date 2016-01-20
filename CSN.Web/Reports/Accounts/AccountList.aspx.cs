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
namespace CSNApplication.Reports.Accounts
{
    public partial class AccountList : System.Web.UI.Page
    {
        UnitOfWork unitOfwork = new UnitOfWork();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTerritory();
                for (int i = 0; i < chkColumnList.Items.Count; i++)
                {
                    chkColumnList.Items[i].Selected = true;
                }
                BindList();
                BindAccount2();
                BindPlatform();
                BindReport();
            
            }
        }

        protected void lstAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pAccountType = String.Join(";", lstAccountType.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());

            if (pAccountType == "")
            {
                pAccountType = "Distributor";
            }

            if (pAccountType == "Distributor")
            {
                lstPrimaryDistributor.Visible = false;
               
            }
            else
            {
                lstPrimaryDistributor.Visible = true;  
            }

                 BindReport();

        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindReport();
        }

        public void BindAccount2()
        {
            string pAccountType1 = string.Empty;
            dynamic AccountType;
           
                pAccountType1 = lstAccountType.SelectedValue; 

                if (pAccountType1 == "")
                {
                    pAccountType1 = "Distributor";
                } 
                AccountType = (from x1 in unitOfwork.tblAccountTypesRepository.Get().OrderBy(e => e.TypeName)
                               select new
                               {
                                   Text = x1.TypeName,
                                   Value = x1.AccountTypeID
                               }).ToList();
 

            lstAccount2.DataSource = AccountType;
            lstAccount2.DataTextField = "Text";
            lstAccount2.DataValueField = "Value";
            lstAccount2.DataBind();
            lstAccount2.Items.Insert(0, " ");
            for (int i = 0; i < lstAccount2.Items.Count; i++)
            {

                lstAccount2.Items[i].Selected = true;
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
            lstPlatform.Items.Insert(0, " ");
            for (int i = 0; i < lstPlatform.Items.Count; i++)
            {

                lstPlatform.Items[i].Selected = true;
            }



        }

        public void BindList()
        {
            dynamic State, CSNRep, PrimaryDistributor;

            State = (from x1 in unitOfwork.TblStatesRepository.Get().OrderBy(e => e.StateName)
                            select new
                            {
                                Text = x1.StateName,
                                Value = x1.State
                            }).ToList();

                CSNRep = (from x1 in unitOfwork.TblCSNListsRepository.Get().OrderBy(e => e.FullName)
                         select new
                         {
                             Text = x1.FullName,
                             Value = x1.CSNID
                         }).ToList(); 
                      PrimaryDistributor = (from x1 in unitOfwork.TblAccountListsRepository.Get()
                                              .Where(e1 => e1.CustType1 == "Distributor")
                                              .OrderBy(e1 => e1.Company)
                                              select new
                                              {
                                                  Text = x1.Company,
                                                  Value = x1.AccountCode
                                              }).ToList(); 
            lstCSNRep.DataSource = CSNRep;
            lstCSNRep.DataTextField = "Text";
            lstCSNRep.DataValueField = "Value";
            lstCSNRep.DataBind();
            for (int i = 0; i < lstCSNRep.Items.Count; i++)
            {         
                lstCSNRep.Items[i].Selected = true;
            }



            lstPrimaryDistributor.DataSource = PrimaryDistributor;
            lstPrimaryDistributor.DataTextField = "Text";
            lstPrimaryDistributor.DataValueField = "Value";
            lstPrimaryDistributor.DataBind();
            for (int i = 0; i < lstPrimaryDistributor.Items.Count; i++)
            {
                lstPrimaryDistributor.Items[i].Selected = true;
            }


            lstState.DataSource =State ;
            lstState.DataTextField = "Text";
            lstState.DataValueField = "Value";
            lstState.DataBind();
            for (int i = 0; i < lstState.Items.Count; i++)
            {
                lstState.Items[i].Selected = true;
            }
        }
        public void BindTerritory()
        {
            dynamic Territory1;

            Territory1 = (from x1 in unitOfwork.TblTerritoriesRepository.Get().OrderBy(e => e.OrderBy)
                             where x1.ParentId != "0"
                             orderby x1.OrderBy
                             select new
                             {
                                 Text = x1.TerrDesc,
                                 Value = x1.Territory
                             }).ToList();

           
            lstTerritory.DataSource = Territory1;
            lstTerritory.DataTextField = "Text";
            lstTerritory.DataValueField = "Value";
            lstTerritory.DataBind();
            lstTerritory.Items.Insert(0, " ");
            for (int i = 0; i < lstTerritory.Items.Count; i++)
            {

                lstTerritory.Items[i].Selected = true;
            }



        }
      
        private void BindReport()
        {   
            string sAccoutList = String.Join(";", lstAccountType.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sAccount2 = String.Join(";", lstAccount2.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sStateList = String.Join(";", lstState.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sCSNRepList = String.Join(";", lstCSNRep.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sTerritory = String.Join(";", lstTerritory.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string sPlatform = String.Join(";", lstPlatform.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());

            string sPrimaryDist = String.Join(";", lstPrimaryDistributor.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray()); 

            IList<vwAccountList> values1;
            dynamic result; 
            DataSet ds = new DataSet();
            clsReports obclsReports = new clsReports();
            ds = obclsReports.RptAccountList(sAccoutList, sAccount2, sStateList, sCSNRepList, sTerritory, sPlatform, sPrimaryDist);
            ReportDataSource rds = new ReportDataSource("dsAccountList", ds.Tables[0]);
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
    }
}