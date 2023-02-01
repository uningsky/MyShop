using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.CategoryAggregate;
using MyShop.SharedKernel.Interfaces;
using MyShop.Web.Endpoints.ProductEndpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class List : BaseAsyncEndpoint
        .WithoutRequest
        .WithResponse<CategoryListResponse>
    {
        private readonly IReadRepository<Category> _repository;
        private readonly IMapper _mapper;

        public List(IReadRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/admin/Categorys")]
        [SwaggerOperation(
            Summary = "Gets a list of all Categorys",
            Description = "Gets a list of all Categorys",
            OperationId = "Category.List",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<CategoryListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new CategoryListResponse();
            response.Categorys = (await _repository.ListAsync()) // TODO: pass cancellation token
                .Select(_mapper.Map<CategoryRecord>)
                .ToList();

            return Ok(response);
        }
    }
}