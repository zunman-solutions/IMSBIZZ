using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class TaxGroupService : ITaxGroupService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<TaxGroup> taxGroupRepository;

        public TaxGroupService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            taxGroupRepository = unitOfWork.GenericRepository<TaxGroup>();
        }
        public IEnumerable<TaxGroup> Get(Expression<Func<TaxGroup, bool>> filter = null,
          Func<IQueryable<TaxGroup>, IOrderedQueryable<TaxGroup>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<TaxGroup> TaxGroups = taxGroupRepository.Get(filter, orderBy, includeProperties).ToList();
            return TaxGroups;
        }

        public IEnumerable<TaxGroup> GetAllTaxGroups()
        {
            IEnumerable<TaxGroup> TaxGroups = taxGroupRepository.GetAll().ToList();
            return TaxGroups;
        }

        public TaxGroup GetTaxGroupById(int id)
        {
            TaxGroup TaxGroup = taxGroupRepository.GetById(id);
            return TaxGroup;
        }

        public void Add(TaxGroup taxGroup)
        {
           
            taxGroupRepository.Add(taxGroup);
        }

        public int SaveChanges()
        {
           return unitOfWork.SaveChanges();
        }

        public void Update(TaxGroup taxGroup)
        {
            taxGroupRepository.Update(taxGroup);
        }

        public void Delete(int id)
        {
            taxGroupRepository.Delete(id);
        }

        

    }
}
