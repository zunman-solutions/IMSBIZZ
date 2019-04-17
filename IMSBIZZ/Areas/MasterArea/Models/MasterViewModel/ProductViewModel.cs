using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string HSNCode { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> GodownId { get; set; }
        public Nullable<int> RackId { get; set; }
        public Nullable<decimal> PurchasPrice { get; set; }
        public Nullable<decimal> SalesPrice { get; set; }
        public Nullable<int> ReorderLevel { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual BranchViewModel Branch { get; set; }
        public virtual CategoryViewModel Category { get; set; }
        public virtual CompanyViewModel Company { get; set; }
        public virtual RackViewModel Rack { get; set; }
    }
}