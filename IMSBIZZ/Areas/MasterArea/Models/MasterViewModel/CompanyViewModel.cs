using IMSBIZZ.Areas.Purchase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Models.MasterViewModel
{
    public class CompanyViewModel
    {
        public int CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> StateId { get; set; }
        public string CityId { get; set; }
        public string PinCOde { get; set; }
        public string Logo { get; set; }
        public string GSTIN { get; set; }
        public string TelephoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Ownername { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerMobileNo { get; set; }
        public string OwnerEmailId { get; set; }
        public Nullable<bool> Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

        public virtual ICollection<BatchViewModel> Batches { get; set; }
        public virtual ICollection<BranchViewModel> Branches { get; set; }
        public virtual ICollection<FinancialyearViewModel> FinancialYears { get; set; }
        public virtual ICollection<GodownViewModel> Godowns { get; set; }
        public virtual ICollection<PartyViewModel> Parties { get; set; }
        public virtual ICollection<ProductViewModel> Products { get; set; }
        public virtual ICollection<PurchaseViewModel> Purchases { get; set; }
        public virtual ICollection<RackViewModel> Racks { get; set; }
        public virtual ICollection<TaxTypeViewModel> TaxTypes { get; set; }
        public virtual ICollection<UnitViewModel> Units { get; set; }
    }
}