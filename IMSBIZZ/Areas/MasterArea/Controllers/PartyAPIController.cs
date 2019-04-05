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
    /// Party Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/Party")]
    public class PartyAPIController : ApiController
    {
        private readonly IPartyService _partyService;

        public PartyAPIController(IPartyService partyService)
        {
            _partyService = partyService;
        }

        [Route("GetParties"), HttpGet]
        public HttpResponseMessage GetParties()
        {
            var parties = _partyService.GetAllPartys();
            return Request.CreateResponse(HttpStatusCode.OK, parties);
        }

        [Route("GetParty"), HttpGet]
        public HttpResponseMessage GetParty(int id)
        {
            var party = _partyService.GetPartyById(id);
            return Request.CreateResponse(HttpStatusCode.OK, party);
        }

        [Route("GetPartyByCompanyBranchType"), HttpGet]
        public HttpResponseMessage GetPartyByCompanyBranchType(int companyId,int branchId,string partyType="Vendor")
        {
            var party = _partyService.Get(w=>w.CompanyId== companyId && w.BranchId==branchId && w.PartyType== partyType && w.Status==true).FirstOrDefault();
            return Request.CreateResponse(HttpStatusCode.OK, party);
        }
    }
}