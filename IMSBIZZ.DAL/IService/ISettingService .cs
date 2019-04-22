using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public interface IsettingService
    {

        IEnumerable<setting> Get(Expression<Func<setting, bool>> filter = null,
         Func<IQueryable<setting>, IOrderedQueryable<setting>> orderBy = null,
         string includeProperties = "");
        IEnumerable<setting> GetAllSettings();
        setting GetSettingsById(int id);
        void Add(setting batch);
        void Update(setting batch);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<setting> ExecWithRowQuery(string query, params object[] parameters);
    }
}
