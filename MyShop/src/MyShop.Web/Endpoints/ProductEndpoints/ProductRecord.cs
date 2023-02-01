using MyShop.Core.CategoryAggregate;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public record ProductRecord(int Id, string Name, string Description, string ImagePath, decimal Price, int Quantity, List<Category> categories);
}