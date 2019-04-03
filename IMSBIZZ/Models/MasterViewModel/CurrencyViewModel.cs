using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Models.MasterViewModel
{
    public class CurrencyViewModel
    {
        public int CurrencyId { get; set; }
        public string CountryName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }
    }
}