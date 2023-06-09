using Microsoft.AspNetCore.Mvc;
using TaskMinder.Services;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TaskMinder.Pages.Index
{
    [ValidateAntiForgeryToken]
    public class TodoDeleteModalModel : AbpPageModel
    {
        private readonly ITodoService _todoService;

        [BindProperty]
        public Guid TodoId { get; set; }

        public TodoDeleteModalModel(ITodoService todoService) 
            => _todoService = todoService;

        public void OnGet(Guid todoId)
        {
            if(todoId.Equals(Guid.Empty))
                throw new ArgumentNullException(nameof(todoId));

            TodoId = todoId;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _todoService.DeleteAsync(TodoId);
            return NoContent();
        }
    }
}
