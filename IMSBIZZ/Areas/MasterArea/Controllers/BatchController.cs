using IMSBIZZ.DAL.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMSBIZZ.Areas.MasterArea.Controllers
{
    /// <summary>
    /// Batch  Controller
    /// </summary>
    public class BatchController : Controller
    {
        IBatchService _batchService;

        /// <summary>
        /// Batch Controller Constructor
        /// </summary>
        /// <param name="batchService"></param>
        public BatchController(IBatchService batchService)
        {
            _batchService = batchService;
        }
        // GET: MasterArea/Batch

            /// <summary>
            /// Batch Indx Page
            /// </summary>
            /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        ///Create Batch
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Edit Batch
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public ActionResult Edit(int batchId)
        {
            ViewBag.Batch = _batchService.GetBatchById(batchId);
            return View();
        }

    }
}