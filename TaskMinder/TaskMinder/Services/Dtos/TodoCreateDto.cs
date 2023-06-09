using System.ComponentModel.DataAnnotations;

namespace TaskMinder.Services.Dtos
{
    public class TodoCreateDto
    {
        [Required(ErrorMessage = "The Title is required.")]
        [MaxLength(300, ErrorMessage = "The Title cannot have more than 300 characters.")]
        public string Title { get; set; }

        [MaxLength(3000, ErrorMessage = "The Title cannot have more than 3000 characters.")]
        public string? Description { get; set; }
    }
}
