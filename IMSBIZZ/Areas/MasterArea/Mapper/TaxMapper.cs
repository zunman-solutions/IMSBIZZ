using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class TaxMapper
    {
        public static TaxGroup Attach(TaxGroupViewModel taxgroupviewmodel)
        {
            TaxGroup taxgroup = new TaxGroup();

            taxgroup.GroupId = taxgroupviewmodel.GroupId;
            taxgroup.GroupName = taxgroupviewmodel.GroupName;
            taxgroup.Status = taxgroupviewmodel.Status;
            taxgroup.CreatedBy = taxgroupviewmodel.CreatedBy;
            taxgroup.CreatedOn = taxgroupviewmodel.CreatedOn;
            taxgroup.UpdatedBy = taxgroupviewmodel.UpdatedBy;
            taxgroup.UpdatedOn = taxgroupviewmodel.UpdatedOn;
            taxgroup.CompanyId = taxgroupviewmodel.CompanyId;
            taxgroup.BranchId = taxgroupviewmodel.BranchId;

            return taxgroup;
        }
        public static TaxGroupViewModel Detach(TaxGroup taxgroup)
        {
            TaxGroupViewModel taxgroupviewmodel = new TaxGroupViewModel();

            taxgroupviewmodel.GroupId = taxgroup.GroupId;
            taxgroupviewmodel.GroupName = taxgroup.GroupName;
            taxgroupviewmodel.Status = taxgroup.Status;
            taxgroupviewmodel.CreatedBy = taxgroup.CreatedBy;
            taxgroupviewmodel.CreatedOn = taxgroup.CreatedOn;
            taxgroupviewmodel.UpdatedBy = taxgroup.UpdatedBy;
            taxgroupviewmodel.UpdatedOn = taxgroup.UpdatedOn;
            taxgroupviewmodel.CompanyId = taxgroup.CompanyId;
            taxgroupviewmodel.BranchId = taxgroup.BranchId;

            return taxgroupviewmodel;
        }
    }
}