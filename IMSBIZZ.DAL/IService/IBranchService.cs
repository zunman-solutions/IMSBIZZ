using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public interface IBranchService
    {

        IEnumerable<Branch> Get(Expression<Func<Branch, bool>> filter = null,
         Func<IQueryable<Branch>, IOrderedQueryable<Branch>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Branch> GetAllBranchs();
        Branch GetBranchById(int id);
        void Add(Branch batch);
        void Update(Branch batch);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<Branch> ExecWithRowQuery(string query, params object[] parameters);
    }
}
