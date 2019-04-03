using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Models
{
    public class PurchaseTaxGroupViewModel
    {
        [Key]
        public long PurchaseTaxGroupId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> TaxGroupId { get; set; }
        public Nullable<long> PurchaseId { get; set; }
        public Nullable<decimal> TotalTaxPercentage { get; set; }
        public Nullable<int> BatchId { get; set; }
    }
}