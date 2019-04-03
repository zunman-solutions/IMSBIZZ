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

        public PurchaseService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            purchaseRepository = unitOfWork.GenericRepository<Purchase>();
        }
        public IEnumerable<Purchase> Get(Expression<Func<Purchase, bool>> filter = null,
          Func<IQueryable<Purchase>, IOrderedQueryable<Purchase>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Purchase> benificiaries = purchaseRepository.Get(filter, orderBy, includeProperties).ToList();
            return benificiaries;
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
            purchaseRepository.Add(purchase);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Purchase purchase)
        {
            purchaseRepository.Update(purchase);
        }

        public void Delete(int id)
        {
            purchaseRepository.Delete(id);
        }
    }
}
