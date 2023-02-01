using Ardalis.GuardClauses;
using MyShop.SharedKernel;
using MyShop.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.CategoryAggregate
{
    public class Category : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Category(string name, string description)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Description = description;
        }

        public void Update(string name, string description)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Description = description;
        }
    }
}
