using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IUserCompanyService
    {
        IEnumerable<UserCompany> Get(Expression<Func<UserCompany, bool>> filter = null,
         Func<IQueryable<UserCompany>, IOrderedQueryable<UserCompany>> orderBy = null,
         string includeProperties = "");
        IEnumerable<UserCompany> GetAllUserCompanys();
        UserCompany GetUserCompanyById(int id);
        void Add(UserCompany UserCompany);
        void Update(UserCompany UserCompany);
        void Delete(int id);
        void SaveChanges();
        IEnumerable<UserCompany> ExecWithRowQuery(string query, params object[] parameters);
       
        
    }
}
