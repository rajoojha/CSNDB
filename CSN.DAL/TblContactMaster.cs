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
    
    public partial class TblContactMaster
    {
        public TblContactMaster()
        {
            this.TblGeneralActivities = new HashSet<TblGeneralActivitie>();
            this.TblInitiativeResults = new HashSet<TblInitiativeResult>();
        }
    
        public int ContactID { get; set; }
        public Nullable<int> AccountCode { get; set; }
        public Nullable<bool> SingleBuyerIndex { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string OfficePhone { get; set; }
        public string PhoneExt { get; set; }
        public string FaxNumber { get; set; }
        public string CellNumber { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyExt { get; set; }
        public string ContactEmail { get; set; }
        public string MailCompanyName { get; set; }
        public string MailTitle { get; set; }
        public string MailNamePrefix { get; set; }
        public string MailLastName { get; set; }
        public string MailFirstName { get; set; }
        public string MailNameSuffix { get; set; }
        public string MailLetters { get; set; }
        public string MailGreeting { get; set; }
        public string MailSalutation { get; set; }
        public string MailAddress1 { get; set; }
        public string MailAddress2 { get; set; }
        public string MailCity { get; set; }
        public string MailState { get; set; }
        public string MailCountry { get; set; }
        public string MailMailCode { get; set; }
        public string Comments { get; set; }
        public Nullable<bool> Buyer { get; set; }
        public Nullable<bool> NewEntry { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public Nullable<bool> StatusChange { get; set; }
        public Nullable<System.DateTime> StatusChangeDate { get; set; }
        public Nullable<bool> AccountChange { get; set; }
        public Nullable<System.DateTime> AccountChangeDate { get; set; }
        public Nullable<bool> CSNRepChange { get; set; }
        public Nullable<System.DateTime> CSNRepChangeDate { get; set; }
        public Nullable<bool> LastModified { get; set; }
        public Nullable<System.DateTime> LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public string CntStatusID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public Nullable<bool> IsMaskMail { get; set; }
        public Nullable<bool> IsDelelted { get; set; }
    
        public virtual ICollection<TblGeneralActivitie> TblGeneralActivities { get; set; }
        public virtual ICollection<TblInitiativeResult> TblInitiativeResults { get; set; }
    }
}
