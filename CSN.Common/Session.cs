using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Configuration;

namespace CSN.Common
{
    #region About Class
    /*   Class Purpose : Class to manage Session for PBA application
         *   Created By : Rajoo Jha
         *   Created On : 08-Feb-2013
         *   Changed History :  
         *       Changes On / By : 
         *       Changes Details :    
        */

    #endregion


    /// <summary>
    ///  Class to Manage Session of PBA Application
    /// </summary>
    public class CSNSession
    {

        #region Public Properties

        /// <summary>
        /// SessionID for the Current Login User
        /// </summary>
        public static string SessionID
        {
            get
            {
                return HttpContext.Current.Session.SessionID;
            }
        }

        /// <summary>
        /// Get 8 Digit SAP Code  of current login user 
        /// </summary>
        public static string LoginID
        {
            get { return GetSessionValue("LoginID"); }
            set { }
        }

       
        public static string AuthCode
        {
            get
            {
                if (LoginID == "")
                {
                    return GetDomainAndLoginName("L");

                }
                else
                {
                    return LoginID;
                }
            }

        }

        /// <summary>
        /// Client IP Address
        /// </summary>
        public static string ClientIP
        {
            get { return HttpContext.Current.Request.UserHostAddress; }

        }

        /// <summary>
        /// Get Current Domain Name (for Ex: MyCSN.com)
        /// </summary>
        public static string DomainName
        {
            get { return GetDomainAndLoginName("D"); }

        }


        #endregion

        #region Public Methods

        /// <summary>
        /// Method to set a new session for login user. session values created for all the columns in the passed datarow
        /// </summary>
        /// <param name="pSessionValues"> Contains all session values in a data row</param>
        public static void SetSession(DataTable  pSessionValues)
        {

            DataRow pSessionKeys = pSessionValues.Rows[0];
            for (int iCounter = 0; iCounter < pSessionKeys.Table.Columns.Count; iCounter++)
            {
                /// Create session values for each column . key name is same as column name and key value is same as column value
                HttpContext.Current.Session[pSessionKeys.Table.Columns[iCounter].ColumnName] = pSessionKeys[iCounter].ToString();

            }
            /// Adding SiteRoot session key as site root is an additional key 
            HttpContext.Current.Session["SiteRoot"] = GetSiteRoot();


        }

        /// <summary>
        /// Function to get SessionValue for the passed key as enum 
        /// </summary>
        /// <param name="pSessionValue">A vaild enum value of eSessionValeType</param>
        /// <returns></returns>
        public static string GetSessionValue(eSessionValeType pSessionValue)
        {
            return GetSessionValue(pSessionValue.ToString());

        }
        /// <summary>
        ///  Function to get SessionValue for the passed key as string 
        /// </summary>
        /// <param name="pSessionValue">A valid session key in string format</param>
        /// <returns></returns>
        public static string GetSessionValue(string pSessionValue)
        {
           
            if (HttpContext.Current.Session[pSessionValue] != null)
                return HttpContext.Current.Session[pSessionValue].ToString();
            else
                return "";
        }

        /// <summary>
        /// Method to get site root( Contains protocol + IP/DomainName + Virtual Name )
        /// </summary>
        /// <returns></returns>
        public static string GetSiteRoot()
        {
             return System.Web.HttpContext.Current.Request.ApplicationPath;
        }

        /// <summary>
        /// Method to get Auth User or Domain Name based on the parameter value
        /// </summary>
        /// <param name="Type"></param>
        /// <returns>D for Domain & L for AuthCode</returns>
        private static string GetDomainAndLoginName(string Type)
        {
            string[] strLoginName;
            string strLogin = "";
            strLoginName = System.Web.HttpContext.Current.User.Identity.Name.Split('\\');
            if (strLoginName.Length == 0)
            {
                strLoginName = System.Web.HttpContext.Current.User.Identity.Name.Split('/');
            }
            if (Type == "L")
                strLogin = strLoginName[strLoginName.Length - 1];
            else if (Type == "D")
                strLogin = strLoginName[strLoginName.Length - 2];
            return strLogin;
        }

        /// <summary>
        /// Method to get Session Values for Client Side Access . Values concatinated in a string in form of Key=Value pair and seprated with |
        /// </summary>
        /// <returns></returns>
        public static string GetSessionValueForJS()
        {
            try
            {

                if (HttpContext.Current.Session["IsAuthUser"].ToString() == "N")
                    throw new Exception();


                StringBuilder _sessionValues;
                _sessionValues = new StringBuilder();


                string[] arrSessionValuesForJS = new string[] { "LoginID", "SiteRoot", "Rights", "LoginIDOnBehalf", "RightsSource", "AccessType","OrgUnit_ParentCode"};



                for (int iCounter = 0; iCounter < arrSessionValuesForJS.Length; iCounter++)
                {
                    _sessionValues.Append(arrSessionValuesForJS[iCounter] + "=" + HttpContext.Current.Session[arrSessionValuesForJS[iCounter]].ToString());
                    _sessionValues.Append("|");

                }
                _sessionValues.Append("ID=" + HttpContext.Current.Session.SessionID);

                return _sessionValues.ToString();

            }
            catch (Exception ex)
            {
                ///HttpContext.Current.Response.Redirect("\\" + ConfigurationSettings.AppSettings["App_VirtualName"].ToString() + "\\Common\\SessionExpired.aspx");
                return "";
            }
        }
        #endregion

    }

    /// <summary>
    /// enum for Session keys 
    /// </summary>
    public enum eSessionValeType
    {
        LoginID,
        CSNID,
        LoginName,
        HomeURL,
        SiteRoot,
	    Access,
	    AccessType,
	    AccessOn,
        IsAuthUser
    }

}
