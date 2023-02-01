using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.CategoryAggregate;
using MyShop.Core.ProductAggregate;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.ProductEndpoints
{
    public class Create : BaseAsyncEndpoint
        .WithRequest<CreateProductRequest>
        .WithResponse<CreateProductResponse>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper; 

        public Create(IRepository<Product> productRepository, IRepository<Category> categoryRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpPost("api/admin/Products")]
        [SwaggerOperation(
            Summary = "Creates a new Product",
            Description = "Creates a new Product",
            OperationId = "Product.Create",
            Tags = new[] { "ProductEndpoints" })
        ]
        public override async Task<ActionResult<CreateProductResponse>> HandleAsync([FromForm] CreateProductRequest request,
            CancellationToken cancellationToken)
        {
            if (request.Name == null)
            {
                return BadRequest();
            }

            string storedFilePath = string.Empty;
            if (request.File is not null)
            {
                storedFilePath = await SaveFile(request.File);
            }

            var newProduct = new Product(request.Name, request.Description, storedFilePath, request.Price, request.Quantity);

            foreach (var categoryId in request.CategoryIds)
            {
                var category = await _categoryRepository.GetByIdAsync(categoryId);
                if (category != null)
                {
                    newProduct.Categories.Add(category);
                }
            }

            var createdItem = await _productRepository.AddAsync(newProduct); // TODO: pass cancellation token

            var response = _mapper.Map<CreateProductResponse>(createdItem); 

            return Ok(response);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            string filePath = string.Empty;

            if (file.Length > 0)
            {
                filePath = Path.Combine("upload", Path.GetRandomFileName());

                using (var stream = System.IO.File.Create(filePath))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return filePath;
        }
    }
}