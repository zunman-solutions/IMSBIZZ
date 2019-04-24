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
    public static class UserCompanyMapper
    {
        public static UserCompany Attach(RegisterViewModel registerViewModel)
        {
            UserCompany company = new UserCompany();
            company.CompanyId = registerViewModel.CompanyId;
            company.UserId = registerViewModel.UserId;

            return company;
        }


        public static RegisterViewModel Detach(UserCompany company)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return registerViewModel;
        }
    }
}