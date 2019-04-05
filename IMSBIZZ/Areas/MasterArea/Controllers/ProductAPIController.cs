using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMSBIZZ.Areas.MasterArea.Controllers
{
    /// <summary>
    /// Product Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/Product")]
    public class ProductAPIController : ApiController
    {
        private readonly IProductService _productService;

        /// <summary>
        /// Constructor to inject Product Service
        /// </summary>
        /// <param name="productService"></param>
        public ProductAPIController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Get All Products By Company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetAllProducts"), HttpGet]
        public HttpResponseMessage GetAllProducts(int companyId, int branchId)
        {
            var products = _productService.Get(w=>w.CompanyId==companyId && w.BranchId==branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK,products);
        }

        /// <summary>
        /// Get Product Details By Product Id
        /// </summary>
        /// <param name="productId">Product id filter</param>
        /// <returns></returns>
        [Route("GetProductById"), HttpGet]
        public HttpResponseMessage GetProductById(int productId)
        {
            var product = _productService.GetProductById(productId);
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        /// <summary>
        /// Get Product Details by Company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetProductByCompanyBranch"), HttpGet]
        public HttpResponseMessage GetProductByCompanyBranch(int companyId, int branchId)
        {
            var product = _productService.Get(w => w.CompanyId == companyId && w.BranchId == branchId && w.Status == true).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }
    }
}
