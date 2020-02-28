using System;

namespace Foo.Domain.Accounts
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Nick { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public DateTime CreateAt { get; set; }
    }
}