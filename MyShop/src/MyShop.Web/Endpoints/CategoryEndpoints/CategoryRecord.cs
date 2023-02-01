namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class CategoryRecord
    {
        private Guid _id;
        private string _name;
        private readonly string _description;

        public CategoryRecord(Guid id, string name, string description)
        {
            this._id = id;
            this._name = name;
            this._description = description;
        }
    }
}