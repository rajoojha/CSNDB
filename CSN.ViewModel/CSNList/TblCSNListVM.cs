using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSN.ViewModel
{
    public class TblCSNListVM
    {
        public int CSNID { get; set; }
        public int CSNTypeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string SortName { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Dept { get; set; }
        public int? CSNGroupID { get; set; }
        public string Email { get; set; }
        public string GsmEmail { get; set; }
        public string DirEmail { get; set; }
        public string Phone { get; set; }
        public string Ext { get; set; }
        public string Cell { get; set; }
        public string AltNumber { get; set; }
        public string Fax { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public string FlagFollowups { get; set; }
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string SAddress1 { get; set; }
        public string SAddress2 { get; set; }
        public string SCity { get; set; }
        public string SState { get; set; }
        public string SCountry { get; set; }
        public string SZip { get; set; }
        public int? Roleid { get; set; }
        public string Division { get; set; }
        public string PrimaryAddress { get; set; }
        public string SecondaryAddress { get; set; }
        public string ErrorMessage { get; set; }
        //public virtual ICollection<TblCSNDivision> TblCSNDivisions { get; set; }
    }
}
