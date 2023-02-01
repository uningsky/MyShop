using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class CreateProductRequest
    {
        public const string Route = "api/admin/Products";

        [Required]
        public string? Name { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public List<Guid> CategoryIds { get; set; } = new List<Guid>();
        public IFormFile? File { get; set; } 
    }
}