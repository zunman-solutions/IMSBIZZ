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
    public static class FinancialYearMapper
    {
        public static FinancialYear Attach(RegisterViewModel registerViewModel)
        {
            FinancialYear financialYear = new FinancialYear();
            financialYear.CompanyId = registerViewModel.CompanyId;
            financialYear.BranchId = registerViewModel.BranchId;
            financialYear.StartDate = registerViewModel.StartDate.ToString();
            financialYear.EndDate = registerViewModel.EndDate.ToString();
            financialYear.Status = true;
            financialYear.CreatedBy = registerViewModel.FirstName;
            financialYear.CreatedOn = DateTime.Now;

            return financialYear;
        }


        public static RegisterViewModel Detach(FinancialYear financialYear)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return registerViewModel;
        }
    }
}