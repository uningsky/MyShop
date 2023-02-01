using Ardalis.GuardClauses;
using MyShop.Core.CategoryAggregate;
using MyShop.SharedKernel;
using MyShop.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ProductAggregate
{
    public class Product : BaseEntity<Guid>, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string ImagePath { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }

        public List<Category> Categories { get; private set; } = new List<Category>();

        public Product(string name, string description, string imagePath, decimal price, int quantity)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(price, nameof(price));

            Name = name;
            Description = description;
            ImagePath = imagePath;
            Price = price;
            SetQuantity(quantity);
        }

        public void Update(string name, string description, decimal price, int quantity)
        {
            Guard.Against.NullOrEmpty(name, nameof(name));
            Guard.Against.NullOrEmpty(description, nameof(description));
            Guard.Against.NegativeOrZero(price, nameof(price));

            Name = name;
            Description = description;
            Price = price;
            SetQuantity(quantity);
        }

        public void AddCategory(Category category)
        {
            Guard.Against.Null(category, nameof(category));

            Categories.Add(category);
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }

        public void UpdateImagePath(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
            {
                ImagePath = string.Empty;
                return;
            }
        }
    }
}
