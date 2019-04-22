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
    [RoutePrefix("Purchase")]
    public class PurchaseController : Controller
    {
        private readonly IPurchaseService _purchaseService;
        private readonly  IStockService _stockService;

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
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        // GET: Purchase
        //[CustomAuthorize(Common.DataEntry, Common.Admin)]
        [Route("Create")]
        public ActionResult Create()
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