using System;
using System.Linq;
using Autofac;
using Foo.App.Boots;
using Foo.AppServices;
using Foo.Common;
using Foo.DAL;

namespace Foo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Setup();
            
            using (var scope = container.BeginLifetimeScope())
            {
                var seed = scope.Resolve<Seed>();
                seed.Init();
            }

            using (var scope = container.BeginLifetimeScope())
            {
                var accountAppService = scope.Resolve<IAccountAppService>();
                var accountDto = accountAppService.GetAccount(new GetAccountArgs() { Username = "admin" });
                Console.WriteLine(accountDto.Nick);
            }


            using (var scope = container.BeginLifetimeScope())
            {
                var firstId = GuidHelper.CreateMockGuidQueue(1).Dequeue();
                Console.WriteLine(firstId);
                var fooDbContext = scope.Resolve<FooDbContext>();
                var admin = fooDbContext.Accounts.SingleOrDefault(x => x.Id == firstId);
                Console.WriteLine("try find: " + admin?.Nick);
            }

            Console.Read();
        }
    }
}
