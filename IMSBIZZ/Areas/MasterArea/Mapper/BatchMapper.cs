using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class BatchMapper
    {
        public static Batch Attach(BatchViewModel batchviewmodel)
        {
            Batch batch = new Batch();
            batch.BatchId = batchviewmodel.BatchId;
            batch.BatchName = batchviewmodel.BatchName;
            batch.CompanyId = batchviewmodel.CompanyId;
            batch.BranchId = batchviewmodel.BranchId;
            batch.Status = batchviewmodel.Status;
            batch.CreatedBy = batchviewmodel.CreatedBy;
            batch.CreatedOn = batchviewmodel.CreatedOn;
            batch.UpdatedBy = batchviewmodel.UpdatedBy;
            batch.UpdatedOn = batchviewmodel.UpdatedOn;
            return batch;
        }
        public static BatchViewModel Detach(Batch batch)
        {
            BatchViewModel batchviewmodel = new BatchViewModel();
            batchviewmodel.BatchId = batch.BatchId;
            batchviewmodel.BatchName = batch.BatchName;
            batchviewmodel.CompanyId = batch.CompanyId;
            batchviewmodel.BranchId = batch.BranchId;
            batchviewmodel.Status = batch.Status;
            batchviewmodel.CreatedBy = batch.CreatedBy;
            batchviewmodel.CreatedOn = batch.CreatedOn;
            batchviewmodel.UpdatedBy = batch.UpdatedBy;
            batchviewmodel.UpdatedOn = batch.UpdatedOn;
            return batchviewmodel;
        }

    }
}