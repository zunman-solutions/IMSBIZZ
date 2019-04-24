using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class PartyService : IPartyService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Party> partyRepository;

        public PartyService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            partyRepository = unitOfWork.GenericRepository<Party>();
        }
        public IEnumerable<Party> Get(Expression<Func<Party, bool>> filter = null,
          Func<IQueryable<Party>, IOrderedQueryable<Party>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Party> Partys = partyRepository.Get(filter, orderBy, includeProperties).ToList();
            return Partys;
        }

        public IEnumerable<Party> GetAllPartys()
        {
            IEnumerable<Party> Partys = partyRepository.GetAll().ToList();
            return Partys;
        }

        public Party GetPartyById(int id)
        {
            Party Party = partyRepository.GetById(id);
            return Party;
        }

        public void Add(Party party)
        {
           
            partyRepository.Add(party);
        }

        public int SaveChanges()
        {
         return   unitOfWork.SaveChanges();
        }

        public void Update(Party party)
        {
            partyRepository.Update(party);
        }

        public void Delete(int id)
        {
            partyRepository.Delete(id);
        }

    }
}
