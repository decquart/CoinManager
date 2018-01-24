using BusinessLogicLayer.Infrastructure;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using PresentationLayer.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PresentationLayer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            NinjectModule walletModule = new WalletModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(walletModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
