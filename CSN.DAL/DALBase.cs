//////////////////////////////////////////
/////////File Created BY Aman Arora(51341005) on 19-Nov-2010 For Database Access
//////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data; 
using System.Data.SqlClient;
using System.Configuration;
using System.Xml;
using CSN.Common;
using CSN.DAL;
using System.Data.EntityClient;
namespace CSN.DAL
{
    public class DALBase
    {
        private static string strConnection;

        public DALBase()
        {
            _ParameterCount = 0;
            _DefaultParmeterCount =0;
        }
        private int _ParameterCount;

        protected int _DefaultParmeterCount;

        private void InitParameters(SqlParameter[] pPrameterCollection)
        {

          /*  pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_LoginID", CSNSession.LoginID);
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_LoginIDOnBehalf", CSNSession.GetSessionValue(eSessionValeType.LoginIDOnBehalf));
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSessionID", CSNSession.SessionID);
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_Period", CSNSession.GetSessionValue(eSessionValeType.Period));
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_OrgUnitCode",CSNSession.GetSessionValue(eSessionValeType.OrgUnitCode));
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_OrgUnitLevelID",CSNSession.GetSessionValue(eSessionValeType.OrgUnitLevelID) );
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_PD_OrgUnitCode", CSNSession.GetSessionValue(eSessionValeType.PD_OrgUnitCode));
            pPrameterCollection[_ParameterCount++] = new SqlParameter("@pSession_PD_OrgUnitLevelID", CSNSession.GetSessionValue(eSessionValeType.PD_OrgUnitLevelID));
           */

        }

        public void AddParameter(SqlParameter[] pPrameterCollection, string pPrameterName, object pParameterValue,bool pIsDefaultParametersRequired)
        {
            if (_ParameterCount == 0 && pIsDefaultParametersRequired==true)
                InitParameters(pPrameterCollection);

            pPrameterCollection[_ParameterCount++] = new SqlParameter(pPrameterName, pParameterValue);

        }

        public void AddParameter(SqlParameter[] pPrameterCollection,string pPrameterName, object pParameterValue)
        {
            if (_ParameterCount == 0)
                InitParameters(pPrameterCollection);

            pPrameterCollection[_ParameterCount++] = new SqlParameter(pPrameterName, pParameterValue);
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetConnString()
        {
            if (string.IsNullOrEmpty(strConnection))
            {
                string providerString = ConfigurationManager.ConnectionStrings["CSNDBEntities"].ConnectionString; 
                EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder(providerString);
                strConnection = entityBuilder.ProviderConnectionString;

              
            }
            return strConnection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        public static void ExecuteStatement(string strCommandName)
        {
           SqlHelper.ExecuteNonQuery(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName);
         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <param name="sqlParams"></param>
        public static void ExecuteStatement(string strCommandName, SqlParameter[] dbParams)
        {
            SqlHelper.ExecuteNonQuery(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName, dbParams);
         
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strCommandName)
        {
            return SqlHelper.ExecuteDataset(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string strCommandName, SqlParameter[] sqlParams)
        {
            
                return  SqlHelper.ExecuteDataset(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName, sqlParams);
                
     
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strCommandName)
        {

            return SqlHelper.ExecuteDataset(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName).Tables[0];
                

        }
        /// <summary>
        /// .
        /// </summary>
        /// <param name="strCommandName"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string strCommandName, SqlParameter[] sqlParams)
        {
          return SqlHelper.ExecuteDataset(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName, sqlParams).Tables[0];
        
        }

        public static  void LOGException(Exception pEx,string pLoginID)
        {
            return;
        }

        public static string GetJSONString(string strCommandName, SqlParameter[] sqlParams)
        {
            DataSet dsResult = SqlHelper.ExecuteDataset(GetConnString(), System.Data.CommandType.StoredProcedure, strCommandName, sqlParams);
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml(dsResult.GetXml());

            return XMLToJOSN.Convert(Doc);

        }

     



    }
}
