
namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class GetCategoryByIdResponse
    {
        public GetCategoryByIdResponse(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; }
    }
}