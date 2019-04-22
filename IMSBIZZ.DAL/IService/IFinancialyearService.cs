using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IFinancialYearService
    {
        IEnumerable<FinancialYear> Get(Expression<Func<FinancialYear, bool>> filter = null,
         Func<IQueryable<FinancialYear>, IOrderedQueryable<FinancialYear>> orderBy = null,
         string includeProperties = "");
        IEnumerable<FinancialYear> GetAllFinancialYears();
        FinancialYear GetFinancialYearById(int id);
        void Add(FinancialYear FinancialYear);
        void Update(FinancialYear FinancialYear);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<FinancialYear> ExecWithRowQuery(string query, params object[] parameters);
    }
}
