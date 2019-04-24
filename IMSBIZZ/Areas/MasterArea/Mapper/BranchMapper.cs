using IMSBIZZ.Areas.MasterArea.Models.StockViewModels;
using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.Helper;
using IMSBIZZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class BranchMapper
    {
        public static Branch Attach(RegisterViewModel registerViewModel)
        {
            Branch branch = new Branch();
            branch.CompanyId = registerViewModel.CompanyId;
            branch.Pincode = registerViewModel.PinCode;
            branch.BranchName = registerViewModel.CompanyName;
            branch.IsMainBranch = true;
            branch.CountyId = registerViewModel.CountryId;
            branch.Status = true;
            branch.CreatedBy = registerViewModel.FirstName;
            branch.CreatedOn = DateTime.Now;

            return branch;
        }


        public static RegisterViewModel Detach(Branch branch)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return registerViewModel;
        }
    }
}