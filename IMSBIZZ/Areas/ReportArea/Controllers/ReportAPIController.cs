using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMSBIZZ.Areas.ReportArea.Controllers
{
    /// <summary>
    /// Report Api Controller
    /// </summary>
    [ElmahError]
    [RoutePrefix("api/Report")]
    public class ReportAPIController : ApiController
    {
        private readonly IReportService _reportService;

        /// <summary>
        /// Report Api Constructor
        /// </summary>
        /// <param name="purchaseService">Purchase Service Injiection</param>
        /// <param name="stockService">Stock Service Injection</param>
        public ReportAPIController(IReportService reportService)
        {
            _reportService = reportService;
        }

        /// <summary>
        /// Get Customer Balance Report
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("CustomerBalanceReport"), HttpGet]
        public HttpResponseMessage CustomerBalanceReport(int companyId, int branchId)
        {
            var sales = _reportService.ExecWithRowQuery(@"SELECT s.InvoiceNumber,spd.BalanceAmnt,spd.GivenAmnt,spd.GrandTotal,pur.PartyName,pur.CreatedOn
                                                         FROM Sale AS s
                                                         INNER JOIN Party AS pur ON s.PartyId = pur.PartyId
                                                         INNER JOIN SalePaymentDetials as spd on s.SaleId = spd.SaleId
                                                         WHERE spd.BalanceAmnt > 0 and s.CompanyId={0} and s.BranchId={1} 
                                                         ORDER BY  s.PartyId desc", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sales);
        }

        /// <summary>
        /// get customer invoices number of previous transaction
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("CustomerBalanceReport"), HttpGet]
        public HttpResponseMessage GetCustomerInvoicesPreviosTransaction(int companyId, int branchId)
        {
            var sales = _reportService.ExecWithRowQuery(@"SELECT s.PartyId,count(s.PartyId) AS SaleCount,p.PartyName,sum(spd.PaidAmnt) AS PaidAmnt,
                                                                 sum(spd.BalanceAmnt) AS BalanceAmnt,sum(spd.GrandTotal) AS GrandTotal
                                                          FROM Sale s 
                                                          INNER JOIN Party p ON s.PartyId = s.PartyId 
                                                          INNER JOIN SalePaymentDetials spd ON s.SaleId = spd.SaleId
                                                          WHERE s.CompanyId={0} and s.BranchId={1}
                                                          GROUP BY s.PartyId,p.PartyName", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sales);
        }

        /// <summary>
        /// Get Vendor Balance Report
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("CustomerBalanceReport"), HttpGet]
        public HttpResponseMessage VendorBalanceReport(int companyId, int branchId)
        {
            var purchase = _reportService.ExecWithRowQuery(@"SELECT p.PurchaseId,pur.PartyName,pd.GivenAmnt,pd.BalanceAmnt,pd.GrandTotal,pur.CreatedOn,p.InvoiceNumber
                                                             FROM Purchase as p
                                                             INNER JOIN Party  pur on p.PartyId=pur.PartyId
                                                             INNER JOIN PurchasePaymentDetials pd on p.PurchaseId=pd.PurchaseId 
                                                             WHERE p.CompanyId={0} and p.BranchId={1} and pd.BalanceAmnt > 0
                                                             ORDER BY p.CompanyId DESC", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }

        /// <summary>
        /// Get customer invoices number of previous transaction
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("CustomerBalanceReport"), HttpGet]
        public HttpResponseMessage GetVendorInvoicesPreviosTransaction(int companyId, int branchId)
        {
            var sales = _reportService.ExecWithRowQuery(@"SELECT p.PartyId,count(p.PartyId) AS PurchaseCount,par.PartyName,sum(ppd.PaidAmnt) AS PaidAmnt,
                                                                 sum(ppd.BalanceAmnt) AS BalanceAmnt,sum(ppd.GrandTotal) AS GrandTotal 
                                                          FROM Purchase p
                                                          INNER JOIN Party par ON p.PartyId = par.PartyId 
                                                          INNER JOIN PurchasePaymentDetials ppd ON p.PurchaseId = ppd.PurchaseId
                                                          where p.CompanyId={0} AND p.BranchId={1} AND ppd.BalanceAmnt> 0
                                                          GROUP BY p.PartyId,par.PartyName", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sales);
        }

        /// <summary>
        /// Get customer invoices number of previous transaction
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        ///  /// <param name="invoiceNumber">Invoice Number Filter</param>
        /// <returns></returns>
        [Route("GetVendorInvoicesDetail"), HttpGet]
        public HttpResponseMessage GetVendorInvoicesDetail(string invoiceNumber ,int companyId, int branchId)
        {
            var sales = _reportService.ExecWithRowQuery(@"WITH PurchaseAndPurchaseReturn(Id,Batch,Company,CompanyAddress,Party,PartyAddress,StartDate,EndDate,InvoiceNumber,PoNo,Product,PurchaseRate,SaleRate,Quantity,TaxAmnt,DiscountAmnt,ProductAmount,TotalTax,TotalDiscount,TotalAmount,GrandTotal,GivenAmnt,BalanceAmnt,PaymentMode,Date,Type)
AS
(
 (SELECT p.PurchaseId,b.BatchName,c.CompanyName,c.CompanyAddress,pa.PartyName,pa.PartyAddress,f.StartDate,f.EndDate,p.InvoiceNumber,p.PoNo,ProductName,pd.PurchaseRate,pd.SaleRate,quantity,pd.TaxAmnt,isnull(pd.DicountAmnt,0)
        ,pd.amount,payd.TaxAmount,payd.DiscountAmount,payd.SubTotal,payd.GrandTotal,payd.GivenAmnt,payd.BalanceAmnt,pm.PaymentmodeName,p.CreatedOn,'Purchase'
        FROM Purchase p Inner Join Purchasedetails pd on p.PurchaseId=pd.PurchaseId inner join Product on pd.ProductId=Product.ProductId 
        inner join PaymentMode pm on p.[PaymentModeId]=pm.[PaymentModeId] inner join Batch b on b.BatchId=pd.BatchId inner join Company c on c.CompanyId=p.CompanyId inner join FinancialYear f on f.FinancialYearId=p.FinancialYearId
        inner join Party pa on pa.PartyId=p.PartyId 
        inner join PurchasePaymentDetials payd on payd.PurchaseId=p.PurchaseId and payd.FromTable='Purchase')
		 UNion ALL 
        (SELECT p.PurchaseId,b.BatchName,c.CompanyName,c.CompanyAddress,pa.PartyName,pa.PartyAddress,f.StartDate,f.EndDate,p.InvoiceNumber,'',ProductName,pd.PurchaseRate,pd.saleRate,quantity,pd.TaxAmnt,
        isnull(pd.DiscountAmnt,0),pd.amount,payd.TaxAmount,payd.DiscountAmount,payd.SubTotal,payd.GrandTotal,payd.GivenAmnt,payd.BalanceAmnt,pm.PaymentmodeName,p.CreatedOn,'Return'
        FROM Purchasereturn p  inner join Purchasereturndetails pd on p.PurchaseReturnId=pd.PurchaseReturnId   inner join Product on pd.ProductId=Product.ProductId 
        inner join PaymentMode pm on p.[PaymentModeId]=pm.[PaymentModeId] inner join Batch b on b.BatchId=pd.BatchId inner join Company c on c.CompanyId=p.CompanyId inner join FinancialYear f on f.FinancialYearId=p.FinancialYearId
        inner join Party pa on pa.PartyId=p.PartyId 
        inner join PurchasePaymentDetials payd on payd.PurchaseId=p.PurchaseId and payd.FromTable='Return')  
        )
        SELECT * from PurchaseAndPurchaseReturn p   where p.InvoiceNumber={0} and p.CompanyId={1}and p.BranchId={2} order by Date ASC", invoiceNumber, companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sales);
        }

        /// <summary>
        /// Get Purchase Monthy Count 
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("PurchaseMonthlyCount"), HttpGet]
        public HttpResponseMessage PurchaseMonthlyCount(int companyId, int branchId)
        {
            var purchase = _reportService.ExecWithRowQuery(@"SELECT COUNT(p.PurchaseId) AS purchas_count,SUM(ppd.GrandTotal) AS purchase_total 
                                                             FROM Purchase as p 
                                                             INNER JOIN PurchasePaymentDetials AS ppd ON p.PurchaseId =ppd.PurchaseId 
                                                             WHERE DATEDIFF(DAY,p.CreatedOn,GETDATE()) <30  AND p.CompanyId={0} AND p.BranchId={1}", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }

        /// <summary>
        /// Get Sale Monthy Count 
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("SaleMonthlyCount"), HttpGet]
        public HttpResponseMessage SaleMonthlyCount(int companyId, int branchId)
        {
            var purchase = _reportService.ExecWithRowQuery(@"SELECT COUNT(s.SaleId) AS sale_id,SUM(spd.GrandTotal) AS grandtotal
                                                             FROM Sale AS s 
                                                             INNER JOIN SalePaymentDetials AS spd on s.SaleId = spd.SaleId
                                                             WHERE DATEDIFF(DAY,s.CreatedOn,GETDATE()) <30 
                                                             AND s.CompanyId={0} AND s.BranchId={1}", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }

        /// <summary>
        /// Get Purchase Monthy Count 
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("PurchaseChartDetails"), HttpGet]
        public HttpResponseMessage PurchaseChartDetails(int companyId, int branchId)
        {
            var purchase = _reportService.ExecWithRowQuery(@"SELECT top 5 p.ProductName, count(pd.ProductId) as [ProductCount], sum(pd.amount) as [TotalPuchase] 
                                                             FROM PurchaseDetails pd 
                                                             INNER JOIN Purchase pur ON pur.PurchaseId=pd.PurchaseId
                                                             INNER JOIN Product p on p.ProductId = pd.ProductId  
                                                             WHERE p.CreatedOn between DATEADD(day,-30, getdate()) and getdate()    
                                                             AND p.CompanyId={0} and p.BranchId={1}
                                                             GROUP BY pd.ProductId, p.ProductName
                                                             ORDER BY count(pd.ProductId) DESC", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }

        /// <summary>
        /// Get Sale Monthy Count 
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("SaleChartDetails"), HttpGet]
        public HttpResponseMessage SaleChartDetails(int companyId, int branchId)
        {
            var purchase = _reportService.ExecWithRowQuery(@"SELECT TOP 5 p.ProductName, count(sd.ProductId) AS [ProductCount], sum(sd.amount) AS [TotalSaleAmount] 
                                                             FROM SaleDetails sd
                                                             INNER JOIN Sale s ON s.SaleId=sd.SaleId
                                                             INNER JOIN Product p ON p.ProductId = sd.ProductId  
                                                             WHERE s.CreatedOn BETWEEN DATEADD(day,-30, getdate()) AND GETDATE()
                                                             AND p.CompanyId={0} AND p.BranchId={1}
                                                             GROUP BY sd.ProductId, p.ProductName
                                                             ORDER BY count(sd.ProductId) DESC   ", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }

        /// <summary>
        /// Get Available Product in Godown by Company and Branch
        /// </summary>
        /// <param name="companyId">Company Id Filter</param>
        /// <param name="branchId">Branch Id Filter</param>
        /// <returns></returns>
        [Route("GetGodownProductsbyCompanyandbranch"), HttpGet]
        public HttpResponseMessage GetGodownProductsbyCompanyandbranch(int companyId, int branchId)
        {
            var productsInGodown = _reportService.ExecWithRowQuery(@"SELECT g.godownId,g.godownname,COUNT(p.ProductName)product_no,SUM(s.Quantity)quantity 
                                                             FROM Godown AS g
                                                             INNER JOIN  Product AS p ON g.GodownId=p.GodownId
                                                             INNER JOIN Stock AS s ON s.ProductId=p.ProductId
                                                             WHERE g.CompanyId={0} AND g.BranchId ={1}
                                                             GROUP BY g.GodownName,g.GodownId", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, productsInGodown);
        }
        /// <summary>
        /// Godown wise product Details
        /// </summary>
        /// <param name="godownId">Godown Id Filter</param>
        /// <returns></returns>
        [Route("GetProductDetialsByGodown"), HttpGet]
        public HttpResponseMessage GetProductDetialsByGodown(int godownId)
        {
            var productdetails = _reportService.GetProductDetialsByGodown(@"SELECT g.GodownName,p.ProductName,p.ProductCode,p.HSNCode,s.Quantity,b.BatchName
	                                                                    FROM 
		                                                                    Godown AS g 
		                                                                    INNER JOIN Product AS p ON g.GodownId=p.GodownId
		                                                                    INNER JOIN Stock AS s ON s.ProductId=p.ProductId
		                                                                    INNER JOIN Batch AS b ON b.BatchId=s.BatchId 
		                                                                    INNER JOIN Company AS c ON c.CompanyId=s.CompanyId
	                                                                    WHERE 
		                                                                    g.GodownId={0}
	                                                                    ORDER BY 
		                                                                    g.GodownId DESC", godownId).ToList();
            

            return Request.CreateResponse(HttpStatusCode.OK, productdetails);

        }

        /// <summary>
        /// Get Company wise vendor payment detials 
        /// </summary>
        /// <param name="companyId">companyId Id Filter</param>
        /// <returns></returns>
        [Route("CompanyWiseVendorPaymentDetails"), HttpGet]
        public HttpResponseMessage CompanyWiseVendorPaymentDetails(int companyId)
        {
            // create a new JSON object to write out
            var productdetails = _reportService.ExecWithRowQuery(@"SELECT 
	                                                                  p.PartyName,pur.InvoiceNumber,pur.CreatedOn,ppd.PaidAmnt,BalanceAmnt,ppd.GrandTotal
	                                                               FROM 
                                                                      Purchase AS pur
                                                                      INNER JOIN PurchasePaymentDetials AS ppd ON pur.PurchaseId = ppd.PurchaseId
                                                                      INNER JOIN Party AS p ON pur.PartyId = p.PartyId
	                                                                WHERE 
		                                                              pur.CompanyId={0}", companyId).ToList();

            return Request.CreateResponse(HttpStatusCode.OK, productdetails);
        }
    }
}
