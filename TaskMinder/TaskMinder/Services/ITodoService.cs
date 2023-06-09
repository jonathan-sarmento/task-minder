using TaskMinder.Services.Dtos;
using Volo.Abp.Application.Services;

namespace TaskMinder.Services;

public interface ITodoService : IApplicationService
{
    Task<TodoItemDto> GetAsync(Guid id);
    Task<TodoItemDto> CreateAsync(TodoCreateDto todoItemDto);
    Task UpdateAsync(TodoUpdateDto todoItemDto);
    Task DeleteAsync(Guid id);
    Task<List<TodoItemDto>> GetListAsync();
    Task UpdateDoneStatusAsync(Guid id, bool done);
}