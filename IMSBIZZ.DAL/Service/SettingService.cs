using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class SettingService : IsettingService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<setting> settingRepository;

        public SettingService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            settingRepository = unitOfWork.GenericRepository<setting>();
        }
        public IEnumerable<setting> Get(Expression<Func<setting, bool>> filter = null,
          Func<IQueryable<setting>, IOrderedQueryable<setting>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<setting> settings = settingRepository.Get(filter, orderBy, includeProperties).ToList();
            return settings;
        }

        public IEnumerable<setting> GetAllSettings()
        {
            IEnumerable<setting> settings = settingRepository.GetAll().ToList();
            return settings;
        }

        public setting GetSettingsById(int id)
        {
            setting setting = settingRepository.GetById(id);
            return setting;
        }

        public void Add(setting setting)
        {

            settingRepository.Add(setting);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(setting setting)
        {
            settingRepository.Update(setting);
        }

        public void Delete(int id)
        {
            settingRepository.Delete(id);
        }

       public IEnumerable<setting> ExecWithRowQuery(string query, params object[] parameters)
        {
            return settingRepository.ExecWithRowQuery(query, parameters);
        }
    }
}