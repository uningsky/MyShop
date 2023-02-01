﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Core.ProjectAggregate;
using MyShop.Core.ProjectAggregate.Specifications;
using MyShop.SharedKernel.Interfaces;
using MyShop.Web.ApiModels;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Web.Pages.ToDoRazorPage
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Project> _repository;

        [BindProperty(SupportsGet = true)]
        public int ProjectId { get; set; }
        public string Message { get; set; } = "";

        public ProjectDTO? Project { get; set; }

        public IndexModel(IRepository<Project> repository)
        {
            _repository = repository;
        }

        public async Task OnGetAsync()
        {
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);

            if (project == null)
            {
                Message = "No project found.";
                return;
            }

            Project = new ProjectDTO
            (
                id: project.Id,
                name: project.Name,
                items: project.Items
                .Select(item => ToDoItemDTO.FromToDoItem(item))
                .ToList()
            );
        }
    }
}