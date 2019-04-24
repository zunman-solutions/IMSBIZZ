using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface ICountryService
    {
        IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null,
           Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = null,
           string includeProperties = "");
        IEnumerable<Country> GetAllCountrys();
        Country GetCountryById(int id);
        void Add(Country country);
        void Update(Country country);
        void Delete(int id);
        int SaveChanges();
        IEnumerable<Country> ExecWithRowQuery(string query, params object[] parameters);
    }
}
