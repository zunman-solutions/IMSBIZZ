using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Models.MasterViewModel
{
    public class TaxTypeViewModel
    {
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public virtual BranchViewModel Branch { get; set; }
        public virtual CompanyViewModel Company { get; set; }
    }
}