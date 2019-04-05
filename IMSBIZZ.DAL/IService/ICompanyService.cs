using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface ICompanyService
    {
        IEnumerable<Company> Get(Expression<Func<Company, bool>> filter = null,
         Func<IQueryable<Company>, IOrderedQueryable<Company>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Company> GetAllCompanys();
        Company GetCompanyById(int id);
        void Add(Company company);
        void Update(Company company);
        void Delete(int id);
        void SaveChanges();        
    }
}
