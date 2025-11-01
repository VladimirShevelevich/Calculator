using Core;
using UnityEngine;
using VContainer;

namespace Calculator
{
    [CreateAssetMenu(fileName = "CalculatorInstaller", menuName = "Installers/Calculator")]
    public class CalculatorInstaller : DomainInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ICalculatorService, CalculatorService>(Lifetime.Singleton);
            builder.Register<IInputHandler, DefaultInputHandler>(Lifetime.Singleton);
        }
    }
}