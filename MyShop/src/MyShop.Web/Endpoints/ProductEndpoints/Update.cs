using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.ProductAggregate;
using MyShop.SharedKernel.Interfaces; 
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class Update : BaseAsyncEndpoint
        .WithRequest<UpdateProductRequest>
        .WithResponse<UpdateProductResponse>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public Update(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut(UpdateProductRequest.Route)]
        [SwaggerOperation(
            Summary = "Updates a Product",
            Description = "Updates a Product with a longer description",
            OperationId = "Products.Update",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<UpdateProductResponse>> HandleAsync(UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Name == null)
            {
                return BadRequest();
            }
            var existingProduct = await _repository.GetByIdAsync(request.Id); // TODO: pass cancellation token

            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Update(request.Name, request.Description, request.Price, request.Quantity);

            await _repository.UpdateAsync(existingProduct); // TODO: pass cancellation token

            var response = new UpdateProductResponse(
                record: _mapper.Map<ProductRecord>(existingProduct)
            );
            return Ok(response);
        }
    }
}