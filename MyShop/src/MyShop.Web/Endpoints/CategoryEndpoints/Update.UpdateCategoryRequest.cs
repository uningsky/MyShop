using System.ComponentModel.DataAnnotations;

namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class UpdateCategoryRequest
    {
        public const string Route = "api/admin/Categorys";
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string Description { get; set; } = string.Empty; 
    }
}