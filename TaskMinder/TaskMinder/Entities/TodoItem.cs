using System.ComponentModel.DataAnnotations;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace TaskMinder.Entities;

public class TodoItem : BasicAggregateRoot<Guid>
{
    private const short TitleMaxLength = 300;
    private const short DescriptionMaxLength = 3000;

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; }

    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; set; }
    public bool Done { get; set; } = false;
    public DateTime? CompletedDate { get; set; }

    [Required]
    public DateTime CreatedDate { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public TodoItem SetTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title cannot be null or whitespace.", nameof(title));

        if (title.Length > TitleMaxLength)
            throw new ArgumentException($"Title cannot be longer than {TitleMaxLength} characters.", nameof(title));

        Title = title;
        return this;
    }

    public TodoItem SetDescription(string? description)
    {
        if (description?.Length > DescriptionMaxLength)
            throw new ArgumentException($"Description cannot be longer than {DescriptionMaxLength} characters.", nameof(description));

        Description = description;
        return this;
    }

    public TodoItem SetDone(bool done)
    {
        Done = done;

        return this;
    }

    public TodoItem SetCompletedDate(DateTime? date)
    {
        CompletedDate = date;
        return this;
    }

    public TodoItem SetCreatedDate(DateTime datetime)
    {
        CreatedDate = datetime;
        return this;
    }

    public TodoItem SetUserId(Guid? guid)
    {
        if(guid == null)
            throw new ArgumentException("User Id cannot be null", nameof(guid));

        UserId = guid.Value;
        return this;
    }
}

