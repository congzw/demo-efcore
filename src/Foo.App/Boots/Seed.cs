using System;
using Foo.Common;
using Foo.DAL;
using Foo.Domain.Accounts;

namespace Foo.App.Boots
{
    public class Seed
    {
        private readonly FooDbContext _dbContext;

        public Seed(FooDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Init()
        {
            var mockGuidQueue = GuidHelper.CreateMockGuidQueue(4);

            var admin = new Account();
            admin.Id = mockGuidQueue.Dequeue();
            admin.Username = "admin";
            admin.CreateAt = new DateTime(2000,1,1);
            admin.Nick = "ADMIN";
            admin.PasswordHash = "MockHash";
            admin.PasswordSalt = "SALT";
            _dbContext.Accounts.Add(admin);
            
            for (int i = 1; i <= 3; i++)
            {
                var account = new Account();
                account.Id = mockGuidQueue.Dequeue();
                account.Username = "User" + i;
                account.CreateAt = new DateTime(2000, 1, 1);
                account.Nick = "用户" + i;
                account.PasswordHash = "MockHash";
                account.PasswordSalt = "SALT";
                _dbContext.Accounts.Add(account);
            }

            _dbContext.SaveChanges();
        }
    }
}
