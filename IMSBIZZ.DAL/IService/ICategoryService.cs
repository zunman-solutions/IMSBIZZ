using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.IService
{
   public interface ICategoryService
    {
        IEnumerable<Category> Get(Expression<Func<Category, bool>> filter = null,
        Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
        string includeProperties = "");
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
        int SaveChanges();
        IEnumerable<Category> ExecWithRowQuery(string query, params object[] parameters);
    }
}
