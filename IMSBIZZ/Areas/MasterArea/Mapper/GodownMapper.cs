using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class GodownMapper
    {
        public static Godown Attach(GodownViewModel godownviewmodel)
        {
            Godown godown = new Godown();

            godown.GodownId = godownviewmodel.GodownId;
            godown.GodownName = godownviewmodel.GodownName;
            godown.GodownAddress = godownviewmodel.GodownAddress;
            godown.ContactNo = godownviewmodel.ContactNo;
            godown.ContactPerson = godownviewmodel.ContactPerson;
            godown.CompanyId = godownviewmodel.CompanyId;
            godown.BranchId = godownviewmodel.BranchId;
            godown.Status = godownviewmodel.Status;
            godown.CreatedBy = godownviewmodel.CreatedBy;
            godown.CreatedOn = godownviewmodel.CreatedOn;
            godown.CreatedOn = godownviewmodel.CreatedOn;


            return godown;
        }
    }
}