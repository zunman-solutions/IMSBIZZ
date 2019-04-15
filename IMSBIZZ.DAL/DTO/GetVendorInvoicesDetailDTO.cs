using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class GetVendorInvoicesDetailDTO
    {
        public int Id { get; set; }
        public string Batch { get; set; }
        public DateTime Company { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public string Party { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string PoNo { get; set; }
        public string Product { get; set; }
        public decimal PurchaseRate { get; set; }
        public decimal SaleRate { get; set; }
        public decimal Quantity { get; set; }
        public decimal TaxAmnt { get; set; }
        public decimal DiscountAmnt { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal TotalDiscount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal GrandTotal { get; set; }
        public decimal GivenAmnt { get; set; }
        public decimal BalanceAmnt { get; set; }
        public decimal PaymentMode { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

    }
}
