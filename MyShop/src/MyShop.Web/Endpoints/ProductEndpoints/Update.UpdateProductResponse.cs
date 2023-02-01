namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class UpdateProductResponse
    {
        public UpdateProductResponse(ProductRecord record)
        {
            Product = record;
        }
        public ProductRecord Product { get; set; }
    }
}