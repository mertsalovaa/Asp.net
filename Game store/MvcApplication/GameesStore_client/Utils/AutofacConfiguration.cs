using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using GamesStore_bll.Services.Abstraction;
using GamesStore_bll.Services.Implementation;
using GamesStore_dal;
using GamesStore_dal.Repository.Abstraction;
using GamesStore_dal.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameesStore_client.Utils
{
    public static class AutofacConfiguration
    {
        public static void ConfigurateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(ApplicationRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<GameService>().As<IGameService>();

            // Register mapper
            var mapperConfig = new MapperConfiguration(config => config.AddProfile(new AutomapperConfig()));
            builder.RegisterInstance<IMapper>(mapperConfig.CreateMapper());


            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}