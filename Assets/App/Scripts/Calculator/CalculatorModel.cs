using Core;
using UniRx;

namespace Calculator
{
    public class CalculatorModel : ICalculatorModel
    {
        public IReadOnlyReactiveCollection<string> ExpressionsLog => _expressionsLog;
        private readonly ReactiveCollection<string> _expressionsLog = new();

        public void AddExpressionLog(string log) =>
            _expressionsLog.Add(log);


    }
}