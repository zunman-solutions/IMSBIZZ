using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class TaxGroupViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

    }

    public class TaxGroupPercentageViewModel
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public decimal? Percentage { get; set; }
    }
    }