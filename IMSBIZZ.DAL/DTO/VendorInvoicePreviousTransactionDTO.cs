using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class VendorInvoicePreviousTransactionDTO
    {
        public int PartyId { get; set; }
        public int PurchaseCount { get; set; }
        public string PartyName { get; set; }
        public decimal PaidAmnt { get; set; }
        public decimal BalanceAmnt { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
