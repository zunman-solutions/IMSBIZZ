﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class VendorBalanceReportDTO
    {
        public int PurchaseId { get; set; }
        public string PartyName { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal GivenAmnt { get; set; }
        public decimal BalanceAmnt { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
