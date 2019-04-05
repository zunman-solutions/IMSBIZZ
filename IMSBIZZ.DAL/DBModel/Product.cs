//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMSBIZZ.DAL.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.ProductTaxGroups = new HashSet<ProductTaxGroup>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
            this.PurchaseReturnDetails = new HashSet<PurchaseReturnDetail>();
            this.PurchaseTaxGroups = new HashSet<PurchaseTaxGroup>();
            this.Stocks = new HashSet<Stock>();
        }
    
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
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Branch Branch1 { get; set; }
        public virtual Category Category { get; set; }
        public virtual Company Company { get; set; }
        public virtual Rack Rack { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductTaxGroup> ProductTaxGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseReturnDetail> PurchaseReturnDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseTaxGroup> PurchaseTaxGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
