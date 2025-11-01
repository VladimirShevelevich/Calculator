using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private ContentHolder _contentHolder;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private DomainInstaller[] _domainsInstallers;
        
        protected override void Configure(IContainerBuilder builder)
        {
            _contentHolder.RegisterContent(builder);
            builder.RegisterInstance(_canvas);
            foreach (var installer in _domainsInstallers) 
                installer.Install(builder);
        }
    }
}