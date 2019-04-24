using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class RackService : IRackService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Rack> rackRepository;

        public RackService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            rackRepository = unitOfWork.GenericRepository<Rack>();
        }
        public IEnumerable<Rack> Get(Expression<Func<Rack, bool>> filter = null,
          Func<IQueryable<Rack>, IOrderedQueryable<Rack>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Rack> Racks = rackRepository.Get(filter, orderBy, includeProperties).ToList();
            return Racks;
        }

        public IEnumerable<Rack> GetAllRacks()
        {
            IEnumerable<Rack> Racks = rackRepository.GetAll().ToList();
            return Racks;
        }

        public Rack GetRackById(int id)
        {
            Rack Rack = rackRepository.GetById(id);
            return Rack;
        }

        public void Add(Rack rack)
        {
           
            rackRepository.Add(rack);
        }

        public int SaveChanges()
        {
          return  unitOfWork.SaveChanges();
        }

        public void Update(Rack rack)
        {
            rackRepository.Update(rack);
        }

        public void Delete(int id)
        {
            rackRepository.Delete(id);
        }

    }
}
