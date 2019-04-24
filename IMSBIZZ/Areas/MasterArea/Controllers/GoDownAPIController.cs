using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
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
    /// Godown Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/GoDown")]
    public class GodownAPIController : ApiController
    {
        private readonly IGodownService _godownService;

        /// <summary>
        /// Constructor to inject Godown Service
        /// </summary>
        /// <param name="godownService">Godown Service Instance</param>
        public GodownAPIController(IGodownService godownService)
        {
            _godownService = godownService;
        }
        /// <summary>
        ///  Get All Godowns by company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetAllGodowns"), HttpGet]
        public HttpResponseMessage GetAllGodowns(int companyId, int branchId)
        {
            var godowns = _godownService.Get(w => w.CompanyId == companyId && w.BranchId == branchId).Select(s => new GodownViewModel 
            { 
                GodownId = s.GodownId,
                GodownName = s.GodownName,
                GodownAddress = s.GodownAddress,
                ContactNo = s.ContactNo,
                ContactPerson = s.ContactPerson
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, godowns);
        }
        /// <summary>
        /// Get Godown by Godown Id
        /// </summary>
        /// <param name="godownId">Godown Id filter</param>
        /// <returns></returns>
        [Route("GetGodownById"), HttpGet]
        public HttpResponseMessage GetGodownById(int godownId)
        {
            var godown = _godownService.GetGodownById(godownId);
            var godownviewmodel = Areas.MasterArea.Mapper.GodownMapper.Detach(godown);
            return Request.CreateResponse(HttpStatusCode.OK, godownviewmodel);
        }

       



     

    }
}
