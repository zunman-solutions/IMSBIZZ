using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Service;
using IMSBIZZ.Areas.MasterArea.Models.MasterViewModel;

namespace IMSBIZZ.Areas.MasterArea.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryservice;

        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }
        
        // GET: MasterArea/Category
        public ActionResult Index()
        {
            var categories = _categoryservice.GetAllCategories();
            var categoryviewmodel = categories.Select(c => new CategoryViewModel
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                
            }).ToList();
            return View(categoryviewmodel);
        }
    }
}