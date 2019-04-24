using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Purchase> purchaseRepository;
        private GenericRepository<Stock> stockRepository;

        public PurchaseService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            purchaseRepository = unitOfWork.GenericRepository<Purchase>();
            stockRepository = unitOfWork.GenericRepository<Stock>();
        }
        public IEnumerable<Purchase> Get(Expression<Func<Purchase, bool>> filter = null,
          Func<IQueryable<Purchase>, IOrderedQueryable<Purchase>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Purchase> purchases = purchaseRepository.Get(filter, orderBy, includeProperties).ToList();
            return purchases;
        }

        public IEnumerable<Purchase> GetAllPurchases()
        {
            IEnumerable<Purchase> purchases = purchaseRepository.GetAll().ToList();
            return purchases;
        }

        public Purchase GetPurchaseById(int id)
        {
            Purchase purchase = purchaseRepository.GetById(id);
            return purchase;
        }

        public void Add(Purchase purchase)
        {
            ////Add Stock if not exist or update the Stock against the product
            foreach (var purchaseDetail in purchase.PurchaseDetails)
            {
                Stock stock = new Stock();
                if (!IsProductStockExists(purchase.CompanyId, purchase.BranchId, purchaseDetail.ProductId, purchaseDetail.BatchId))
                {
                    stock.CompanyId = purchase.CompanyId;
                    stock.BranchId = purchase.BranchId;
                    stock.ProductId = purchaseDetail.ProductId;
                    stock.BatchId = purchaseDetail.BatchId;
                    stock.Quantity = Convert.ToInt32(purchaseDetail.Quantity);
                    stock.CreatedBy = purchase.CreatedBy;
                    stock.CreatedOn = purchase.CreatedOn;
                    stockRepository.Add(stock);
                }
                else {
                    stock = stockRepository.Get().Where(w => w.CompanyId == purchase.CompanyId && w.BranchId == purchase.BranchId && w.ProductId == purchaseDetail.ProductId && w.BatchId == purchaseDetail.BatchId).FirstOrDefault();
                    stock.Quantity = stock.Quantity + Convert.ToInt32(purchaseDetail.Quantity);
                    stock.UpdatedBy = purchase.CreatedBy;
                    stock.UpdatedOn = purchase.CreatedOn;
                }
            }
            purchaseRepository.Add(purchase);
        }

        public int SaveChanges()
        {
           return unitOfWork.SaveChanges();
        }

        public void Update(Purchase purchase)
        {
            purchaseRepository.Update(purchase);
        }

        public void Delete(int id)
        {
            purchaseRepository.Delete(id);
        }
               
        private bool IsProductStockExists(int? companyId, int? branchId, int? productId, int? batchId)
        {
            return stockRepository.Get().Where(w => w.CompanyId == companyId && w.BranchId == branchId && w.ProductId == productId && w.BatchId == batchId).Any();
        }

        public bool IsProductExist(int productId,int batchId,decimal saleRate,decimal purchaseRate,int taxGroupId)
        {
            bool isExist = false;
            var isProductExsits = _dbContext.PurchaseDetails.Join(_dbContext.Products, pd => pd.ProductId, p => p.ProductId,
                        (pd, p) => new { pd.ProductId, pd.TaxGroupId, pd.BatchId, pd.SaleRate, pd.PurchaseRate  }
                        ).Where(w => w.ProductId == productId && w.BatchId == batchId).FirstOrDefault();
            if (isProductExsits != null)
            {

                if (isProductExsits.SaleRate != saleRate || isProductExsits.PurchaseRate != purchaseRate || isProductExsits.TaxGroupId != taxGroupId)
                {
                    isExist = true;

                }
            }

            return isExist;

        }


    }
}
