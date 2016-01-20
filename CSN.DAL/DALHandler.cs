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
using CSN.DAL;
namespace ML.DAL
{
    public class DALHandler
    {
        private static string strConnection;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetConnString()
        {
            if (string.IsNullOrEmpty(strConnection))
            {
                strConnection = ConfigurationManager.ConnectionStrings["MLConn"].ConnectionString;
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
