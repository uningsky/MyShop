
using MyShop.Core.CategoryAggregate;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class GetProductByIdResponse
    {
        public GetProductByIdResponse(Guid id, string name, string description, string imagePath, decimal price, int quantity, List<Category> categories)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Price = price;
            Quantity = quantity;
            Categories = categories;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Category> Categories { get; set; }
    }
}