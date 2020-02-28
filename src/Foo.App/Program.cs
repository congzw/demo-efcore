using System;
using Autofac;
using Foo.App.Boots;
using Foo.AppServices;

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
                var accountDto = accountAppService.GetAccount(new GetAccountArgs() {Username = "admin"});
                Console.WriteLine(accountDto.Nick);
            }

            Console.Read();
        }
    }
}
