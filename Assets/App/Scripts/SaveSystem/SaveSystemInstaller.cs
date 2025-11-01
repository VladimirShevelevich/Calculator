using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace App.Scripts.Saver
{
    [CreateAssetMenu(fileName = "SaveSystemInstaller", menuName = "Installers/SaveSystem")]
    public class SaveSystemInstaller : DomainInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ISaver, PrefsSaver>(Lifetime.Singleton);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<SaveSystemService>();
            });
        }
    }
}