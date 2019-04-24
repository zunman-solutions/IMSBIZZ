using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.DTO;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{

    /// <summary>
    /// Make Instances of All Procedure and call through Repository
    /// </summary>
    public class ReportService : IReportService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<dynamic> storedProcedureRepository;

        public ReportService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            storedProcedureRepository = unitOfWork.GenericRepository<dynamic>();
        } 

        public int SaveChanges()
        {
           return unitOfWork.SaveChanges();
        }

        public IEnumerable<dynamic> ExecWithStoreProcedure(string proceudureName, params object[] parameters)
        {
            return storedProcedureRepository.ExecWithStoreProcedure(proceudureName, parameters);
        }

        public IEnumerable<dynamic> ExecWithRowQuery(string query, params object[] parameters)
        {
            return storedProcedureRepository.ExecWithRowQuery(query, parameters);
        }

        public IEnumerable<GetProductdetialsbygodownDTO> GetProductDetialsByGodown(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<GetProductdetialsbygodownDTO>(query, parameters);
        }
        public IEnumerable<CompanyWiseVendorPaymentDetailsDTO> CompanyWiseVendorPaymentDetails(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<CompanyWiseVendorPaymentDetailsDTO>(query, parameters);
        }
        public IEnumerable<GodownProductsbyCompanyandbranchDTO> GodownProductsbyCompanyandbranch(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<GodownProductsbyCompanyandbranchDTO>(query, parameters);
        }
        public IEnumerable<SaleChartDetailsDTO> SaleChartDetails(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<SaleChartDetailsDTO>(query, parameters);
        }
        public IEnumerable<PurchaseChartDetailsDTO> PurchaseChartDetails(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<PurchaseChartDetailsDTO>(query, parameters);
        }
        public IEnumerable<SaleMonthlyCountDTO> SaleMonthlyCount(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<SaleMonthlyCountDTO>(query, parameters);
        }
        public IEnumerable<PurchaseMonthlyCountDTO> PurchaseMonthlyCount(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<PurchaseMonthlyCountDTO>(query, parameters);
        }
        public IEnumerable<VendorInvoicePreviousTransactionDTO> VendorInvoicesPreviosTransaction(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<VendorInvoicePreviousTransactionDTO>(query, parameters);
        }
        public IEnumerable<VendorBalanceReportDTO> VendorBalanceReport(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<VendorBalanceReportDTO>(query, parameters);
        }
        public IEnumerable<CustomerInvoicePreviousTransactionDTO> CustomerInvoicesPreviosTransaction(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<CustomerInvoicePreviousTransactionDTO>(query, parameters);
        }
        public IEnumerable<CustomerBalanceReportDTO> CustomerBalanceReport(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<CustomerBalanceReportDTO>(query, parameters);
        }
        public IEnumerable<GetVendorInvoicesDetailDTO> GetVendorInvoicesDetail(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<GetVendorInvoicesDetailDTO>(query, parameters);
        }
    }
}
