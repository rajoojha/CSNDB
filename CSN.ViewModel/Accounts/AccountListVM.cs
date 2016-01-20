using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSN.ViewModel
{
    public class AccountListVM
    {

        public int? AccountID { get; set; }

        public string AccountName { get; set; }

        public string NumberAccount { get; set; }

        public string Compny_Phone { get; set; }

        public string EXT { get; set; }

        public string CompanyFax { get; set; }

        public string Mal_Address1 { get; set; }

        public string Mal_Address2 { get; set; }

        public string Mal_Zip { get; set; }

        public string Mal_Country { get; set; }

        public string Mal_City { get; set; }

    }
}