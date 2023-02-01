using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.CategoryAggregate;
using MyShop.SharedKernel.Interfaces;
using MyShop.Web.Endpoints.ProductEndpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class GetById : BaseAsyncEndpoint
        .WithRequest<GetCategoryByIdRequest>
        .WithResponse<GetCategoryByIdResponse>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetById(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet(GetCategoryByIdRequest.Route)]
        [SwaggerOperation(
            Summary = "Gets a single Category",
            Description = "Gets a single Category by Id",
            OperationId = "Categorys.GetById",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<GetCategoryByIdResponse>> HandleAsync([FromRoute] GetCategoryByIdRequest request,
            CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CategoryId); // TODO: pass cancellation token
            if (entity == null) return NotFound();

            var response = _mapper.Map<GetProductByIdResponse>(entity);

            return Ok(response);
        }
    }
}