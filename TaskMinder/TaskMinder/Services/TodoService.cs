using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMinder.Entities;
using TaskMinder.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace TaskMinder.Services;

//[ExposeServices(typeof(ITodoService))]
[Authorize]
[IgnoreAntiforgeryToken]
public class TodoService : ApplicationService, ITodoService, ITransientDependency
{
    private readonly ICurrentUser _currentUser;
    private readonly IRepository<TodoItem, Guid> _todoItemRepository;

    public TodoService(IRepository<TodoItem, Guid> todoItemRepository, ICurrentUser currentUser)
    {
        _todoItemRepository = todoItemRepository;
        _currentUser = currentUser;
    }

    public async Task<TodoItemDto> GetAsync(Guid id)
    {
        var todo = await _todoItemRepository.GetAsync(x => x.Id.Equals(id));
        return ObjectMapper.Map<TodoItem, TodoItemDto>(todo);
    }

    public async Task<List<TodoItemDto>> GetListAsync()
    {
        var items = await (await _todoItemRepository.GetDbSetAsync())
            .OrderByDescending(x => x.CreatedDate)
            .Where(x => x.UserId == _currentUser.Id)
            .ToListAsync();
        return ObjectMapper.Map<List<TodoItem>, List<TodoItemDto>>(items);
    }

    [UnitOfWork]
    public async Task<TodoItemDto> CreateAsync(TodoCreateDto todoItemDto)
    {
        var model = new TodoItem().SetTitle(todoItemDto.Title)
                        .SetDescription(todoItemDto.Description)
                        .SetCreatedDate(DateTime.UtcNow)
                        .SetUserId(_currentUser.Id);

        var todoItem = await _todoItemRepository.InsertAsync(model);

        return new TodoItemDto
        {
            Id = todoItem.Id,
            Title = todoItem.Title
        };
    }

    [UnitOfWork]
    public async Task UpdateAsync(TodoUpdateDto todoItemDto)
    {
        var todo = await _todoItemRepository.GetAsync(x => x.Id.Equals(todoItemDto.Id));
        todo.SetTitle(todoItemDto.Title)
            .SetDescription(todoItemDto.Description)
            .SetDone(todoItemDto.Done)
            .SetCompletedDate(todoItemDto.Done ? DateTime.UtcNow : default);

        await _todoItemRepository.UpdateAsync(todo);
    }

    public async Task UpdateDoneStatusAsync(Guid id, bool done)
    {
        var todo = await _todoItemRepository.GetAsync(x => x.Id.Equals(id));
        todo.SetDone(done)
            .SetCompletedDate(done ? DateTime.UtcNow : default);

        await _todoItemRepository.UpdateAsync(todo);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _todoItemRepository.DeleteAsync(id);
    }
}
