using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IPartyService
    {
        IEnumerable<Party> Get(Expression<Func<Party, bool>> filter = null,
         Func<IQueryable<Party>, IOrderedQueryable<Party>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Party> GetAllPartys();
        Party GetPartyById(int id);
        void Add(Party party);
        void Update(Party party);
        void Delete(int id);
        void SaveChanges();        
    }
}
