using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public Nullable<bool> IsMainBranch { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public string BranchAddress { get; set; }
        public Nullable<int> CountyId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual BranchViewModel Branch { get; set; }
        public virtual CompanyViewModel Company { get; set; }
        public virtual CountryViewModel Country { get; set; }
    }
}