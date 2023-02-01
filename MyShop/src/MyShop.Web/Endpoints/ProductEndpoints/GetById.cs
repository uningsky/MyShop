using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.ProductAggregate;
using MyShop.Core.ProductAggregate.Specifications;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetProductByIdRequest>
        .WithResponse<GetProductByIdResponse>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper; 

        public GetById(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(GetProductByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single Product",
            Description = "Gets a single Product by Id",
            OperationId = "Products.GetById",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<GetProductByIdResponse>> HandleAsync([FromRoute] GetProductByIdRequest request,
            CancellationToken cancellationToken)
        {
            var spec = new ProductByIdWithCategorySpec(request.ProductId);

            var entity = await _repository.GetBySpecAsync(spec); // TODO: pass cancellation token
            if (entity == null) return NotFound();

            var response = _mapper.Map<GetProductByIdResponse>(entity);
            return Ok(response);
        }
    }
}