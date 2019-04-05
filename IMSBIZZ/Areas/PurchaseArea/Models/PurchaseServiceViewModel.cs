using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.Purchase.Models
{
    public class PurchaseServiceViewModel
    {
        public int PurchaseId { get; set; }
        public int? PartyId { get; set; }
        public int? FinancialYearId { get; set; }
        public string PONo { get; set; }
        public bool? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? PODate { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string InvoiceNumber { get; set; }
        public int? PaymentModeId { get; set; }
        public string Note { get; set; }
        public Decimal? OtherExpenses { get; set; }

        //Payment Detail Properties
        public Decimal? SubTotal { get; set; }
        public Decimal? TaxAmount { get; set; }
        public Decimal? DiscountAmount { get; set; }
        public Decimal? GrandTotal { get; set; }
        public Decimal? PaidAmnt { get; set; }
        public Decimal? GivenAmnt { get; set; }
        public Decimal? BalanceAmnt { get; set; }
        public string FromTable { get; set; }

        public ICollection<PurchaseDetailsViewModel> PurchaseDetailsViewModel { get; set; }

    }


    public class PurchaseDetailsViewModel
    {
        public int? ProductId { get; set; }
        public Nullable<int> BatchId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<decimal> TaxAmnt { get; set; }
        public Nullable<decimal> DiscountAmnt { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public decimal TotalTaxPercentage { get; set; }
        public string GroupName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }

        //ActualPurchaseTaxAndPrice Properties
        public Decimal? PurchaseRate { get; set; }
        public Decimal? DiscountPercentage { get; set; }
        public Decimal? SaleRate { get; set; }

        public ICollection<TaxGroupDetailsViewModel> TaxGroupDetailsViewModel { get; set; }

    }

    public class TaxGroupDetailsViewModel
    {
        public int TypeId { get; set; }
        public decimal TaxPercentage { get; set; }
    }
}