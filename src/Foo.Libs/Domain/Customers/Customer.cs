using System;

namespace Foo.Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
