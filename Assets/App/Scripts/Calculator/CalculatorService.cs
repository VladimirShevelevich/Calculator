using Core;

namespace Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IInputHandler _inputHandler;
        private readonly CalculatorModel _calculatorModel;

        public CalculatorService(IInputHandler inputHandler, CalculatorModel calculatorModel)
        {
            _inputHandler = inputHandler;
            _calculatorModel = calculatorModel;
        }
        
        public bool ApplyInput(string input)
        {
            var success = _inputHandler.HandleInput(input, out var result);
            var logResult = success ? result.ToString() : "error";
            var newLog = $"{input}={logResult}";
            _calculatorModel.AddExpressionLog(newLog);
            return success;
        }

        public ICalculatorModel CalculatorModel =>
            _calculatorModel;
    }
}