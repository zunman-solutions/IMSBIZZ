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
            godown.UpdatedBy = godownviewmodel.UpdatedBy;
            godown.UpdatedOn = godownviewmodel.UpdatedOn;

            return godown;
        }

        public static GodownViewModel Detach(Godown godown)
        {
            GodownViewModel godownviewmodel = new GodownViewModel();

            godownviewmodel.GodownId = godown.GodownId;
            godownviewmodel.GodownName = godown.GodownName;
            godownviewmodel.GodownAddress = godown.GodownAddress;
            godownviewmodel.ContactNo = godown.ContactNo;
            godownviewmodel.ContactPerson = godown.ContactPerson;
            godownviewmodel.CompanyId = godown.CompanyId;
            godownviewmodel.BranchId = godown.BranchId;
            godownviewmodel.Status = godown.Status;
            godownviewmodel.CreatedBy = godown.CreatedBy;
            godownviewmodel.CreatedOn = godown.CreatedOn;
            godownviewmodel.UpdatedBy = godown.UpdatedBy;
            godownviewmodel.UpdatedOn = godown.UpdatedOn;

            return godownviewmodel;
        }
    }
}