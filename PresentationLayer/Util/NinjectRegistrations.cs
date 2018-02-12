using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject.Modules;

namespace PresentationLayer.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IWalletService>().To<WalletService>();
        }
    }
}