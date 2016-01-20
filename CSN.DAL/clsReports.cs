using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Dynamic;
using System.Data.SqlClient;
using CSN.Common;

namespace CSN.DAL
{
    public class clsReports : DALBase
    {
        public DataSet MfgPrincipalContactList(string pvalues)
       {
           DataSet ds = null;
           SqlParameter[] param = new SqlParameter[1];
           AddParameter(param, "@MfgID", pvalues);
        
           ds = GetDataSet("Usp_Rpt_MfgContact", param);
           return ds;
       }


        public DataSet MfgPrincipalList(string pvalues, string vDry, string vRef, string vFrozen, string vDotFoods, string vPlatform, string vTerritory)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[7];
            AddParameter(param, "@MfgID", pvalues);
            AddParameter(param, "@pDry", vDry);
            AddParameter(param, "@pRef", vRef);
            AddParameter(param, "@pFrozen", vFrozen);
            AddParameter(param, "@pDotFoods", vDotFoods);
            AddParameter(param, "@pPlatform", vPlatform);
            AddParameter(param, "@pTerritory", vTerritory); 
            ds = GetDataSet("USP_RPT_PrincipalList", param);
            return ds;
        }


        public DataSet RptAccountList(string CustType1, string CustType2, string State, string CSNID, string Territory, string sPlatform, string pPrimDist)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[7];
            AddParameter(param, "@pCustType1", CustType1);
            AddParameter(param, "@pCustType2", CustType2);
            AddParameter(param, "@pState", State);
            AddParameter(param, "@pCSNID", CSNID);
            AddParameter(param, "@pTerritory", Territory); 
           AddParameter(param, "@pPlatform", sPlatform);
           AddParameter(param, "@pPrimDist", pPrimDist);

           ds = GetDataSet("USP_RPT_AccountList_Test", param);
            return ds;
        }


        public DataSet CSNList(string pvalues, string vTerritory, string vState)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[3];
            AddParameter(param, "@Dept", pvalues); 
            AddParameter(param, "@pTerritory", vTerritory);
            AddParameter(param, "@State", vState);
            ds = GetDataSet("rptCSNList", param);
            return ds;
        }

        public DataSet BuyersList(string CustType1, string State, string sPlatform, string sAccount, string sAccount2, string sCSN, string sTerritory, string sMassMail)
        {
            DataSet ds = null; 
            SqlParameter[] param = new SqlParameter[7];
           // AddParameter(param, "@pCustType1", CustType1); 
            AddParameter(param, "@pState", State); 
            AddParameter(param, "@pPlatform", sPlatform);
            AddParameter(param, "@pAccount", sAccount);
            AddParameter(param, "@pAccount2", sAccount2);
            AddParameter(param, "@pCSNRep", sCSN);
            AddParameter(param, "@pTerritory", sTerritory);
            AddParameter(param, "@pMassMail", sMassMail); 
            ds = GetDataSet("USP_RPT_BuyersList", param);
            return ds;
        }


        public DataSet RPT_InitiativeResults(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[7];
            AddParameter(param, "@CSNID", pvalues.CSNID);
            AddParameter(param, "@MfgID", pvalues.MfgID);
            AddParameter(param, "@AccountID", pvalues.AccountID);
            AddParameter(param, "@InitResultsID", pvalues.InitResultsID);
            AddParameter(param, "@InitID", pvalues.InitID);
            AddParameter(param, "@InitStatus", pvalues.InitStatus);
            AddParameter(param, "@InitEntryStatus", pvalues.InitEntryStatus);
            ds = GetDataSet("RPT_InitiativeResults", param);
            return ds;
        }

        public DataSet RPT_GeneralActivities(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[4];
            AddParameter(param, "@CSNID", pvalues.CSNID);
            AddParameter(param, "@MfgID", pvalues.MfgID);
            AddParameter(param, "@AccountID", pvalues.AccountID);
            AddParameter(param, "@InitResultsID", pvalues.InitResultsID); 
            ds = GetDataSet("RPT_GeneralActivities", param);
            return ds;
        }


        
    }
}
