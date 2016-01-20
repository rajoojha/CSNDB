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

namespace CSNApplication.Reports.PrincipalLine
{
    public partial class MfgContactList : System.Web.UI.Page
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
                BindReport();
            }
        }
        public void BindList()
        {
            dynamic Platform, Prinicpal;
           

                Prinicpal = (from x1 in unitOfwork.TblMfgsRepository.Get().OrderBy(e => e.MfgName)
                          select new
                          {
                              Text = x1.MfgName,
                              Value = x1.MfgID
                          }).ToList();

       

            lstPrincipal.DataSource = Prinicpal;
            lstPrincipal.DataTextField = "Text";
            lstPrincipal.DataValueField = "Value";
            lstPrincipal.DataBind();
            for (int i = 0; i < lstPrincipal.Items.Count; i++)
            {

                lstPrincipal.Items[i].Selected = true;
            }


            
        }
      
        private void BindReport()
        {
           string values11 = String.Join(";", lstPrincipal.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
        //   string vPlatform = String.Join(";", lstPlatform.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
        //   values11 = values11.Insert(0, "'");
          // values11 = values11.Insert(values11.Length, "'");
           // string[] sval = (lstPrincipal.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
          //  string sval11 = (lstState.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToString());
            IList<TblCSNList> values1;
        
            dynamic result;

            DataSet ds = new DataSet();
            clsReports  obclsReports = new clsReports();
            ds = obclsReports.MfgPrincipalContactList(values11);



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