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
    
    public partial class Sale
    {
        public long SaleId { get; set; }
        public Nullable<int> PartyId { get; set; }
        public Nullable<int> FinancialyearId { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public string InvoiceNumber { get; set; }
        public Nullable<int> PaymentModeId { get; set; }
        public string Note { get; set; }
        public Nullable<decimal> OtherExpenses { get; set; }
        public string AttachmentUrl { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
    }
}
