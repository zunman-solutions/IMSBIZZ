using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IRackService
    {
        IEnumerable<Rack> Get(Expression<Func<Rack, bool>> filter = null,
         Func<IQueryable<Rack>, IOrderedQueryable<Rack>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Rack> GetAllRacks();
        Rack GetRackById(int id);
        void Add(Rack rack);
        void Update(Rack rack);
        void Delete(int id);
        int SaveChanges();        
    }
}
