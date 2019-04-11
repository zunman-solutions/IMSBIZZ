using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class SaleChartDetailsDTO
    {
        public string ProductName { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalSaleAmount { get; set; }
    }
}
