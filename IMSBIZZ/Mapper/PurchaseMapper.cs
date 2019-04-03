using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.Helper;
using IMSBIZZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Mapper
{
    public static class PurchaseMapper
    {

        public static Purchase Attach(PurchaseViewModel purchaseViewModel)
        {
            Purchase purchase = new Purchase();

          
            return purchase;
        }

       
        public static PurchaseViewModel Detach(Purchase purchase)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            
            return purchaseViewModel;
        }
    }
}