using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IProductService
    {
        IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null,
         Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
        void SaveChanges();        
    }
}
