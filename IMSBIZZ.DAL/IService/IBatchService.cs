﻿using IMSBIZZ.DAL.DBModel;
using IMSBIZZ.DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IMSBIZZ.DAL.IService
{
    public interface IBatchService
    {
        IEnumerable<Batch> Get(Expression<Func<Batch, bool>> filter = null,
         Func<IQueryable<Batch>, IOrderedQueryable<Batch>> orderBy = null,
         string includeProperties = "");
        IEnumerable<Batch> GetAllBatchs();
        Batch GetBatchById(int id);
        void Add(Batch batch);
        void Update(Batch batch);
        void Delete(int id);
        int SaveChanges();
        IEnumerable<Batch> ExecWithRowQuery(string query, params object[] parameters);
        IEnumerable<GetBatchByProductDTO> GetBatchByProduct(string query, params object[] parameters);
        
    }
}
