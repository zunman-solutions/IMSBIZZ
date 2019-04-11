using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.DTO;
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
    public class ReportService : IReportService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<dynamic> storedProcedureRepository;

        public ReportService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            storedProcedureRepository = unitOfWork.GenericRepository<dynamic>();
        } 

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public IEnumerable<dynamic> ExecWithStoreProcedure(string proceudureName, params object[] parameters)
        {
            return storedProcedureRepository.ExecWithStoreProcedure(proceudureName, parameters);
        }

        public IEnumerable<dynamic> ExecWithRowQuery(string query, params object[] parameters)
        {
            return storedProcedureRepository.ExecWithRowQuery(query, parameters);
        }

        public IEnumerable<GetProductdetialsbygodownDTO> GetProductDetialsByGodown(string query, params object[] parameters)
        {
            return _dbContext.Database.SqlQuery<GetProductdetialsbygodownDTO>(query, parameters);
        }
    }
}
