using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TaskMinder.Services.Dtos
{
    public class TodoUpdateDto
    {
        [Required]
        [HiddenInput]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The Title is required.")]
        [MaxLength(300, ErrorMessage = "The Title cannot have more than 300 characters.")]
        public string Title { get; set; }

        [MaxLength(3000, ErrorMessage = "The Title cannot have more than 3000 characters.")]
        public string? Description { get; set; }
        public bool Done { get; set; }

        public TodoUpdateDto Create(TodoItemDto dto)
        {
            Id = dto.Id;
            Title = dto.Title;
            Description = dto.Description;
            Done = dto.Done;
            return this;
        }
    }
}
