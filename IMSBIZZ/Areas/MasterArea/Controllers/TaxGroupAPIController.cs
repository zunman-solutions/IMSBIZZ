using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.Areas.MasterArea.Controllers
{
    /// <summary>
    /// Tax Group Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/TaxGroup")]
    public class TaxGroupAPIController : ApiController
    {
        private readonly ITaxGroupService _taxGroupService;

        /// <summary>
        /// Constructor to inject TaxGroup Service
        /// </summary>
        /// <param name="taxGroupService">TaxGroup Service Instance</param>
        public TaxGroupAPIController(ITaxGroupService taxGroupService)
        {
            _taxGroupService = taxGroupService;
        }
        /// <summary>
        ///  Get All TaxGroupes by company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        //[Route("GetAllTaxGroups"), HttpGet]
        //public HttpResponseMessage GetAllTaxGroups(int companyId, int branchId)
        //{
        //    var TaxGroupes = _taxGroupService.Get(w => w.CompanyId == companyId && w.BranchId == branchId).ToList();
        //    return Request.CreateResponse(HttpStatusCode.OK, TaxGroupes);
        //}

        /// <summary>
        /// Get TaxGroup by TaxGroup Id
        /// </summary>
        /// <param name="TaxGroupId">TaxGroup Id filter</param>
        /// <returns></returns>
        [Route("GetTaxGroupById"), HttpGet]
        public HttpResponseMessage GetTaxGroupById(int taxGroupId)
        {
            var taxGroup = _taxGroupService.GetTaxGroupById(taxGroupId);
            var taxgroupviewmodel = Areas.MasterArea.Mapper.TaxMapper.Detach(taxGroup);
            return Request.CreateResponse(HttpStatusCode.OK, taxgroupviewmodel);
        }

        /// <summary>
        /// Get TaxGroup Details by Company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetTaxGroupByCompanyBranch"), HttpGet]
        public HttpResponseMessage GetTaxGroupByCompanyBranch(int companyId, int branchId)
        {
            var TaxGroup = _taxGroupService.Get(w => w.CompanyId == companyId && w.BranchId == branchId && w.Status == true).Select(s => new TaxGroupViewModel 
            {
                GroupId = s.GroupId,
                GroupName = s.GroupName,
            }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, TaxGroup);
        }
        /// <summary>
        /// Get All Grpup Taxes 
        /// </summary>
        /// <param name="companyId">Filter by Company Id</param>
        /// <param name="branchId">Filter By Branch Id</param>
        /// <param name="productId">Filter by Product Id</param>
        /// <returns></returns>
        [Route("GetAllTaxGroupsPercentage"), HttpGet]
        public HttpResponseMessage GetAllTaxGroupsPercentage(int companyId, int branchId,int productId)
        {
            var taxGroups = _taxGroupService.Get(w => w.CompanyId == companyId && w.BranchId == branchId && (w.ProductTaxGroups.Any(p=>p.ProductId==productId)==true) && w.Status == true, includeProperties: "ProductTaxGroups,TaxGroupWithTaxTypes").GroupBy(g => new { g.GroupId, g.GroupName })
                .Select(s => new TaxGroupPercentageViewModel { GroupId = s.FirstOrDefault().GroupId, GroupName = s.FirstOrDefault().GroupName, Percentage = s.Sum(g => g.TaxGroupWithTaxTypes.Sum(sum => sum.TaxPercentage))}).ToList();
                //.Select(s => new {  Percentage = s.Sum(g => g.TaxGroupWithTaxTypes.Sum(sum => sum.TaxPercentage)) }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, taxGroups);
        }
    }
}
