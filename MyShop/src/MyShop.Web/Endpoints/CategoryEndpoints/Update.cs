using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.CategoryAggregate;
using MyShop.SharedKernel.Interfaces;
using MyShop.Web.Endpoints.ProductEndpoints;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateCategoryRequest>
        .WithResponse<UpdateCategoryResponse>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper; 

        public Update(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut(UpdateCategoryRequest.Route)]
        [SwaggerOperation(
            Summary = "Updates a Category",
            Description = "Updates a Category with a longer description",
            OperationId = "Categorys.Update",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Name == null)
            {
                return BadRequest();
            }
            var existingCategory = await _repository.GetByIdAsync(request.Id); // TODO: pass cancellation token

            if (existingCategory == null)
            {
                return NotFound();
            }
            existingCategory.Update(request.Name, request.Description);

            await _repository.UpdateAsync(existingCategory); // TODO: pass cancellation token

            var response = new UpdateCategoryResponse(
                record: _mapper.Map<CategoryRecord>(existingCategory)
            );
            return Ok(response);
        }
    }
}