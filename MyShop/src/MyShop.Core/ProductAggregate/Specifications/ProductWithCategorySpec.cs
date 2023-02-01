using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.ProductAggregate.Specifications
{
    public class ProductWithCategorySpec : Specification<Product>
    {
        public ProductWithCategorySpec() 
        {
            Query
                .Include(x => x.Categories);
        }
    }
}
