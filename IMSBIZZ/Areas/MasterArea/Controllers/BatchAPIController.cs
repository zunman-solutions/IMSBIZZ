using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace IMSBIZZ.Areas.MasterArea.Controllers
{
    /// <summary>
    /// Batch Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/Batch")]
    public class BatchAPIController : ApiController
    {
        private readonly IBatchService _batchService;

        /// <summary>
        /// Constructor to inject Batch Service
        /// </summary>
        /// <param name="batchService">Batch Service Instance</param>
        public BatchAPIController(IBatchService batchService)
        {
            _batchService = batchService;
        }
        /// <summary>
        ///  Get All Batches by company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetAllBatches"), HttpGet]
        public HttpResponseMessage GetAllBatches(int companyId, int branchId)
        {
            var batches = _batchService.Get(w => w.CompanyId == companyId && w.BranchId == branchId && w.Status==true).Select(s => new BatchViewModel 
            {
               BatchId = s.BatchId,
                BatchName = s.BatchName,
                Status=s.Status
            }).ToList();
            return Request.CreateResponse(new { status = "OK", recordsTotal = batches.Count(), data = batches, recordsFiltered = batches.Count() });
            //return JsonResult(new { status = "OK", recordsTotal = urlDetails.Count(), data = urlDetails, recordsFiltered = urlDetails.Count() });
        }

        /// <summary>
        /// Get Batch by Batch Id
        /// </summary>
        /// <param name="batchId">Batch Id filter</param>
        /// <returns></returns>
        [Route("GetBatchesById"), HttpGet]
        public HttpResponseMessage GetBatchesById(int batchId)
        {
            var batch = _batchService.GetBatchById(batchId);
            var batchviewmodel = Areas.MasterArea.Mapper.BatchMapper.Detach(batch);
            return Request.CreateResponse(HttpStatusCode.OK, batchviewmodel);
        }

        /// <summary>
        /// Create Batch
        /// </summary>
        /// <param name="batchViewModel">Pass Batch Model</param>
        /// <returns></returns>
        [Route("CreateBatch"), HttpPost]
        public HttpResponseMessage CreateBatch(BatchViewModel batchViewModel)
        {
            var batch = Mapper.BatchMapper.Attach(batchViewModel);
            _batchService.Add(batch);
            _batchService.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        /// <summary>
        /// Edit Batch
        /// </summary>
        /// <param name="batchViewModel">Pass Batch Model</param>
        /// <returns></returns>
        [Route("EditBatch/{batchViewModel}"), HttpPost]
        public HttpResponseMessage EditBatch(BatchViewModel batchViewModel)
        {
            //var _batch = _batchService.GetBatchById(batchViewModel.BatchId);
            var batch = Mapper.BatchMapper.Attach(batchViewModel);
            _batchService.Update(batch);
            _batchService.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Delete Batch
        /// </summary>
        /// <param name="batchId">Batch Id</param>
        /// <returns></returns>
        [Route("DeleteBatch/{batchId}"), HttpPost]
        public HttpResponseMessage DeleteBatch(int batchId)
        {
            //var _batch = _batchService.GetBatchById(batchViewModel.BatchId);
            //var batch = _batchService.GetBatchById(batchId);
            _batchService.Delete(batchId);
            _batchService.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Get Batch Details by Company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        //[Route("GetBatchByCompanyBranch"), HttpGet]
        //public HttpResponseMessage GetBatchByCompanyBranch(int companyId, int branchId)
        //{
        //    var batch = _batchService.Get(w => w.CompanyId == companyId && w.BranchId == branchId && w.Status == true).FirstOrDefault();
        //    return Request.CreateResponse(HttpStatusCode.OK, batch);
        //}




        /// <summary>
        /// Get Sale Monthy Count 
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        ///  <param name="productId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetBatchByProduct"), HttpGet]
        public HttpResponseMessage GetBatchByProduct(int productId,int companyId, int branchId)
        {
            var purchase = _batchService.GetBatchByProduct(@"SELECT pd.BatchID,b.BatchName 
                                                            FROM PurchaseDetails pd 
                                                            INNER JOIN Batch  b ON pd.BatchId = b.BatchId 
                                                            Where pd.ProductId={0} 
                                                            AND b.CompanyId={1} 
                                                            AND b.BranchId ={2} 
                                                            AND  b.status=1  ", productId, companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }
    }
}
