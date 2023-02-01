
namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class GetCategoryByIdRequest
    {
        public const string Route = "api/admin/Categorys/{CategoryId:Guid}";
        public static string BuildRoute(Guid CategoryId) => Route.Replace("{CategoryId:Guid}", CategoryId.ToString());

        public Guid CategoryId { get; set; }
    }
}