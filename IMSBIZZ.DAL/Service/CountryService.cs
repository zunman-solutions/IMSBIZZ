using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
   public   class CountryService : ICountryService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Country> countryRepository;

        public CountryService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            countryRepository = unitOfWork.GenericRepository<Country>();
        }
        public IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null,
          Func<IQueryable<Country>, IOrderedQueryable<Country>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Country> Countrys = countryRepository.Get(filter, orderBy, includeProperties).ToList();
            return Countrys;
        }

        public IEnumerable<Country> GetAllCountrys()
        {
            IEnumerable<Country> Countrys = countryRepository.GetAll().ToList();
            return Countrys;
        }

        public Country GetCountryById(int id)
        {
            Country country = countryRepository.GetById(id);
            return country;
        }

        public void Add(Country country)
        {

            countryRepository.Add(country);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Country country)
        {
            countryRepository.Update(country);
        }

        public void Delete(int id)
        {
            countryRepository.Delete(id);
        }

        public IEnumerable<Country> ExecWithRowQuery(string query, params object[] parameters)
        {
            return countryRepository.ExecWithRowQuery(query, parameters);
        }
    }
}
