
namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class GetProductByIdRequest
    {
        public const string Route = "api/admin/Products/{ProductId:Guid}";
        public static string BuildRoute(Guid ProductId) => Route.Replace("{ProductId:Guid}", ProductId.ToString());

        public Guid ProductId { get; set; }
    }
}