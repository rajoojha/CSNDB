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
    public class ManageInitiative : DALBase
    {

        public DataSet getInitiative(dynamic values)
        {
            DataSet ds = null;
            ds = GetDataSet("UspInitiativeList");
            return ds;
        }


        public DataSet getInitiativeResult(dynamic values)
        {
            DataSet ds = null;
            ds = GetDataSet("uspGetInitiativeResults");
            return ds;
        }


        public DataSet InitiativeEntryList(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[2];
            AddParameter(param, "@CSNID", pvalues.CSNID);
            AddParameter(param, "@MfgID", pvalues.MfgID);
            ds = GetDataSet("USP_InitiativeEntryList", param);
            return ds;
        }

        public DataSet InitiativeEntryListSearch(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[6];
            AddParameter(param, "@CSNID", pvalues.CSNID);
            AddParameter(param, "@MfgID", pvalues.MfgID);
            AddParameter(param, "@AccountID", pvalues.AccountID);
            AddParameter(param, "@InitStatus", pvalues.InitStatus);
            AddParameter(param, "@PageSize", pvalues.PageSize);
            AddParameter(param, "@PageNumber", pvalues.PageNumber);
            // AddParameter(param, "@InitResultsID", pvalues.InitResultsID);
            ds = GetDataSet("USP_InitiativeEntryListSearch", param);
            return ds;
        }

        public DataSet InitiativeMasterValues(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[1];
            AddParameter(param, "@CSNID", pvalues.CSNID);
            ds = GetDataSet("USP_InitiativeEntryMasterSearch", param);
            return ds;
        }

        public DataSet InitiativeByID(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[2];
            AddParameter(param, "@InitiativeID", pvalues.InitiativeID);
            AddParameter(param, "@ContactID", pvalues.ContactID);
            ds = GetDataSet("USP_InitiativeByID", param);
            return ds;
        }
        public DataSet PROC_Mfg_CSN_Account_Buyers(dynamic pvalues)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[2];
            AddParameter(param, "@CSNID", pvalues.CSNID);
            AddParameter(param, "@MfgID", pvalues.MfgID);
            ds = GetDataSet("PROC_Mfg_CSN_Account_Buyers", param);
            return ds;
        }  
    }
}
