using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Interface
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        //With Expression Include Properties
        IEnumerable<TEntity> GetAllExpression(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] navigationPropeties);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(int id);
        IEnumerable<TEntity> ExecWithStoreProcedure(string procedureName, params object[] parameters);
        IEnumerable<TEntity> ExecWithRowQuery(string query, params object[] parameters);
        bool Exists(Expression<Func<TEntity, bool>> predicate);
    }
}
