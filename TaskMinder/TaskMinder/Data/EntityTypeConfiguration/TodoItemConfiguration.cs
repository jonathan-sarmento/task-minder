using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskMinder.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace TaskMinder.Data.EntityTypeConfiguration;

public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
{
    public void Configure(EntityTypeBuilder<TodoItem> builder)
    {
        builder.ToTable("TODOITEM");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("ID")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.Title)
            .HasColumnName("TITLE")
            .HasMaxLength(300)
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(3000)
            .HasColumnName("DESCRIPTION");

        builder.Property(e => e.Done)
            .HasColumnName("DONE")
            .IsRequired();

        builder.Property(e => e.CompletedDate)
            .HasColumnName("COMPLETEDDATE");

        builder.Property(e => e.CreatedDate)
            .HasColumnName("CREATEDDATE")
            .IsRequired();

        builder.Property(e => e.UserId)
            .HasColumnName("USERID")
            .IsRequired();
    }
}
