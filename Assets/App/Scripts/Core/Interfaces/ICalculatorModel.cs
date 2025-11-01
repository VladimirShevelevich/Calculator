using UniRx;

namespace Core
{
    public interface ICalculatorModel
    {
        IReadOnlyReactiveCollection<string> ExpressionsLog { get; }
    }
}