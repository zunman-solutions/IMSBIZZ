using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class ProductService : IProductService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Product> productRepository;

        public ProductService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            productRepository = unitOfWork.GenericRepository<Product>();
        }
        public IEnumerable<Product> Get(Expression<Func<Product, bool>> filter = null,
          Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Product> Products = productRepository.Get(filter, orderBy, includeProperties).ToList();
            return Products;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            IEnumerable<Product> Products = productRepository.GetAll().ToList();
            return Products;
        }

        public Product GetProductById(int id)
        {
            Product Product = productRepository.GetById(id);
            return Product;
        }

        public void Add(Product product)
        {
           
            productRepository.Add(product);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Product product)
        {
            productRepository.Update(product);
        }

        public void Delete(int id)
        {
            productRepository.Delete(id);
        }

    }
}
