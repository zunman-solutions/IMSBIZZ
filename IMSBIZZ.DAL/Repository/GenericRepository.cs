using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.Repository
{
   public  class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly IMSBIZZEntities dbContext = null;
        private DbSet<TEntity> entityTable = null;

        public GenericRepository(IMSBIZZEntities _dbContext)
        {
            dbContext = _dbContext;            
            this.entityTable= dbContext.Set<TEntity>();
        }
        public virtual IEnumerable<TEntity> GetAllExpression(
             Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
             params Expression<Func<TEntity, object>>[] navigationPropeties)
        {
            IQueryable<TEntity> dbQuery = entityTable;

            if (filter != null)
            {
                dbQuery = dbQuery.Where(filter);
            }

            foreach (Expression<Func<TEntity, object>> nProperty in navigationPropeties)
                dbQuery = dbQuery.Include<TEntity, object>(nProperty);

            if (orderBy != null)
            {
                dbQuery = orderBy(dbQuery);
            }

            return dbQuery.ToList();
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,string includeProperties = "")
        {
            IQueryable<TEntity> query = entityTable;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return entityTable.ToList();
        }

        public TEntity GetById(int id)
        {
            return entityTable.Find(id);
        }
        public void Add(TEntity entity)
        {
            entityTable.Add(entity);
        }
        public void Update(TEntity entity)
        {
            entityTable.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            TEntity existing = entityTable.Find(id);
            entityTable.Remove(existing);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                entityTable.Attach(entityToDelete);
            }
            entityTable.Remove(entityToDelete);
        }

        public IEnumerable<TEntity> ExecWithStoreProcedure(string procedureName, params object[] parameters)
        {
            return dbContext.Database.SqlQuery<TEntity>(procedureName, parameters);
        }

        public IEnumerable<TEntity> ExecWithRowQuery(string query, params object[] parameters)
        {
            return dbContext.Database.SqlQuery<TEntity>(query, parameters);
        }

        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return entityTable.AsQueryable().Any(predicate);
        }       
    }
}
