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
    
    public partial class PurchaseTaxGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseTaxGroup()
        {
            this.PurchaseTaxgroupDetails = new HashSet<PurchaseTaxgroupDetail>();
        }
    
        public long PurchaseTaxGroupId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> TaxGroupId { get; set; }
        public Nullable<long> PurchaseId { get; set; }
        public Nullable<decimal> TotalTaxPercentage { get; set; }
        public Nullable<int> BatchId { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseTaxgroupDetail> PurchaseTaxgroupDetails { get; set; }
    }
}
