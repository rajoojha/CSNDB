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
    
    public partial class tblPageMaster
    {
        public decimal Page_Id { get; set; }
        public string PageName { get; set; }
        public Nullable<decimal> ParentID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<decimal> DisplayOrder { get; set; }
        public string ClassName { get; set; }
    }
}