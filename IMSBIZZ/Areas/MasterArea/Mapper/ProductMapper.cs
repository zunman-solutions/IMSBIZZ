using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;
using IMSBIZZ.DAL.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSBIZZ.Areas.MasterArea.Mapper
{
    public static class ProductMapper
    {
        public static Product Attach(ProductViewModel productviewmodel)
        {
            Product product = new Product();
            product.ProductId = productviewmodel.ProductId;
            product.ProductName = productviewmodel.ProductName;
            product.ProductCode = productviewmodel.ProductCode;
            product.HSNCode = productviewmodel.HSNCode;
            product.CompanyId = productviewmodel.CompanyId;
            product.BranchId = productviewmodel.BranchId;
            product.GodownId = productviewmodel.GodownId;
            product.RackId = productviewmodel.RackId;
            product.CategoryId = productviewmodel.CategoryId;
            product.UnitId = productviewmodel.UnitId;
            product.ReorderLevel = productviewmodel.ReorderLevel;
            product.PurchasPrice = productviewmodel.PurchasPrice;
            product.SalesPrice = productviewmodel.SalesPrice;
            product.CreatedBy = productviewmodel.CreatedBy;
            product.CreatedOn = productviewmodel.CreatedOn;
            product.UpdatedBy = productviewmodel.UpdatedBy;
            product.UpdatedOn = productviewmodel.UpdatedOn;
            product.Status = productviewmodel.Status;
            return product;
        }
        public static ProductViewModel Detach(Product product)
        {
            ProductViewModel productviewmodel = new ProductViewModel();
            productviewmodel.ProductId = product.ProductId;
            productviewmodel.ProductName = product.ProductName;
            productviewmodel.ProductCode = product.ProductCode;
            productviewmodel.HSNCode = product.HSNCode;
            productviewmodel.CompanyId = product.CompanyId;
            productviewmodel.BranchId = product.BranchId;
            productviewmodel.GodownId = product.GodownId;
            productviewmodel.RackId = product.RackId;
            productviewmodel.CategoryId = product.CategoryId;
            productviewmodel.UnitId = product.UnitId;
            productviewmodel.ReorderLevel = product.ReorderLevel;
            productviewmodel.PurchasPrice = product.PurchasPrice;
            productviewmodel.SalesPrice = product.SalesPrice;
            productviewmodel.CreatedBy = product.CreatedBy;
            productviewmodel.CreatedOn = product.CreatedOn;
            productviewmodel.UpdatedBy = product.UpdatedBy;
            productviewmodel.UpdatedOn = product.UpdatedOn;
            productviewmodel.Status = product.Status;

            return productviewmodel;
        }
    }
}