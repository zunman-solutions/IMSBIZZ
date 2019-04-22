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
    public static class CompanyMapper
    {
        public static Company Attach(RegisterViewModel registerViewModel)
        {
            Company company = new Company();
            company.FirstName = registerViewModel.FirstName;
            company.LastName = registerViewModel.LastName;
            company.CompanyName = registerViewModel.CompanyName;
            company.OwnerEmailId = registerViewModel.Email;
            company.OwnerMobileNo = registerViewModel.MobileNo;
            company.CountryId = registerViewModel.CountryId;
            company.PinCode = registerViewModel.PinCode;
            company.Status = true;
            company.CreatedBy = registerViewModel.FirstName;
            company.CreatedOn = DateTime.Now;
            company.RefrenceMobileNo = registerViewModel.ReferenceMobileNo;

            return company;
        }


        public static RegisterViewModel Detach(Company company)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return registerViewModel;
        }
    }
}