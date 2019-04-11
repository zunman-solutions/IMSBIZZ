using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.DTO
{
    public class GetProductdetialsbygodownDTO
    {
        public string GodownName { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string HSNCode { get; set; }
        public int Quantity { get; set; }
        public string BatchName { get; set; }
    }
}
