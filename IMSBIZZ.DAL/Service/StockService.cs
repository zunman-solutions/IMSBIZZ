using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class StockService : IStockService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Stock> stockRepository;

        public StockService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            stockRepository = unitOfWork.GenericRepository<Stock>();
        }
        public IEnumerable<Stock> Get(Expression<Func<Stock, bool>> filter = null,
          Func<IQueryable<Stock>, IOrderedQueryable<Stock>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Stock> stocks= stockRepository.Get(filter, orderBy, includeProperties).ToList();
            return stocks;
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            IEnumerable<Stock> stocks = stockRepository.GetAll().ToList();
            return stocks;
        }

        public Stock GetStockById(int id)
        {
            Stock stock = stockRepository.GetById(id);
            return stock;
        }

        public void Add(Stock stock)
        {
            stockRepository.Add(stock);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Stock stock)
        {
            stockRepository.Update(stock);
        }

        public void Delete(int id)
        {
            stockRepository.Delete(id);
        }
    }
}
