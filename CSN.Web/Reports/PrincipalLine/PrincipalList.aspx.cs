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
    public partial class PrincipalList : System.Web.UI.Page
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
                BindTerritory();
                BindReport();
        


            }
        }

        public void BindPlatform()
        {
            dynamic Platform, Prinicpal;
            
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
            for (int i = 0; i < lstPlatform.Items.Count; i++)
            {

                lstPlatform.Items[i].Selected = true;
            }



        }

        public void BindTerritory()
        {
            dynamic Territory; 

            Territory = (from x1 in unitOfwork.TblTerritoriesRepository.Get().OrderBy(e => e.OrderBy)
                            select new
                            {
                                Text = x1.TerrDesc,
                                Value = x1.Territory
                            }).ToList(); 

            lstTerritory.DataSource = Territory;
            lstTerritory.DataTextField = "Text";
            lstTerritory.DataValueField = "Value";
            lstTerritory.DataBind();
            for (int i = 0; i < lstTerritory.Items.Count; i++)
            {

                lstTerritory.Items[i].Selected = true;
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
        #region Generae Report

        private void RenderRDLCReport<T>(List<T> objList, string reportFileName, LocalReport localReport)
        {
            string DataSetName = String.Empty;
            DataSetName = "DataSet1";

            ReportDataSource reportDataSource = new ReportDataSource(DataSetName, objList);
            localReport.DataSources.Add(reportDataSource);

            var reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http://msdn2.microsoft.com/en-us/library/ms155397.aspx
            string deviceInfo =
            "<DeviceInfo>" +
            " <OutputFormat>PDF</OutputFormat>" +
            " <PageWidth>11in</PageWidth>" +
            " <PageHeight>8.5in</PageHeight>" +
            " <MarginTop>0.5in</MarginTop>" +
            " <MarginLeft>1in</MarginLeft>" +
            " <MarginRight>1in</MarginRight>" +
            " <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            var renderedBytes = localReport.Render(
                                reportType,
                                deviceInfo,
                                out mimeType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings);

            //Clear the response stream and write the bytes to the outputstream
            //Set content-disposition to "attachment" so that user is prompted to take an action
            //on the file (open or save)
            Response.Clear();
            Response.ContentType = mimeType;

            Response.BinaryWrite(renderedBytes);
            Response.End();
        }

        #endregion 
        private void BindReport()
        {
           string values11 = String.Join(";", lstPrincipal.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray()); 
           string vDry = String.Join(";", lstDry.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray()); 
           string vRef = String.Join(";", lstRef.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
           string vFrozen = String.Join(";", lstFrozen.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
           string vDotFoods = String.Join(";", lstDotFoods.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
           string vPlatform = String.Join(";", lstPlatform.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
           string vTerritory = String.Join(";", lstTerritory.Items.Cast<ListItem>().Where(i => i.Selected).Select(i => i.Value).ToArray());
            
            IList<TblCSNList> values1;        
            dynamic result;

            DataSet ds = new DataSet();
            clsReports  obclsReports = new clsReports();
            ds = obclsReports.MfgPrincipalList(values11, vDry, vRef, vFrozen, vDotFoods, vPlatform, vTerritory);



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
          
            ///////



            
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            BindReport();
        }
    }
}