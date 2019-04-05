using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IStockService
    {
        IEnumerable<Stock> Get(Expression<Func<Stock, bool>> filter = null,
         Func<IQueryable<Stock>, IOrderedQueryable<Stock>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Stock> GetAllStocks();
        Stock GetStockById(int id);
        void Add(Stock stock);
        void Update(Stock stock);
        void Delete(int id);
        void SaveChanges();        
    }
}
