using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Company> companyRepository;

        public CompanyService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            companyRepository = unitOfWork.GenericRepository<Company>();
        }
        public IEnumerable<Company> Get(Expression<Func<Company, bool>> filter = null,
          Func<IQueryable<Company>, IOrderedQueryable<Company>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Company> Companys = companyRepository.Get(filter, orderBy, includeProperties).ToList();
            return Companys;
        }

        public IEnumerable<Company> GetAllCompanys()
        {
            IEnumerable<Company> Companys = companyRepository.GetAll().ToList();
            return Companys;
        }

        public Company GetCompanyById(int id)
        {
            Company Company = companyRepository.GetById(id);
            return Company;
        }

        public void Add(Company company)
        {
           
            companyRepository.Add(company);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Company company)
        {
            companyRepository.Update(company);
        }

        public void Delete(int id)
        {
            companyRepository.Delete(id);
        }

    }
}
