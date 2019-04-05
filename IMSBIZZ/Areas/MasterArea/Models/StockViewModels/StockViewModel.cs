using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.StockViewModels
{
    public class StockViewModel
    {
        public int StockId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public virtual BatchViewModel Batch { get; set; }
        public virtual BranchViewModel Branch { get; set; }
        public virtual CompanyViewModel Company { get; set; }
        public virtual ProductViewModel Product { get; set; }
    }
}