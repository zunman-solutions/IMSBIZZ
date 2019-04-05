using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class GodownViewModel
    {
        public int GodownId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string GodownName { get; set; }
        public string GodownAddress { get; set; }
        public string ContactNo { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual CompanyViewModel Company { get; set; }
    }
}