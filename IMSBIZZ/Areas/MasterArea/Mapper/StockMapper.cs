using IMSBIZZ.Areas.MasterArea.Models.StockViewModels;
using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.Helper;
using IMSBIZZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class StockMapper
    {
        public static Stock Attach(StockViewModel stockViewModel)
        {
            Stock stock = new Stock();

            stock.CompanyId = stockViewModel.CompanyId;
            stock.BranchId = stockViewModel.BranchId;
            stock.ProductId = stockViewModel.ProductId;
            stock.BatchId = stockViewModel.BatchId;
            stock.Quantity = stockViewModel.Quantity;
            stock.CreatedBy = stockViewModel.CreatedBy;
            stock.CreatedOn = stockViewModel.CreatedOn;
            return stock;
        }


        public static StockViewModel Detach(Stock stock)
        {
            StockViewModel stockViewModel = new StockViewModel();

            return stockViewModel;
        }
    }
}