using Autofac;
using Autofac.Features.ResolveAnything;
using Foo.AppServices;
using Foo.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Foo.App.Boots
{
    public class ContainerConfig
    {
        public static IContainer Container { get; set; }

        public static IContainer Setup()
        {
            var builder = new ContainerBuilder();

            var loggerFactory = CreateLoggerFactory();
            builder.RegisterInstance(loggerFactory).SingleInstance();

            var fooDbContext = CreateFooDbContext(true);
            builder.RegisterInstance(fooDbContext).SingleInstance();

            builder.RegisterType<Seed>().SingleInstance();
            builder.RegisterType<AccountAppService>().As<IAccountAppService>().InstancePerLifetimeScope();

            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            Container = builder.Build();
            return Container;
        }
        
        private static FooDbContext CreateFooDbContext(bool ensureDeleted)
        {
            var loggerFactory = CreateLoggerFactory();
            var optionsBuilder = new DbContextOptionsBuilder<FooDbContext>();
            optionsBuilder.UseSqlite("Data Source=FooDb.db");
            //optionsBuilder.UseInMemoryDatabase("Data Source=FooDb.db");
            optionsBuilder.UseLoggerFactory(loggerFactory);
            var dbContext = new FooDbContext(optionsBuilder.Options);

            if (ensureDeleted)
            {
                dbContext.Database.EnsureDeleted();
            }

            dbContext.Database.EnsureCreated();
            return dbContext;
        }
        private static LoggerFactory CreateLoggerFactory()
        {
            var loggerFilterOptions = new LoggerFilterOptions();
            loggerFilterOptions.MinLevel = LogLevel.Information;
            var loggerFactory = new LoggerFactory(new[] { new DebugLoggerProvider(), }, loggerFilterOptions);
            loggerFactory.AddProvider(new MyLogProvider());
            return loggerFactory;
        }
    }
}
