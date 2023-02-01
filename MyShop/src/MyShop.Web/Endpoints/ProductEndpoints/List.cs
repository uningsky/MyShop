using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.ProductAggregate;
using MyShop.Core.ProductAggregate.Specifications;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<ProductListResponse>
    {
        private readonly IReadRepository<Product> _repository;
        private readonly IMapper _mapper;

        public List(IReadRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/admin/Products")]
        [SwaggerOperation(
            Summary = "Gets a list of all Products",
            Description = "Gets a list of all Products",
            OperationId = "Product.List",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<ProductListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var spec = new ProductWithCategorySpec();

            var response = new ProductListResponse();
            response.Products = (await _repository.ListAsync(spec)) // TODO: pass cancellation token
                .Select(_mapper.Map<ProductRecord>)
                .ToList();

            return Ok(response);
        }
    }
}