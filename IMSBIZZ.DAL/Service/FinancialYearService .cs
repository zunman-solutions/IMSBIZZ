using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class FinancialYearService : IFinancialYearService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<FinancialYear> FinancialYearRepository;

        public FinancialYearService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            FinancialYearRepository = unitOfWork.GenericRepository<FinancialYear>();
        }
        public IEnumerable<FinancialYear> Get(Expression<Func<FinancialYear, bool>> filter = null,
          Func<IQueryable<FinancialYear>, IOrderedQueryable<FinancialYear>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<FinancialYear> FinancialYears = FinancialYearRepository.Get(filter, orderBy, includeProperties).ToList();
            return FinancialYears;
        }

        public IEnumerable<FinancialYear> GetAllFinancialYears()
        {
            IEnumerable<FinancialYear> FinancialYears = FinancialYearRepository.GetAll().ToList();
            return FinancialYears;
        }

        public FinancialYear GetFinancialYearById(int id)
        {
            FinancialYear FinancialYear = FinancialYearRepository.GetById(id);
            return FinancialYear;
        }

        public void Add(FinancialYear FinancialYear)
        {

            FinancialYearRepository.Add(FinancialYear);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(FinancialYear FinancialYear)
        {
            FinancialYearRepository.Update(FinancialYear);
        }

        public void Delete(int id)
        {
            FinancialYearRepository.Delete(id);
        }

       public IEnumerable<FinancialYear> ExecWithRowQuery(string query, params object[] parameters)
        {
            return FinancialYearRepository.ExecWithRowQuery(query, parameters);
        }
    }
}