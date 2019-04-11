using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.IService
{
    public interface IGodownService
    {
        IEnumerable<Godown> Get(Expression<Func<Godown, bool>> filter = null,
        Func<IQueryable<Godown>, IOrderedQueryable<Godown>> orderBy = null,
        string includeProperties = "");
        IEnumerable<Godown> GetAllGodowns();
        Godown GetGodownById(int id);
        void Add(Godown godown);
        void Update(Godown godown);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<Godown> ExecWithRowQuery(string query, params object[] parameters);
    }
}
