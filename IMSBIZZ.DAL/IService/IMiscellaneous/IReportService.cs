using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IReportService
    {
        void SaveChanges();
        IEnumerable<Batch> ExecWithStoreProcedure(string proceudureName, params object[] parameters);
        IEnumerable<Batch> ExecWithRowQuery(string query, params object[] parameters);


    }
}
