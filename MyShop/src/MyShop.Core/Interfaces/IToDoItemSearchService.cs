using Ardalis.Result;
using MyShop.Core.ProjectAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Core.Interfaces
{
    public interface IToDoItemSearchService
    {
        Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
        Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
    }
}