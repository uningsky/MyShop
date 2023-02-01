﻿using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using MyShop.Core.ProjectAggregate;
using MyShop.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace MyShop.Web.Endpoints.ProjectEndpoints
{
    public class Delete : BaseAsyncEndpoint
        .WithRequest<DeleteProjectRequest>
        .WithoutResponse
    {
        private readonly IRepository<Project> _repository;

        public Delete(IRepository<Project> repository)
        {
            _repository = repository;
        }

        [HttpDelete(DeleteProjectRequest.Route)]
        [SwaggerOperation(
            Summary = "Deletes a Project",
            Description = "Deletes a Project",
            OperationId = "Projects.Delete",
            Tags = new[] { "ProjectEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync([FromRoute] DeleteProjectRequest request,
            CancellationToken cancellationToken)
        {
            var aggregateToDelete = await _repository.GetByIdAsync(request.ProjectId); // TODO: pass cancellation token
            if (aggregateToDelete == null) return NotFound();

            await _repository.DeleteAsync(aggregateToDelete);

            return NoContent();
        }
    }
}