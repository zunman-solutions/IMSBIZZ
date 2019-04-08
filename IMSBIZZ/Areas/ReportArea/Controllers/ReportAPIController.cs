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
            var sales = _reportService.ExecWithRowQuery(@"select s.InvoiceNumber,spd.BalanceAmnt,spd.GivenAmnt,spd.GrandTotal,pur.party_name,pur.created_date 
from Sale as s inner join Party as pur on s.PartyId = pur.PartyId
inner join SalePaymentDetails as spd on s.SaleId = spd.SaleId where spd.BalanceAmnt > 0 and s.CompanyId={0} and s.BranchId={1} order by  s.PartyId desc", companyId, branchId).ToList();
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
            var sales = _reportService.ExecWithRowQuery(@"select s.PartyId,count(s.PartyId)as SaleCount,p.PartyName,sum(spd.PaidAmnt) as PaidAmnt,sum(spd.BalanceAmnt)
as BalanceAmnt,sum(spd.GrandTotal) as GrandTotal from Sale s inner join Party p on s.PartyId = s.PartyId inner 
join SalePaymentDetials spd on s.SaleId = spd.SaleId where s.CompanyId={0} and s.BranchId={1}  group by s.PartyId,p.PartyName", companyId, branchId).ToList();
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
            var purchase = _reportService.ExecWithRowQuery(@"select p.PurchaseId,pur.PartyName,pd.GivenAmnt,pd.BalanceAmnt,pd.GrandTotal,pur.CreatedOn,p.InvoiceNumber
from Purchase as p inner join Party  pur on p.PartyId=pur.PartyId inner join PurchasePaymentDetials pd on p.PurchaseId=pd.PurchaseId where s.CompanyId={0} and s.BranchId={1} and pd.BalanceAmnt >0 order by p.CompanyId desc", companyId, branchId).ToList();
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
            var sales = _reportService.ExecWithRowQuery(@"select p.PartyId,count(p.PartyId) as PurchaseCount,par.PartyName,sum(ppd.PaidAmnt) as PaidAmnt,sum(ppd.BalanceAmnt) 
 as BalanceAmnt,sum(ppd.GrandTotal) as GrandTotal from Purchase p inner join Party par on p.PartyId = par.PartyId inner join PurchasePaymentDetials ppd on p.PurchaseId = ppd.PurchaseId
where p.CompanyId={0} and p.BranchId={1} and ppd.BalanceAmnt>0 group by p.PurchaseId,par.PartyName", companyId, branchId).ToList();
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
            var purchase = _reportService.ExecWithRowQuery(@"select COUNT(p.PurchaseId) as purchas_count,SUM(ppd.GrandTotal) as purchase_total from Purchase as p 
inner join PurchasePaymentDetials as ppd on p.PurchaseId =ppd.PurchaseId 
where DATEDIFF(DAY,p.CreatedOn,GETDATE()) <30  AND p.CompanyId={0} and p.BranchId={1}", companyId, branchId).ToList();
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
            var purchase = _reportService.ExecWithRowQuery(@"select COUNT(s.SaleId) as sale_id,SUM(spd.GrandTotal) as grandtotal from Sale as s 
inner join SalePaymentDetials as spd on s.SaleId = spd.SaleId  where DATEDIFF(DAY,s.CreatedOn,GETDATE()) <30   AND p.CompanyId={0} and p.BranchId={1}", companyId, branchId).ToList();
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
            var purchase = _reportService.ExecWithRowQuery(@"select top 5 p.ProductName, count(pd.ProductId) as [ProductCount], sum(pd.amount) as [TotalPuchase] 
            from PurchaseDetails pd inner join Purchase pur on pur.PurchaseId=pd.PurchaseId
            inner join Product p on p.ProductId = pd.ProductId  
            where p.CreatedOn between DATEADD(day,-30, getdate()) and getdate()    
            AND p.CompanyId={0} and p.BranchId={1}
            group by pd.ProductId, p.ProductName
            order by count(pd.ProductId) desc
   ", companyId, branchId).ToList();
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
            var purchase = _reportService.ExecWithRowQuery(@"select top 5 p.ProductName, count(sd.ProductId) as [ProductCount], sum(sd.amount) as [TotalSaleAmount] 
            from SaleDetails sd inner join Sale s on s.SaleId=sd.SaleId
            join Product p on p.ProductId = sd.ProductId  
            where s.CreatedOn between DATEADD(day,-30, getdate()) and getdate()
            AND p.CompanyId={0} and p.BranchId={1}
            group by sd.ProductId, p.ProductName
            order by count(sd.ProductId) desc   ", companyId, branchId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, purchase);
        }
    }
}
