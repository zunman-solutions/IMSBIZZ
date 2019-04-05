using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{

    /// <summary>
    /// Make Instances of All Procedure and call through Repository
    /// </summary>
    public class StoredProcedureService : IStoredProcedureService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Batch> storedProcedureRepository;

        public StoredProcedureService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            storedProcedureRepository = unitOfWork.GenericRepository<Batch>();
        } 

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public IEnumerable<Batch> ExecWithStoreProcedure(string proceudureName, params object[] parameters)
        {
           return storedProcedureRepository.ExecWithStoreProcedure(proceudureName, parameters);
        }
    }
}
