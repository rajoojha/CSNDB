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
    
    public partial class TblMfg
    {
        public TblMfg()
        {
            this.TblGeneralActivities = new HashSet<TblGeneralActivitie>();
            this.TblInitiativeLists = new HashSet<TblInitiativeList>();
        }
    
        public int ID { get; set; }
        public string MfgID { get; set; }
        public string MfgName { get; set; }
        public string MFGPrintName { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public Nullable<bool> DryOnly { get; set; }
        public Nullable<bool> Food { get; set; }
        public Nullable<bool> Freezen { get; set; }
        public Nullable<bool> DOTFoods { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string PrimaryPhone1 { get; set; }
        public string PrimaryPhone2 { get; set; }
        public string Fax { get; set; }
        public string EMailAddress { get; set; }
        public string Website { get; set; }
        public Nullable<bool> MfgActive { get; set; }
    
        public virtual ICollection<TblGeneralActivitie> TblGeneralActivities { get; set; }
        public virtual ICollection<TblInitiativeList> TblInitiativeLists { get; set; }
    }
}