using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.CategoryAggregate;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.CategoryEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteCategoryRequest>
        .WithoutResponse
    {
        private readonly IRepository<Category> _repository;

        public Delete(IRepository<Category> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteCategoryRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a Category",
            Description = "Deletes a Category",
            OperationId = "Categorys.Delete",
            Tags = new[] { "CategoryEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteCategoryRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.CategoryId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}