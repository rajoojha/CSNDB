//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSN.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLCSNRoleAccess
    {
        public int CSNRoleAccessID { get; set; }
        public Nullable<int> CSNID { get; set; }
        public Nullable<bool> IncludeInStats { get; set; }
        public Nullable<bool> IncludeInReports { get; set; }
        public Nullable<bool> IncludeAllRepAccounts { get; set; }
        public Nullable<bool> AllowCasualAcctMaintenance { get; set; }
        public Nullable<bool> AllowDetailedAcctMaintenance { get; set; }
        public Nullable<bool> AllowAdminAccMaintenance { get; set; }
        public Nullable<bool> AllowInitiativeMaintenance { get; set; }
        public Nullable<bool> AllowRepMaintenance { get; set; }
        public Nullable<bool> AllowGenActivityMaintenance { get; set; }
        public Nullable<bool> AllowAcctStatusMaintenance { get; set; }
        public Nullable<bool> AllowCasualMfgMaintenance { get; set; }
        public Nullable<bool> AllowDetailedMfgMaintenance { get; set; }
        public Nullable<bool> AllowSurveyMaintenance { get; set; }
        public Nullable<bool> AllowDatabaseAudit { get; set; }
        public Nullable<bool> AllowRawDataCorrections { get; set; }
        public Nullable<bool> AllowInitiativeDataEntry { get; set; }
        public Nullable<bool> AllowGenActivityDataEntry { get; set; }
        public Nullable<bool> AllowAcctStatusDataEntry { get; set; }
        public Nullable<bool> AllowSurveyDataEntry { get; set; }
        public Nullable<bool> AllowInitiativeReview { get; set; }
        public Nullable<bool> AllowGenActivityReview { get; set; }
        public Nullable<bool> AllowAcctStatusReview { get; set; }
        public Nullable<bool> AllowSurveyReview { get; set; }
        public Nullable<bool> AllowInitiativeReports { get; set; }
        public Nullable<bool> AllowGenActivityReports { get; set; }
        public Nullable<bool> AllowAcctStatusReports { get; set; }
        public Nullable<bool> AllowSurveyReports { get; set; }
        public Nullable<bool> AllowBuyersLists { get; set; }
        public Nullable<bool> AllowContactLists { get; set; }
        public Nullable<bool> AllowAccountLists { get; set; }
    }
}