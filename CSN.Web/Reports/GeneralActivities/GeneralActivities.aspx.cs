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
using System.Dynamic;
using CSN.Business;

namespace CSNApplication.Reports.GeneralActivities
{
    public partial class GeneralActivities : System.Web.UI.Page
    {
        UnitOfWork unitOfwork = new UnitOfWork();
        dynamic State, CSNRep, PrincipalList, Accounts, InitResults, InitiativeDesc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 0; i < chkColumnList.Items.Count; i++)
                {
                    chkColumnList.Items[i].Selected = true;
                }
                BindList();
                BindReport();


            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {

            BindReport();
        }
        public void BindList()
        { 
                int pCSNID = Convert.ToInt32(Session["CSNID"].ToString());
                if (Session["RoleId"].ToString() == "1" || Session["RoleId"].ToString() == "28")
                {
                    CSNRep = (from x1 in unitOfwork.TblCSNListsRepository.Get().OrderBy(e => e.FullName)
                              select new
                              {
                                  Text = x1.FullName,
                                  Value = x1.CSNID
                              }).ToList();
                }
                else
                {
                    CSNRep = (from x1 in unitOfwork.TblCSNListsRepository.Get().OrderBy(e => e.FullName)
                              .Where(e => e.CSNID == pCSNID)
                              select new
                              {
                                  Text = x1.FullName,
                                  Value = x1.CSNID
                              }).ToList();
                }
                lstCSNRep.DataSource = CSNRep;
                lstCSNRep.DataTextField = "Text";
                lstCSNRep.DataValueField = "Value";
                lstCSNRep.DataBind();
                for (int i = 0; i < lstCSNRep.Items.Count; i++)
                {

                    lstCSNRep.Items[i].Selected = true;
                }
                InitiativeDesc = (from x1 in unitOfwork.TblInitiativeListsRepository.Get() 
                                  select new
                                  {
                                      Text = x1.InitiativeLabel,
                                      Value = x1.InitiativeID,
                                      ToolTip = x1.InitiativeDesc,
                                  }).ToList().OrderBy(d => d.Text);

                if (Session["RoleId"].ToString() == "1" || Session["RoleId"].ToString() == "28")
                {

                    PrincipalList = (from x1 in unitOfwork.TblMfgsRepository.Get().OrderBy(e => e.MfgID)
                                                         select new
                                                         {
                                                             Text = x1.MfgName,
                                                             Value = x1.MfgID
                                                         }).ToList(); 

                    string sCSNID = String.Join(",", lstCSNRep.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
                    dynamic obj2 = new ExpandoObject();
                    obj2.CSNID = sCSNID;

                    InitiativeDetails details = new InitiativeDetails();
                    DataSet dsPeriod = details.GetMasterValues(obj2);
                    dsPeriod.Tables[0].TableName = "Principal";

                    DataTable dtPrincipal = dsPeriod.Tables[0];
                    DataTable dtAccount = dsPeriod.Tables[1];
                    //PrincipalList = from s in dtPrincipal.AsEnumerable()
                    //                select new { Text = s["MfgName"], Value = s["MfgId"] };

                }
                else
                {
                    dynamic obj2 = new ExpandoObject();
                    obj2.CSNID = pCSNID;

                    InitiativeDetails details = new InitiativeDetails();
                    DataSet dsPeriod = details.GetMasterValues(obj2);
                    dsPeriod.Tables[0].TableName = "Principal";

                    DataTable dtPrincipal = dsPeriod.Tables[0];
                    DataTable dtAccount = dsPeriod.Tables[1];
                    PrincipalList = (from x1 in unitOfwork.TblMfgsRepository.Get().OrderBy(e => e.MfgID)
                                     select new
                                     {
                                         Text = x1.MfgName,
                                         Value = x1.MfgID
                                     }).ToList(); 


                }


                if (Session["RoleId"].ToString() == "1" || Session["RoleId"].ToString() == "28")
                {
                    Accounts = (from x1 in unitOfwork.TblAccountListsRepository.Get().OrderBy(e => e.Company)
                                select new
                                {
                                    Text = x1.Company,
                                    Value = x1.AccountCode
                                }).ToList();
                }
                else
                {
                    Accounts = (from x1 in unitOfwork.TblAccountListsRepository.Get().OrderBy(e => e.Company)
                                    .Where(e => e.CSNDirID == pCSNID)
                                select new
                                {
                                    Text = x1.Company,
                                    Value = x1.AccountCode
                                }).ToList();
                }

                InitResults = (from x1 in unitOfwork.TblpkInitResultsRepository.Get().Where(e => e.ResponseType == 1 && e.Category == 1 && e.InitResultID != 19)
                                 .OrderBy(e => e.InitResultID)
                               select new
                               {
                                   Text = x1.AccountType + " -" + x1.Response,
                                   Value = x1.InitResultID
                               }).ToList(); 
            
            lstAccount.DataSource = Accounts;
            lstAccount.DataTextField = "Text";
            lstAccount.DataValueField = "Value";
            lstAccount.DataBind();
            for (int i = 0; i < lstAccount.Items.Count; i++)
            {

                lstAccount.Items[i].Selected = true;
            }



            lstPrincipal.DataSource = PrincipalList;
            lstPrincipal.DataTextField = "Text";
            lstPrincipal.DataValueField = "Value";
            lstPrincipal.DataBind();
            for (int i = 0; i < lstPrincipal.Items.Count; i++)
            {

                lstPrincipal.Items[i].Selected = true;
            }


            lstInitiativeResult.DataSource = InitResults;
            lstInitiativeResult.DataTextField = "Text";
            lstInitiativeResult.DataValueField = "Value";
            lstInitiativeResult.DataBind();
            for (int i = 0; i < lstInitiativeResult.Items.Count; i++)
            {

                lstInitiativeResult.Items[i].Selected = true;
            }

        }

        private void BindReport()
        {


            string pCSNID = String.Join(";", lstCSNRep.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string pAccount = String.Join(";", lstAccount.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string pPrincipal = String.Join(";", lstPrincipal.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string pInitiativeResult = String.Join(";", lstInitiativeResult.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            
            IList<TblCSNList> values1;

            dynamic result;

            DataSet ds = new DataSet();
            clsReports obclsReports = new clsReports();

            dynamic obj2 = new ExpandoObject();
            obj2.CSNID = pCSNID;
            obj2.MfgID = pPrincipal;
            obj2.AccountID = pAccount;
            obj2.InitResultsID = pInitiativeResult;
           

            ds = obclsReports.RPT_GeneralActivities(obj2);

            ReportDataSource rds = new ReportDataSource("DataSet1", ds.Tables[0]);
            ReportViewer1.LocalReport.DataSources.Clear();

            ReportParameter[] rParam = new ReportParameter[chkColumnList.Items.Count + 1];

            for (Int32 i = 0; i < chkColumnList.Items.Count + 1; i++)
            {
                if (i == chkColumnList.Items.Count)
                {
                    rParam[i] = new ReportParameter("ReportHeader", "");
                }
                else
                {

                    rParam[i] = new ReportParameter(chkColumnList.Items[i].Value, (chkColumnList.Items[i].Selected == true ? "True" : "false"));
                }
            }

          
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();

        }

        protected void lstCSNRep_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        protected void lstInitiativeEntryStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reports();

        }

        protected void lstCSNRep_TextChanged(object sender, EventArgs e)
        {
            Reports();
        }


        public void Reports()
        {


            BindReport();

        }

      
    }
}