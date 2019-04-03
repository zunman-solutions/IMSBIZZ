using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Models
{
    public class PurchasePaymentDetailViewModel
    {
        [Key]
        public long Id { get; set; }
        public Nullable<long> PurchaseId { get; set; }
        public Nullable<decimal> SubTotal { get; set; }
        public Nullable<decimal> TaxAmount { get; set; }
        public Nullable<decimal> DiscountAmount { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public Nullable<decimal> PaidAmnt { get; set; }
        public Nullable<decimal> GivenAmnt { get; set; }
        public Nullable<decimal> BalanceAmnt { get; set; }
        public string FromTable { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public virtual PurchaseViewModel Purchase { get; set; }


    }
}