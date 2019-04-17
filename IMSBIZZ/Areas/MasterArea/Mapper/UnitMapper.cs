using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class UnitMapper
    {
        public static Unit Attach(UnitViewModel unitviewmodel)
        {
            Unit unit = new Unit();

            unit.UnitId = unitviewmodel.UnitId;
            unit.UnitName = unitviewmodel.UnitName;
            unit.Status = unitviewmodel.Status;
            unit.CompanyId = unitviewmodel.CompanyId;
            unit.BranchId = unitviewmodel.BranchId;
            unit.CreatedBy = unitviewmodel.CreatedBy;
            unit.CreatedOn = unitviewmodel.CreatedOn;
            unit.UpdatedBy = unitviewmodel.UpdatedBy;
            unit.UpdatedOn = unitviewmodel.UpdatedOn;

            return unit;
        }

        public static UnitViewModel Detach(Unit unit)
        {
            UnitViewModel unitviewmodel = new UnitViewModel();

            unitviewmodel.UnitId = unit.UnitId;
            unitviewmodel.UnitName = unit.UnitName;
            unitviewmodel.Status = unit.Status;
            unitviewmodel.CompanyId = unit.CompanyId;
            unitviewmodel.BranchId = unit.BranchId;
            unitviewmodel.CreatedBy = unit.CreatedBy;
            unitviewmodel.CreatedOn = unit.CreatedOn;
            unitviewmodel.UpdatedBy = unit.UpdatedBy;
            unitviewmodel.UpdatedOn = unit.UpdatedOn;

            return unitviewmodel;
        }
    }
}