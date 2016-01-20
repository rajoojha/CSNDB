using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using CSN.DAL;

namespace CSN.Business 
{
    public class InitiativeDetails 
    { 
        /// <summary>
        /// Get The Required Data to Initiative List.
        /// </summary>
        public DataSet getInitiativeList(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.getInitiative(values);
        }

        /// <summary>
        /// Get The Required Data to Initiative  Result List.
        /// </summary>
        public DataSet getInitiativeResult(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.getInitiativeResult(values);
        }

        public DataSet InitiativeEntryList(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.InitiativeEntryList(values);
        }
        public DataSet InitiativeEntryListsSearch(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.InitiativeEntryListSearch(values);
        }

        public DataSet GetMasterValues(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.InitiativeMasterValues(values);
        }

        public DataSet InitiativeByID(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.InitiativeByID(values);
        }

        public DataSet PROC_Mfg_CSN_Account_Buyers(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.PROC_Mfg_CSN_Account_Buyers(values);
        }
    }
}