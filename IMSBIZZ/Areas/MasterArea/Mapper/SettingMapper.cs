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
    public static class SettingMapper
    {
        public static setting Attach(RegisterViewModel registerViewModel)
        {
            setting Setting = new setting();
            Setting.company_id = registerViewModel.CompanyId;
            Setting.branch_id = registerViewModel.BranchId;
            Setting.user_id = registerViewModel.UserId;
            Setting.created_by = registerViewModel.FirstName;
            Setting.created_date = DateTime.Now;
            Setting.InvoiceTemplateName = "PurchaseSaleReturnReport1.rdlc";

            return Setting;
        }


        public static RegisterViewModel Detach(setting Setting)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return registerViewModel;
        }
    }
}