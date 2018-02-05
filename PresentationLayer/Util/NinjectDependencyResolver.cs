using AutoMapper;
using BusinessLogicLayer.DTO;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using Ninject;
using Ninject.Modules;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PresentationLayer.Util
{
    public class NinjectDependencyResolver : NinjectModule
    {
        public override void Load()
        {
            AddBindings();
        }

        private void AddBindings()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IWalletService>().To<WalletService>();
        }
    }
}