using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IReportService
    {
        int SaveChanges();
        IEnumerable<dynamic> ExecWithStoreProcedure(string proceudureName, params object[] parameters);
        IEnumerable<dynamic> ExecWithRowQuery(string query, params object[] parameters);
        IEnumerable<GetProductdetialsbygodownDTO> GetProductDetialsByGodown(string query, params object[] parameters);

        IEnumerable<CompanyWiseVendorPaymentDetailsDTO> CompanyWiseVendorPaymentDetails(string query, params object[] parameters);

        IEnumerable<GodownProductsbyCompanyandbranchDTO> GodownProductsbyCompanyandbranch(string query, params object[] parameters);
        IEnumerable<SaleChartDetailsDTO> SaleChartDetails(string query, params object[] parameters);
        IEnumerable<PurchaseChartDetailsDTO> PurchaseChartDetails(string query, params object[] parameters);

        IEnumerable<SaleMonthlyCountDTO> SaleMonthlyCount(string query, params object[] parameters);
        
        IEnumerable<PurchaseMonthlyCountDTO> PurchaseMonthlyCount(string query, params object[] parameters);
        IEnumerable<VendorInvoicePreviousTransactionDTO> VendorInvoicesPreviosTransaction(string query, params object[] parameters);
        IEnumerable<VendorBalanceReportDTO> VendorBalanceReport(string query, params object[] parameters);
        IEnumerable<CustomerInvoicePreviousTransactionDTO> CustomerInvoicesPreviosTransaction(string query, params object[] parameters);
        IEnumerable<CustomerBalanceReportDTO> CustomerBalanceReport(string query, params object[] parameters);
        IEnumerable<GetVendorInvoicesDetailDTO> GetVendorInvoicesDetail(string query, params object[] parameters);
    }
}
