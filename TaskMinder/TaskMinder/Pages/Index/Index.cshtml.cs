using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMinder.Services;
using TaskMinder.Services.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TaskMinder.Pages.Index;

[Authorize]
public class IndexModel : AbpPageModel
{
    public List<TodoItemDto> TodoItems { get; set; } = new List<TodoItemDto>();

    private readonly ITodoService _todoService;

    public IndexModel(ITodoService todoService)
        => _todoService = todoService;
    
    public async Task OnGetAsync()
    {
        TodoItems = await _todoService.GetListAsync();
    }

    [BindProperty]
    public TodoCreateDto? TodoItem { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        await _todoService.CreateAsync(TodoItem);

        return RedirectToPage("./Index");
    }
}