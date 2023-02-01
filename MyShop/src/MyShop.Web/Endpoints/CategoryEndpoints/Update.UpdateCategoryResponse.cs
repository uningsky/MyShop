namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class UpdateCategoryResponse
    {
        public UpdateCategoryResponse(CategoryRecord record)
        {
            Category = record;
        }
        public CategoryRecord Category { get; set; }
    }
}