using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.Service
{
    public class SettingService : ISettingService
    {
        private readonly IMSBIZZEntities _dbContext;
        private UnitOfWork unitOfWork;
        private GenericRepository<Setting> SettingRepository;

        public SettingService()
        {
            _dbContext = new IMSBIZZEntities();
            unitOfWork = new UnitOfWork(_dbContext);
            SettingRepository = unitOfWork.GenericRepository<Setting>();
        }
        public IEnumerable<Setting> Get(Expression<Func<Setting, bool>> filter = null,
          Func<IQueryable<Setting>, IOrderedQueryable<Setting>> orderBy = null,
          string includeProperties = "")
        {
            IEnumerable<Setting> Settings = SettingRepository.Get(filter, orderBy, includeProperties).ToList();
            return Settings;
        }

        public IEnumerable<Setting> GetAllSettings()
        {
            IEnumerable<Setting> Settings = SettingRepository.GetAll().ToList();
            return Settings;
        }

        public Setting GetSettingsById(int id)
        {
            Setting Setting = SettingRepository.GetById(id);
            return Setting;
        }

        public void Add(Setting Setting)
        {

            SettingRepository.Add(Setting);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Setting Setting)
        {
            SettingRepository.Update(Setting);
        }

        public void Delete(int id)
        {
            SettingRepository.Delete(id);
        }

       public IEnumerable<Setting> ExecWithRowQuery(string query, params object[] parameters)
        {
            return SettingRepository.ExecWithRowQuery(query, parameters);
        }
    }
}