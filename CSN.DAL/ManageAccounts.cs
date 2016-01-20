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
    public class ManageAccounts : DALBase
    {
        public DataSet getAccountList(dynamic values)
        {
           DataSet ds = null;
           ds = GetDataSet("uspGetAccountList"); 
           return ds;
        }

        public DataSet getAccounsDDL(int AccountCode, int CSNID)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[2];
            AddParameter(param, "@AccountCode", AccountCode);
            AddParameter(param, "@CSNID", CSNID);
            ds = GetDataSet("USP_Accounts_DDL",param);
            return ds;
        }


        public DataSet SaveAccountsList(dynamic pParameters)
        {
            DataSet ds = null;
            SqlParameter[] param = new SqlParameter[28];  
            AddParameter(param, "@pAccountCode", pParameters.AccountID);
            AddParameter(param, "@pCompanyName", pParameters.CompanyName);
            AddParameter(param, "@pCompanyPhone", pParameters.CompanyPhone);
            AddParameter(param, "@pCompanyExt", pParameters.CompanyExt);
            AddParameter(param, "@pCompanyFax", pParameters.CompanyFax);
            AddParameter(param, "@pDryOnly", pParameters.DryOnly);
            AddParameter(param, "@pFreezer", pParameters.Freezer);
            AddParameter(param, "@pFood", pParameters.Food);
            AddParameter(param, "@pAccountType1", pParameters.AccountType1);
            AddParameter(param, "@pPrimaryAcctCode", pParameters.PrimaryAcctCode);
            AddParameter(param, "@pNuberOfStores", pParameters.NuberOfStores);
            AddParameter(param, "@pAccountType2", pParameters.AccountType2);
            AddParameter(param, "@pTerritory", pParameters.Territory);
            AddParameter(param, "@pDivision", pParameters.Division);
            AddParameter(param, "@pCSNDirID", pParameters.CSNDirID); 
            AddParameter(param, "@pStatus", pParameters.Status);
            AddParameter(param, "@pAddress1", pParameters.Address1);
            AddParameter(param, "@pAddress2", pParameters.Address2);
            AddParameter(param, "@pCity", pParameters.City);
            AddParameter(param, "@pState", pParameters.State); 
            AddParameter(param, "@pZip", pParameters.Zip);
            AddParameter(param, "@pCountry", pParameters.Country);
            AddParameter(param, "@pShipToName", pParameters.ShipToName);
            AddParameter(param, "@pShipToAddress1", pParameters.ShipToAddress1);
            AddParameter(param, "@pShipToAddress2", pParameters.ShipToAddress2);
            AddParameter(param, "@pShipToCity", pParameters.ShipToCity);
            AddParameter(param, "@pShipToState", pParameters.ShipToState);
            AddParameter(param, "@pShipZip", pParameters.ShipZip);
             AddParameter(param, "@pShipToCountry", pParameters.ShipToCountry);

            ds = GetDataSet("USP_SAVE_Account", param);
            return ds;
        }
    }
}
