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
    
    public partial class TblGeneralActivitie
    {
        public int ActivityItemCode { get; set; }
        public Nullable<int> ContactID { get; set; }
        public string MfgId { get; set; }
        public string PlatformID { get; set; }
        public Nullable<System.DateTime> ActivityDate { get; set; }
        public string ActivityTitle { get; set; }
        public Nullable<System.DateTime> FollowupDate { get; set; }
        public string ActivityDesc { get; set; }
        public string ActivityComments { get; set; }
        public Nullable<int> CSNID { get; set; }
        public Nullable<int> AccountId { get; set; }
        public int InitResultID { get; set; }
        public bool DeleteFlag { get; set; }
    
        public virtual TblMfg TblMfg { get; set; }
        public virtual TblPlatform TblPlatform { get; set; }
        public virtual TblAccountList TblAccountList { get; set; }
        public virtual TblCSNList TblCSNList { get; set; }
        public virtual TblContactMaster TblContactMaster { get; set; }
    }
}
