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
        public static Setting Attach(RegisterViewModel registerViewModel)
        {
            Setting setting = new Setting();
            setting.CompanyId = registerViewModel.CompanyId;
            setting.BranchId = registerViewModel.BranchId;
            setting.UserId = registerViewModel.UserId;
            setting.CreatedBy = registerViewModel.FirstName;
            setting.CreatedOn = DateTime.Now;
            setting.InvoiceTemplateName = "PurchaseSaleReturnReport1.rdlc";

            return setting;
        }


        public static RegisterViewModel Detach(Setting Setting)
        {
            RegisterViewModel registerViewModel = new RegisterViewModel();

            return registerViewModel;
        }
    }
}