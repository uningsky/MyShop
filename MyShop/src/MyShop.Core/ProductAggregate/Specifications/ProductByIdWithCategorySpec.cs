using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ProductAggregate.Specifications
{
    public class ProductByIdWithCategorySpec : Specification<Product>, ISingleResultSpecification
    {
        public ProductByIdWithCategorySpec(Guid id) 
        {
            Query
                .Where(x => x.Id == id)
                .Include(x => x.Categories);
        }
    }
}
