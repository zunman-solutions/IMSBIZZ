using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface ITaxGroupService
    {
        IEnumerable<TaxGroup> Get(Expression<Func<TaxGroup, bool>> filter = null,
         Func<IQueryable<TaxGroup>, IOrderedQueryable<TaxGroup>> orderBy = null,
         string includeProperties = "");
        IEnumerable<TaxGroup> GetAllTaxGroups();
        TaxGroup GetTaxGroupById(int id);
        void Add(TaxGroup taxGroup);
        void Update(TaxGroup taxGroup);
        void Delete(int id);
        void SaveChanges();
    }
}
