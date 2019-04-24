using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class BranchService : IBranchService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Branch> BranchRepository;

        public BranchService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            BranchRepository = unitOfWork.GenericRepository<Branch>();
        }
        public IEnumerable<Branch> Get(Expression<Func<Branch, bool>> filter = null,
          Func<IQueryable<Branch>, IOrderedQueryable<Branch>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Branch> Branchs = BranchRepository.Get(filter, orderBy, includeProperties).ToList();
            return Branchs;
        }

        public IEnumerable<Branch> GetAllBranchs()
        {
            IEnumerable<Branch> Branchs = BranchRepository.GetAll().ToList();
            return Branchs;
        }

        public Branch GetBranchById(int id)
        {
            Branch Branch = BranchRepository.GetById(id);
            return Branch;
        }

        public void Add(Branch Branch)
        {

            BranchRepository.Add(Branch);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Branch Branch)
        {
            BranchRepository.Update(Branch);
        }

        public void Delete(int id)
        {
            BranchRepository.Delete(id);
        }

       public IEnumerable<Branch> ExecWithRowQuery(string query, params object[] parameters)
        {
            return BranchRepository.ExecWithRowQuery(query, parameters);
        }
    }
}