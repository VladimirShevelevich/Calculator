using App.Scripts.Saver;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Installer[] _installers;
        
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(_canvas);
            SaveSystemInstaller.Install(builder);
            foreach (var installer in _installers) 
                installer.Install(builder);
        }
    }
}