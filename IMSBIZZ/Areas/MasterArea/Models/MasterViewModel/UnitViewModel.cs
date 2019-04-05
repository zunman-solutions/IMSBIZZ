using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class UnitViewModel
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual BranchViewModel Branch { get; set; }
        public virtual CompanyViewModel Company { get; set; }
    }
}