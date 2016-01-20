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
    
    public partial class TblInitiativeResult
    {
        public int InitiativeItemCode { get; set; }
        public Nullable<int> InitiativeID { get; set; }
        public Nullable<int> ContactID { get; set; }
        public Nullable<bool> Presented { get; set; }
        public Nullable<System.DateTime> PresentDate { get; set; }
        public string PresentTo { get; set; }
        public Nullable<int> InitResultID { get; set; }
        public Nullable<System.DateTime> FollowupDate { get; set; }
        public string Reasons { get; set; }
        public string Comments { get; set; }
        public string SkusPlaced { get; set; }
        public Nullable<int> DistConfirm { get; set; }
        public string EmailText { get; set; }
        public string ItemSuffix { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> AccountID { get; set; }
        public Nullable<int> CSNID { get; set; }
        public Nullable<bool> AppointmentPending { get; set; }
        public Nullable<bool> DISQUALIFIED { get; set; }
    
        public virtual TblInitiativeList TblInitiativeList { get; set; }
        public virtual TblpkInitResult TblpkInitResult { get; set; }
        public virtual TblContactMaster TblContactMaster { get; set; }
    }
}
