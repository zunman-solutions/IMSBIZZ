using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class PartyViewModel
    {
        public int PartyId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string ContactNo { get; set; }
        public string GSTINNo { get; set; }
        public string PartyType { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> StateId { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }

        public virtual BranchViewModel Branch { get; set; }
        public virtual CompanyViewModel Company { get; set; }
    }
}