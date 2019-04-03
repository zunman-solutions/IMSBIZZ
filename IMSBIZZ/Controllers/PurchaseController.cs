using IMSBIZZ.DAL.IService;
using IMSBIZZ.Helper;
using IMSBIZZ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data;
using IMSBIZZ.DAL.DBModel;
using System.Data.SqlClient;
using System.Web.UI;
using System.Text;


namespace IMSBIZZ.Controllers
{
    [ElmahError]
    public class PurchaseController : Controller
    {
        IPurchaseService _purchaseService;
     

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
          
        }
        // GET: Purchase
        //[CustomAuthorize(Common.DataEntry, Common.Admin)]
        public ActionResult Index()
        {
                        return View();
        }


        [HttpPost]
        public ActionResult Save(Models.PurchaseViewModel.PurchaseServiceViewModel purcaseServiceViewModel)
        {
            Purchase purchase = new Purchase();
            int CompanyId = Convert.ToInt32(purcaseServiceViewModel.CompanyId);
            int BranchId = Convert.ToInt32(purcaseServiceViewModel.BranchId);


            purchase.CompanyId = CompanyId;
            purchase.BranchId = BranchId;
            purchase.FinancialyearId = purcaseServiceViewModel.FinancialYearId;
            purchase.InvoiceNumber = purcaseServiceViewModel.InvoiceNumber;

            purchase.PaymentModeId = purcaseServiceViewModel.PaymentModeId;
            purchase.PartyId = purcaseServiceViewModel.PartyId;
            purchase.Po_Date = purcaseServiceViewModel.PODate;
            purchase.PoNo = purcaseServiceViewModel.PONo;
            purchase.Note = purcaseServiceViewModel.Note;
            purchase.OtherExpenses = purcaseServiceViewModel.OtherExpenses;

            purchase.CreatedBy = purcaseServiceViewModel.CreatedBy;
            purchase.CreatedOn = purcaseServiceViewModel.CreatedDate;

            //insert into Purchase Payment Details 
            PurchasePaymentDetial purchasePaymentDetail = new PurchasePaymentDetial();
            purchasePaymentDetail.TaxAmount = purcaseServiceViewModel.TaxAmount;
            purchasePaymentDetail.DiscountAmount = purcaseServiceViewModel.DiscountAmount;
            purchasePaymentDetail.SubTotal = purcaseServiceViewModel.SubTotal;
            purchasePaymentDetail.GrandTotal = purcaseServiceViewModel.GrandTotal;
            purchasePaymentDetail.PaidAmnt = purcaseServiceViewModel.PaidAmnt;
            purchasePaymentDetail.GivenAmnt = purcaseServiceViewModel.GivenAmnt;
            purchasePaymentDetail.BalanceAmnt = purcaseServiceViewModel.BalanceAmnt;
            purchasePaymentDetail.FromTable = purcaseServiceViewModel.FromTable;
            purchase.PurchasePaymentDetials.Add(purchasePaymentDetail);

            foreach (var purchaseDetail in purcaseServiceViewModel.PurchaseDetailsViewModel)
            {
                int productId = Convert.ToInt32(purchaseDetail.ProductId);
                int batchId = Convert.ToInt32(purchaseDetail.BatchId);

                var qty = purchaseDetail.Quantity;
                //Add into Purchase Details table for each product
                PurchaseDetail purchaseDetails = new PurchaseDetail();
                purchaseDetails.ProductId = productId;
                purchaseDetails.BatchId = batchId;
                // purchaseDetails.tax_id = product.tax_id;
                purchaseDetails.UnitId = purchaseDetail.UnitId;
                purchaseDetails.TaxAmnt = purchaseDetail.TaxAmnt;
                purchaseDetails.DicountAmnt = purchaseDetail.DiscountAmnt;
                purchaseDetails.Quantity = qty;
                purchaseDetails.a = purchaseDetail.Amount;
                purchaseDetails.CreatedBy= purchaseDetail.CreatedBy;
                purchaseDetails.created_date = purchaseDetail.CreatedDate;
                purchaseDetails.status = true;

                var groupId = purchaseDetail.GroupId;

                // DataTable taxgroupTypes = helper.LINQToDataTable(context.SelectProductTaxGroup(groupId, productId, qty));
                //for (int j = 0; j <= taxgroupTypes.Rows.Count - 1; j++)
                //{
                //    ViewState["TotalTaxPercent"] = taxgroupTypes.Rows[j].Field<decimal>("totalTaxPercetage");
                //}

                //insert into tax group purchase
                tbl_purchasetaxgroup purchaseTaxGroup = new tbl_purchasetaxgroup();
                purchaseTaxGroup.group_id = groupId;
                purchaseTaxGroup.product_id = productId;
                //purchaseTaxGroup.totalTaxPercentage = (Decimal)ViewState["TotalTaxPercent"];
                purchaseTaxGroup.group_name = purchaseDetail.GroupName;
                //Get the Tax type saved from db 
                //insert into tax group detailes
                // var taxGroupTypes = context.tbl_productTaxGroup.Join(context.tbl_taxgroup, t => t.group_id, pt => pt.group_id, (t, pt) => new { t.group_id, pt.group_name, t.product_id }).Where(t => t.product_id == productId).ToList();


                //for (int j = 0; j <= taxgroupTypes.Rows.Count - 1; j++)
                foreach (var taxType in purchaseDetail.TaxGroupDetailsViewModel)
                {
                    tbl_purchasetaxgroupdetails purchaseTaxDetails = new tbl_purchasetaxgroupdetails();
                    purchaseTaxDetails.type_id = taxType.TypeId;
                    purchaseTaxDetails.tax_percentage = taxType.TaxPercentage;
                    purchaseTaxGroup.tbl_purchasetaxgroupdetails.Add(purchaseTaxDetails);
                }
                purchase.tbl_purchasetaxgroup.Add(purchaseTaxGroup);

                //Enter Details In tbl_ActualPurchaseTaxAndPrice : to get the original Values at the time of Purchase Return
                tbl_ActualPurchaseTaxAndPrice actualPurchase = new tbl_ActualPurchaseTaxAndPrice();
                actualPurchase.product_id = productId;
                actualPurchase.status = true;
                //actualPurchase.tax_percent = Convert.ToDecimal(gvpurchasedetails.Rows[i].Cells[10].Text);
                actualPurchase.purchase_rate = purchaseDetail.PurchaseRate;
                actualPurchase.discount_percent = purchaseDetail.DiscountPercentage;
                actualPurchase.discount_amnt = purchaseDetail.DiscountAmnt;
                actualPurchase.batch_id = batchId;
                actualPurchase.sale_price = purchaseDetail.SaleRate;
                actualPurchase.created_by = purchaseDetail.CreatedBy;
                actualPurchase.created_date = purchaseDetail.CreatedDate;

                //Add into Actual Purchase Tax And Return Table
                purchase.tbl_ActualPurchaseTaxAndPrice.Add(actualPurchase);


                //Add Stock if not exist or update the Stock against the product
                tbl_stock stock = new tbl_stock();
                if (!IsProductStockExists(CompanyId, BranchId, productId, batchId))
                {
                    stock.company_id = CompanyId;
                    stock.branch_id = BranchId;
                    stock.product_id = productId;
                    stock.batch_id = batchId;
                    stock.qty = Convert.ToInt32(qty);
                    stock.status = true;
                    stock.created_by = purchaseDetail.CreatedBy;
                    stock.created_date = purchaseDetail.CreatedDate;
                    context.tbl_stock.Add(stock);
                }
                else
                {
                    stock = context.tbl_stock.Where(w => w.company_id == CompanyId && w.branch_id == BranchId && w.product_id == productId && w.batch_id == batchId).FirstOrDefault();
                    stock.qty = stock.qty + Convert.ToInt32(qty);
                    stock.modified_by = purchaseDetail.CreatedBy;
                    stock.modified_date = purchaseDetail.CreatedDate;
                }
                purchase.tbl_purchasedetails.Add(purchaseDetails);
            }


            context.tbl_purchase.Add(purchase);

            _purchaseService.Add()
            return View();
        }
    }
}
