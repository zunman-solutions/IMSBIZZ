using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Models
{
    public class PurchaseViewModel
    {
        [Key]
        public long PurchaseId { get; set; }
        public Nullable<int> PartyId { get; set; }
        public Nullable<int> FinancialyearId { get; set; }
        public string PoNo { get; set; }
        public Nullable<System.DateTime> Po_Date { get; set; }
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

        
        public virtual ICollection<PurchaseDetailViewModel> PurchaseDetails { get; set; }
        public virtual ICollection<PurchasePaymentDetailViewModel> PurchasePaymentDetials { get; set; }
        //public virtual ICollection<PurchaseReturn> PurchaseReturns { get; set; }
        public virtual ICollection<PurchaseTaxGroupViewModel> PurchaseTaxGroups { get; set; }


    }
}