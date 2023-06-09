using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Reflection.Emit;
using TaskMinder.Data.EntityTypeConfiguration;
using TaskMinder.Entities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace TaskMinder.Data;

public class TaskMinderDbContext : AbpDbContext<TaskMinderDbContext>
{
    public TaskMinderDbContext(DbContextOptions<TaskMinderDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        builder.ApplyConfigurationsFromAssembly(typeof(TodoItemConfiguration).Assembly);

        /* Configure your own entities here */
    }
}
