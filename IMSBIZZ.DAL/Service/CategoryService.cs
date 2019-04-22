using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IMSBIZZ.DAL.Service
{
    public class CategoryService : ICategoryService
    {

        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Category> categoryRepository;

        public CategoryService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            categoryRepository = unitOfWork.GenericRepository<Category>();
        }
        public IEnumerable<Category> Get(Expression<Func<Category, bool>> filter = null,
         Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy = null,
         string includeProperties = "")
        {
            IEnumerable<Category> categories = categoryRepository.Get(filter, orderBy, includeProperties).ToList();
            return categories;
        }
        public IEnumerable<Category> GetAllCategories()
        {
            IEnumerable<Category> categories = categoryRepository.GetAll().ToList();
            return categories;
        }
        public Category GetCategoryById(int id)
        {
            Category category = categoryRepository.GetById(id);
            return category;
        }

        public void Add(Category category)
        {

            categoryRepository.Add(category);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Category category)
        {
            categoryRepository.Update(category);
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }

        public IEnumerable<Category> ExecWithRowQuery(string query, params object[] parameters)
        {
            return categoryRepository.ExecWithRowQuery(query, parameters);
        }

    }
}
