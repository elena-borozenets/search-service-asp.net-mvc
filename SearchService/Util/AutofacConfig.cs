using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SearchService.Infrastructure.IRepositories;
using SearchService.Infrastructure.Repositories;
using SearchService.Facade.Facades;
using SearchService.Facade.IFacades;

namespace SearchService.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // регистрируем споставление типов
            builder.RegisterType<RecordRepository>().As<IRecordRepository>();

            builder.RegisterType<RecordFacade>().As<IRecordFacade>();

            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}