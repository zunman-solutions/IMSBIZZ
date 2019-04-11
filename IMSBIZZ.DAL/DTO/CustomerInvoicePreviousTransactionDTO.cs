using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class CustomerInvoicePreviousTransactionDTO
    {
        public int PartyId { get; set; }
        public int SaleCount { get; set; }
        public string PartyName { get; set; }
        public decimal PaidAmnt { get; set; }
        public decimal BalanceAmnt { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
