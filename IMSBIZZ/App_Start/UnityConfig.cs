using IMSBIZZ.Controllers;
using IMSBIZZ.DAL.IService;
using IMSBIZZ.DAL.Service;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Injection;
using Unity.WebApi;

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
            container.RegisterType<IPurchaseService, PurchaseService>();
            container.RegisterType<IStockService, StockService>();
            container.RegisterType<IBatchService, BatchService>();
            container.RegisterType<IProductService, ProductService>();
            container.RegisterType<ITaxGroupService, TaxGroupService>();
            container.RegisterType<IStoredProcedureService, StoredProcedureService>();
            container.RegisterType<IRackService, RackService>();
            container.RegisterType<IPartyService, PartyService>();
            container.RegisterType<ICountryService, CountryService>();
            container.RegisterType<AccountController>(
              new InjectionConstructor(
                container.Resolve<ICountryService>()));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}