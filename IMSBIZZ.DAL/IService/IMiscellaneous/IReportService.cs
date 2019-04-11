using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IReportService
    {
        void SaveChanges();
        IEnumerable<dynamic> ExecWithStoreProcedure(string proceudureName, params object[] parameters);
        IEnumerable<dynamic> ExecWithRowQuery(string query, params object[] parameters);
        IEnumerable<GetProductdetialsbygodownDTO> GetProductDetialsByGodown(string query, params object[] parameters);

    }
}
