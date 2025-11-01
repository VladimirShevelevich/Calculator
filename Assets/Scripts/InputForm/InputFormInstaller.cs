using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InputForm
{
    public class InputFormInstaller : DomainInstaller
    {
        [SerializeField] private InputFormContent _inputFormContent;
        
        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_inputFormContent);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<InputFormFactory>();
            });
        }
    }
}