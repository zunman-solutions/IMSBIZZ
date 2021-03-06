using IMSBIZZ.Controllers;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Service;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace IMSBIZZ
{

    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IMiscellaneousService, MiscellaneosService>();
            container.RegisterType<IReportService, ReportService>();
            container.RegisterType<IStoredProcedureService, StoredProcedureService>();
            container.RegisterType<IPurchaseService, PurchaseService>();
            container.RegisterType<IStockService, StockService>();
            container.RegisterType<IBatchService, BatchService>();
            container.RegisterType<IGodownService, GodownService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ITaxGroupService, TaxGroupService>();
            container.RegisterType<IStoredProcedureService, StoredProcedureService>();
            container.RegisterType<IRackService, RackService>();
            container.RegisterType<IPartyService, PartyService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<ISettingService, SettingService>();
            container.RegisterType<IFinancialYearService, FinancialYearService>();
            container.RegisterType<IBranchService, BranchService>();
            container.RegisterType<ICompanyService, CompanyService>();
            container.RegisterType<ICategoryService, CategoryService>();
            container.RegisterType<ICompanyService, CompanyService>();

            container.RegisterType<IUserCompanyService, UserCompanyService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}