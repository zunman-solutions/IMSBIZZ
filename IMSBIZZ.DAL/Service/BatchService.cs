using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class BatchService : IBatchService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Batch> batchRepository;

        public BatchService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            batchRepository = unitOfWork.GenericRepository<Batch>();
        }
        public IEnumerable<Batch> Get(Expression<Func<Batch, bool>> filter = null,
          Func<IQueryable<Batch>, IOrderedQueryable<Batch>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Batch> Batchs = batchRepository.Get(filter, orderBy, includeProperties).ToList();
            return Batchs;
        }

        public IEnumerable<Batch> GetAllBatchs()
        {
            IEnumerable<Batch> Batchs = batchRepository.GetAll().ToList();
            return Batchs;
        }

        public Batch GetBatchById(int id)
        {
            Batch Batch = batchRepository.GetById(id);
            return Batch;
        }

        public void Add(Batch batch)
        {

            batchRepository.Add(batch);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Batch batch)
        {
            batchRepository.Update(batch);
        }

        public void Delete(int id)
        {
            batchRepository.Delete(id);
        }

       public IEnumerable<Batch> ExecWithRowQuery(string query, params object[] parameters)
        {
            return batchRepository.ExecWithRowQuery(query, parameters);
        }
    }
}