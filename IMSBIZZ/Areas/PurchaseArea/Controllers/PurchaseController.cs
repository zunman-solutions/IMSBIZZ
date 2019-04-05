using IMSBIZZ.Areas.Purchase.Mapper;
using IMSBIZZ.Areas.Purchase.Models;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Areas.PurchaseArea.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ElmahError]
    public class PurchaseController : Controller
    {
        IPurchaseService _purchaseService;
        IStockService _stockService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseService"></param>
        /// <param name="stockService"></param>
        public PurchaseController(IPurchaseService purchaseService, IStockService stockService)
        {
            _purchaseService = purchaseService;
            _stockService = stockService;
        }

        // GET: Purchase
        //[CustomAuthorize(Common.DataEntry, Common.Admin)]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(PurchaseServiceViewModel purchaseServiceViewModel)
        {
            //Attch to original Db table using Mapper
            var purchase = PurchaseMapper.Attach(purchaseServiceViewModel);
            _purchaseService.Add(purchase);

            return View();
        }




    }
}