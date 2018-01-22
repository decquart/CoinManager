using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Repositories;
using DataAccessLayer.Interfaces;
using AutoMapper;
using DataAccessLayer.Entities;
using BusinessLogicLayer.DTO;
using Ninject;

namespace BusinessLogicLayer.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }


        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>()
                .WithConstructorArgument(connectionString);
          
            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type))).InSingletonScope();
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Wallet, WalletDTO>();
                cfg.CreateMap<Expense, ExpenseDTO>();
                cfg.CreateMap<Income, IncomeDTO>();
                cfg.CreateMap<ExpenseCategory, ExpenseCategoryDTO>();
                cfg.CreateMap<IncomeCategory, IncomeCategoryDTO>();
            });

            return config;
        }
    }
}
