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
namespace CSNApplication.Reports.EMPLOYEE
{
    public partial class WebForm1 : System.Web.UI.Page
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
                BindTerritory();
                BindState();
                BindReport();
            }
        }
        public void BindState()
        {
            dynamic State;

            State = (from x1 in unitOfwork.TblStatesRepository.Get() 
                             orderby x1.StateName
                             select new
                             {
                                 Text = x1.StateName,
                                 Value = x1.State
                             }).ToList();
            

            lstState.DataSource = State;
            lstState.DataTextField = "Text";
            lstState.DataValueField = "Value";
            lstState.DataBind();
            lstState.Items.Insert(0, " ");
            for (int i = 0; i < lstState.Items.Count; i++)
            {

                lstState.Items[i].Selected = true;
            }

        }
        public void BindTerritory()
        {


            dynamic Territory;
             

                Territory = (from x1 in unitOfwork.TblTerritoriesRepository.Get()
                             where x1.ParentId!="0"
                             orderby x1.OrderBy                                
                             select new
                             {
                                 Text = x1.TerrDesc,
                                 Value = x1.Territory
                             }).ToList();

           

            lstTerritory.DataSource = Territory;
            lstTerritory.DataTextField = "Text";
            lstTerritory.DataValueField = "Value";
            lstTerritory.DataBind();
            lstTerritory.Items.Insert(0," ");
            for (int i = 0; i < lstTerritory.Items.Count; i++)
            {

                lstTerritory.Items[i].Selected = true;
            }



        }
        private void BindReport()
        {
           // string values = String.Join(", ", ddlCaption.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string values = String.Join(",", ddlCaption.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string vTerritory = String.Join(";", lstTerritory.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string vState = String.Join(",", lstState.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            string[] sval = (ddlCaption.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            IList<TblCSNList> values1; 
            dynamic result;
            DataSet ds = new DataSet();
            clsReports obclsReports = new clsReports();
            ds = obclsReports.CSNList(values, vTerritory,vState); 
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
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindReport();
        }
    }
}