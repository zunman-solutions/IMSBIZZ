using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IPurchaseService
    {
        IEnumerable<Purchase> Get(Expression<Func<Purchase, bool>> filter = null,
         Func<IQueryable<Purchase>, IOrderedQueryable<Purchase>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Purchase> GetAllPurchases();
        Purchase GetPurchaseById(int id);
        void Add(Purchase purchase);
        void Update(Purchase purchase);
        void Delete(int id);
        void SaveChanges();
        bool IsProductExist(int productId, int batchId, decimal saleRate, decimal purchaseRate, int taxGroupId);
    }
}
