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
    public class GodownService : IGodownService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Godown> godownRepository;

        public GodownService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            godownRepository = unitOfWork.GenericRepository<Godown>();
        }
        public IEnumerable<Godown> Get(Expression<Func<Godown, bool>> filter = null,
          Func<IQueryable<Godown>, IOrderedQueryable<Godown>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Godown> Godowns = godownRepository.Get(filter, orderBy, includeProperties).ToList();
            return Godowns;
        }

        public IEnumerable<Godown> GetAllGodowns()
        {
            IEnumerable<Godown> Godowns = godownRepository.GetAll().ToList();
            return Godowns;
        }

        public Godown GetGodownById(int id)
        {
            Godown Godown = godownRepository.GetById(id);
            return Godown;
        }

        public void Add(Godown godown)
        {

            godownRepository.Add(godown);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Godown godown)
        {
            godownRepository.Update(godown);
        }
        public void Delete(int id)
        {
            godownRepository.Delete(id);
        }

        public IEnumerable<Godown> ExecWithRowQuery(string query, params object[] parameters)
        {
            return godownRepository.ExecWithRowQuery(query, parameters);
        }
    }
}
