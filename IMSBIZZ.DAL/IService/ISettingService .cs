using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public interface ISettingService
    {

        IEnumerable<Setting> Get(Expression<Func<Setting, bool>> filter = null,
         Func<IQueryable<Setting>, IOrderedQueryable<Setting>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Setting> GetAllSettings();
        Setting GetSettingsById(int id);
        void Add(Setting batch);
        void Update(Setting batch);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<Setting> ExecWithRowQuery(string query, params object[] parameters);
    }
}
