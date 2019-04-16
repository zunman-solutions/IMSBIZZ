using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class CategoryMapper
    {
        public static Category Attach(CategoryViewModel categoryviewmodel)
        {
            Category category = new Category();
            category.CategoryId = categoryviewmodel.CategoryId;
            category.CategoryName = categoryviewmodel.CategoryName;
            category.CompanyId = categoryviewmodel.CompanyId;
            category.BranchId = categoryviewmodel.BranchId;
            category.Status = categoryviewmodel.Status;
            category.CreatedBy = categoryviewmodel.CreatedBy;
            category.CreatedOn = categoryviewmodel.CreatedOn;
            category.UpdatedBy = categoryviewmodel.UpdatedBy;
            category.UpdatedOn = categoryviewmodel.UpdatedOn;
            return category;
        }
        public static CategoryViewModel Detach(Category category)
        {
            CategoryViewModel categoryviewmodel = new CategoryViewModel();

            categoryviewmodel.CategoryId = category.CategoryId;
            categoryviewmodel.CategoryName = category.CategoryName;
            categoryviewmodel.CompanyId = category.CompanyId;
            categoryviewmodel.BranchId = category.BranchId;
            categoryviewmodel.Status = category.Status;
            categoryviewmodel.CreatedBy = category.CreatedBy;
            categoryviewmodel.CreatedOn = category.CreatedOn;
            categoryviewmodel.UpdatedBy = category.UpdatedBy;
            categoryviewmodel.UpdatedOn = category.UpdatedOn;

            return categoryviewmodel;
        }
    }
}