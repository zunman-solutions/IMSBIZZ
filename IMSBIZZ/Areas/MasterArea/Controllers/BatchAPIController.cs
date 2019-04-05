﻿using IMSBIZZ.DAL.IService;
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
            var batches = _batchService.Get(w => w.CompanyId == companyId && w.BranchId == branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, batches);
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
            return Request.CreateResponse(HttpStatusCode.OK, batch);
        }

        /// <summary>
        /// Get Batch Details by Company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetBatchByCompanyBranch"), HttpGet]
        public HttpResponseMessage GetBatchByCompanyBranch(int companyId, int branchId)
        {
            var batch = _batchService.Get(w => w.CompanyId == companyId && w.BranchId == branchId && w.Status == true).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, batch);
        }
    }
}