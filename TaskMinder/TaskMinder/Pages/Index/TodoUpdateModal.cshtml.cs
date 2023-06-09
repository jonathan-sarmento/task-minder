using Microsoft.AspNetCore.Mvc;
using TaskMinder.Services;
using TaskMinder.Services.Dtos;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TaskMinder.Pages.Index
{
    public class TodoUpdateModalModel : AbpPageModel
    {
        private readonly ITodoService _todoService;

        public TodoUpdateModalModel(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [BindProperty]
        public TodoUpdateDto TodoItem { get; set; }

        public async Task OnGetAsync(Guid todoId)
        {
            var todoDto = await _todoService.GetAsync(todoId);
            TodoItem = new TodoUpdateDto().Create(todoDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
                return Page();

            await _todoService.UpdateAsync(TodoItem);
            return NoContent();
        }
    }
}
