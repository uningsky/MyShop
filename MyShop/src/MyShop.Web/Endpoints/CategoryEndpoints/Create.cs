using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.CategoryAggregate;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateCategoryRequest>
        .WithResponse<CreateCategoryResponse>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public Create(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost(CreateCategoryRequest.Route)]
        [SwaggerOperation(
            Summary = "Creates a new Category",
            Description = "Creates a new Category",
            OperationId = "Category.Create",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateCategoryResponse>> HandleAsync(CreateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Name == null)
            {
                return BadRequest();
            }

            var newCategory = new Category(request.Name, request.Description);

            var createdItem = await _repository.AddAsync(newCategory); // TODO: pass cancellation token

            var response = _mapper.Map<CreateCategoryResponse>(createdItem);
            
            return Ok(response);
        }
    }
}