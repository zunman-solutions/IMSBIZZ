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
    
    public partial class SaleDetailsHistory
    {
        public long Id { get; set; }
        public long SaleDetailsId { get; set; }
        public Nullable<long> SaleId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> TaxGroupId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> TaxAmnt { get; set; }
        public Nullable<decimal> TaxPercent { get; set; }
        public Nullable<decimal> DicountAmnt { get; set; }
        public Nullable<decimal> DiscountPercent { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}