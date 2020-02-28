using System;
using System.Collections.Generic;
using System.Linq;
using Foo.Common;
using Foo.DAL;
using Foo.Domain.Accounts;

namespace Foo.AppServices
{
    public interface IAccountAppService
    {
        void InitAccounts(IList<Account> accounts);
        AccountDto GetAccount(GetAccountArgs args);
        //IEnumerable<AccountDto> GetAccounts(GetAccountsArgs args);
    }

    public class GetAccountArgs
    {
        public string Username { get; set; }
    }

    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Nick { get; set; }
        public DateTime CreateAt { get; set; }
    }

    public class AccountAppService : IAccountAppService
    {
        private readonly FooDbContext _context;

        public AccountAppService(FooDbContext context)
        {
            _context = context;
        }

        public void InitAccounts(IList<Account> accounts)
        {
            if (accounts == null || accounts.Count == 0)
            {
                return;
            }

            var allAccounts = _context.Accounts.ToList();

            foreach (var account in accounts)
            {
                var theOne = allAccounts.FirstOrDefault(x => x.Username == account.Username);
                if (theOne != null)
                {
                    _context.Add(theOne);
                }
            }

            _context.SaveChanges();
        }

        public AccountDto GetAccount(GetAccountArgs args)
        {
            if (args == null)
            {
                return null;
            }

            var theOne = _context.Accounts.FirstOrDefault(x => x.Username == args.Username);
            if (theOne == null)
            {
                return null;
            }

            var accountDto = new AccountDto();
            MyModelHelper.SetProperties(accountDto, theOne);
            return accountDto;
        }
    }
}
