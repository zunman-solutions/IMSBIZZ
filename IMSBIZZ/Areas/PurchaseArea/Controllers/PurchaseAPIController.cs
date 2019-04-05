using IMSBIZZ.Areas.Purchase.Mapper;
using IMSBIZZ.Areas.Purchase.Models;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMSBIZZ.Areas.PurchaseArea.Controllers
{
    /// <summary>
    /// Purchase Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/Purchase")]
    public class PurchaseAPIController : ApiController
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IStockService _stockService;

        /// <summary>
        /// Purchase Api Constructor
        /// </summary>
        /// <param name="purchaseService">Purchase Service Injiection</param>
        /// <param name="stockService">Stock Service Injection</param>
        public PurchaseAPIController(IPurchaseService purchaseService, IStockService stockService)
        {
            _purchaseService = purchaseService;
            _stockService = stockService;
        }
        /// <summary>
        /// Get All Purchases
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetPurchase"), HttpGet]
        public HttpResponseMessage GetPurchase(int companyId, int branchId)
        {
            var purchases = _purchaseService.Get(w => w.CompanyId == companyId && w.BranchId == branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,purchases);
        }
        /// <summary>
        /// Save Purchase 
        /// </summary>
        /// <param name="purchaseServiceViewModel">ViewModel Used to Pass data for purchase</param>
        /// <returns></returns>
        [Route("SavePurchase"), HttpPost]
        public HttpResponseMessage SavePurchase(PurchaseServiceViewModel purchaseServiceViewModel)
        {
            //Attch to original Db table using Mapper
            var purchase = PurchaseMapper.Attach(purchaseServiceViewModel);
            _purchaseService.Add(purchase);
            _purchaseService.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Saved successfully.");
        }
        /// <summary>
        /// Validate Product Batch as per Batch, Purchase Rate and Tax Group
        /// </summary>
        /// <param name="purchaseServiceViewModel"></param>
        /// <returns></returns>
        [Route("ValidateProductBatch"), HttpPost]
        public HttpResponseMessage ValidateProductBatch(PurchaseServiceViewModel purchaseServiceViewModel)
        {
            //Attch to original Db table using Mapper
            var purchase = PurchaseMapper.Attach(purchaseServiceViewModel);
            _purchaseService.Add(purchase);
            _purchaseService.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Saved successfully.");
        }
    }
}
