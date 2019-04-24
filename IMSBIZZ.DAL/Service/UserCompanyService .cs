using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class UserCompanyService : IUserCompanyService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<UserCompany> UserCompanyRepository;

        public UserCompanyService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            UserCompanyRepository = unitOfWork.GenericRepository<UserCompany>();
        }
        public IEnumerable<UserCompany> Get(Expression<Func<UserCompany, bool>> filter = null,
          Func<IQueryable<UserCompany>, IOrderedQueryable<UserCompany>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<UserCompany> UserCompanys = UserCompanyRepository.Get(filter, orderBy, includeProperties).ToList();
            return UserCompanys;
        }

        public IEnumerable<UserCompany> GetAllUserCompanys()
        {
            IEnumerable<UserCompany> UserCompanys = UserCompanyRepository.GetAll().ToList();
            return UserCompanys;
        }

        public UserCompany GetUserCompanyById(int id)
        {
            UserCompany UserCompany = UserCompanyRepository.GetById(id);
            return UserCompany;
        }

        public void Add(UserCompany UserCompany)
        {

            UserCompanyRepository.Add(UserCompany);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(UserCompany UserCompany)
        {
            UserCompanyRepository.Update(UserCompany);
        }

        public void Delete(int id)
        {
            UserCompanyRepository.Delete(id);
        }

       public IEnumerable<UserCompany> ExecWithRowQuery(string query, params object[] parameters)
        {
            return UserCompanyRepository.ExecWithRowQuery(query, parameters);
        }
    }
}