using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Calculator
{
    [CreateAssetMenu(fileName = "CalculatorInstaller", menuName = "Installers/Calculator")]
    public class CalculatorInstaller : Installer
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<IInputHandler, DefaultInputHandler>(Lifetime.Singleton);
            builder.UseEntryPoints(ep =>
            {
                ep.Add<CalculatorModel>().AsSelf();
            });
        }
    }
}