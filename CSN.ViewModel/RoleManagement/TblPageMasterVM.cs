using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSN.ViewModel
{
    public class TblPageMasterVM
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
        public Nullable<decimal> ParentID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Nullable<decimal> DisplayOrder { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public IEnumerable<TblPageMasterVM> TblPageMasterList { get; set; }
    }

   
}
