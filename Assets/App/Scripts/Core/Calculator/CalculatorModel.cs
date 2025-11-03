using System.Linq;
using Core;
using UniRx;
using VContainer.Unity;

namespace Calculator
{
    public class CalculatorModel : ICalculatorModel, IInitializable
    {
        private readonly ISaveSystemService _saveSystemService;
        private readonly IInputHandler _inputHandler;
        public IReadOnlyReactiveCollection<string> ExpressionsLog => _expressionsLog;
        private readonly ReactiveCollection<string> _expressionsLog = new();

        public CalculatorModel(ISaveSystemService saveSystemService, IInputHandler inputHandler)
        {
            _saveSystemService = saveSystemService;
            _inputHandler = inputHandler;
        }

        void IInitializable.Initialize()
        {
            Load();
        }

        /// <returns>Whether the operation is success</returns>
        public bool ApplyInput(string input)
        {
            var success = _inputHandler.HandleInput(input, out var result);
            var logResult = success ? result.ToString() : "ERROR";
            var newLog = $"{input}={logResult}";
            AddExpressionLog(newLog);
            return success;
        }

        private void Load()
        {
            if (!_saveSystemService.GetData(out CalculatorSaveData saveData))
                return;

            foreach (var expressionLog in saveData.ExpressionsLog)
                _expressionsLog.Add(expressionLog);
        }

        private void Save()
        {
            var saveData = new CalculatorSaveData
            {
                ExpressionsLog = _expressionsLog.ToArray()
            };
            _saveSystemService.SaveData(saveData);
        }

        private void AddExpressionLog(string log)
        {
            _expressionsLog.Add(log);
            Save();
        }
    }
}

public interface ICalculatorModel
{
    IReadOnlyReactiveCollection<string> ExpressionsLog { get; }       
}