namespace TaskMinder.Services.Dtos;

public record TodoItemDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string? Description { get; init; }
    public DateTime CreatedDate { get; init; }
    public bool Done { get; init; }
    public DateTime? CompletedDate { get; init; }
}
