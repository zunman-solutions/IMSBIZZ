using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Models.MasterViewModel
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string CategoryName { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
    }
}