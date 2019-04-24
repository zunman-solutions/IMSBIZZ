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
    
    public partial class PurchaseDetail
    {
        public long PurchaseDetailsId { get; set; }
        public Nullable<long> PurchaseId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> TaxGroupId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<decimal> PurchaseRate { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> TaxAmnt { get; set; }
        public Nullable<decimal> TaxPercent { get; set; }
        public Nullable<decimal> DiscountPercent { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> DiscountAmnt { get; set; }
    
        public virtual Batch Batch { get; set; }
        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual TaxGroup TaxGroup { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
