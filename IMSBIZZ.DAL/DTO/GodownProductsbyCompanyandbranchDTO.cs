using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class GodownProductsbyCompanyandbranchDTO
    {
        public string GodownName { get; set; }
        public int godownId { get; set; }
        public string product_no { get; set; }
        public int quantity { get; set; }
    }
}
