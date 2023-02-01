namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class CreateProductResponse
    {
        public CreateProductResponse(Guid id, string name, string description, string imagePath, decimal price, int quantity, List<Guid> categoryIds)
        {
            Id = id;
            Name = name;
            Description = description;
            ImagePath = imagePath;
            Price = price;
            Quantity = quantity;
            CategoryIds = categoryIds;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}