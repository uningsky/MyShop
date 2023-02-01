using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class UpdateProductRequest
    {
        public const string Route = "api/admin/Products";
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string ImagePath { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Guid> CategoryIds { get; set; }
    }
}