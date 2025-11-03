using VContainer;
using VContainer.Unity;

namespace App.Scripts.Saver
{
    public class SaveSystemInstaller
    {
        public static void Install(IContainerBuilder builder)
        {
            builder.Register<ISaver, PrefsSaver>(Lifetime.Singleton);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<SaveSystemService>();
            });
        }
    }
}