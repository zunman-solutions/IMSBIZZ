using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Areas.Purchase.Models
{
    public class PurchaseTaxgroupDetailViewModel
    {
        public int PurchaseTaxgroupDetailsId { get; set; }
        public Nullable<int> PurchaseTaxGroupId { get; set; }
        public Nullable<int> TypeId { get; set; }
        public Nullable<decimal> TaxPercentage { get; set; }
    }
}