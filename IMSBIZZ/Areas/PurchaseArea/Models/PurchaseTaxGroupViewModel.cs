using IMSBIZZ.Areas.Purchase.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IIMSBIZZ.Areas.Purchase.Models
{
    public class PurchaseTaxGroupViewModel
    {
        public long PurchaseTaxGroupId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> TaxGroupId { get; set; }
        public Nullable<long> PurchaseId { get; set; }
        public Nullable<decimal> TotalTaxPercentage { get; set; }
        public Nullable<int> BatchId { get; set; }


        public virtual ICollection<PurchaseTaxgroupDetailViewModel> PurchaseTaxgroupDetails { get; set; }

    }
}