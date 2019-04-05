using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Areas.Purchase.Models
{
    public class PurchaseDetailViewModel
    {
        public long PurchaseDetailsId { get; set; }
        public Nullable<long> PurchaseId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<decimal> TaxAmnt { get; set; }
        public Nullable<decimal> DicountAmnt { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }

     
    }
}