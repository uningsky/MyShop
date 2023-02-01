using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.ProductAggregate;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteProductRequest>
        .WithoutResponse
    {
        private readonly IRepository<Product> _repository;

        public Delete(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteProductRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a Product",
            Description = "Deletes a Product",
            OperationId = "Products.Delete",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteProductRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.ProductId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}