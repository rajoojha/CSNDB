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
    public class ManageContacts : DALBase
    {
        public DataSet getContactList(dynamic values)
        {
           DataSet ds = null;
           ds = GetDataSet("uspGetContactList"); 
           return ds;
        }

        /// <summary>
        /// Save the Record into DB.
        /// </summary>
        public DataSet saveBuyerline(string pEARecords, int ContactID)
        {
            DataSet ds = null; 
            SqlParameter[] param = new SqlParameter[2];
            AddParameter(param, "@XMLDoc", pEARecords);
            AddParameter(param, "@ContactID", ContactID);
            ds = GetDataSet("usp_BuyerLine", param);
            return ds;
        }

        public DataTable GetBuyerLine(string pContactId)
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            AddParameter(param, "@ContactId", pContactId);
            dt = GetDataTable("USP_getBuyersLine", param);
            return dt;
        }
    }
}
