using Ninject.Modules;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Interfaces;

namespace PresentationLayer.Util
{
    public class WalletModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWalletService>().To<WalletService>();
        }
    }
}