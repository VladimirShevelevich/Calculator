using Core;
using VContainer;
using VContainer.Unity;

namespace InputForm
{
    public class InputFormInstaller : DomainInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InputFormFactory>();
            });
        }
    }
}