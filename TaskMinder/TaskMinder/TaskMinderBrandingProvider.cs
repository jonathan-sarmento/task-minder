using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TaskMinder;

[Dependency(ReplaceServices = true)]
public class TaskMinderBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TaskMinder";
}
