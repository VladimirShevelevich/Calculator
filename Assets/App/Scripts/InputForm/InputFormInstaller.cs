using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InputForm
{
    [CreateAssetMenu(fileName = "InputFormInstaller", menuName = "Installers/InputForm")]
    public class InputFormInstaller : Installer
    {
        [SerializeField] private InputFormContent _inputFormContent;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_inputFormContent);
            builder.Register<InputFormPresenter>(Lifetime.Singleton);
            builder.Register<InputFormSaver>(Lifetime.Singleton);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InputFormFactory>();
            });
        }
    }
}