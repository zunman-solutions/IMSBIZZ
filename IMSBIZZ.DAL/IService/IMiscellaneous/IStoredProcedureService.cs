using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IStoredProcedureService
    {
        int SaveChanges();
        IEnumerable<Batch> ExecWithStoreProcedure(string proceudureName, params object[] parameters);
        
    }
}
