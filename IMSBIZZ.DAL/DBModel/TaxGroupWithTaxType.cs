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
    
    public partial class TaxGroupWithTaxType
    {
        public int TaxGroupWithTaxTypeId { get; set; }
        public Nullable<int> TaxGroupId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<decimal> TaxPercentage { get; set; }
    
        public virtual TaxGroup TaxGroup { get; set; }
        public virtual TaxType TaxType { get; set; }
    }
}
