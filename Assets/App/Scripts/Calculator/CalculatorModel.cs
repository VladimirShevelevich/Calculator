using System.Linq;
using Core;
using UniRx;
using VContainer.Unity;

namespace Calculator
{
    public class CalculatorModel : ICalculatorModel, IInitializable
    {
        private readonly ISaveSystemService _saveSystemService;
        public IReadOnlyReactiveCollection<string> ExpressionsLog => _expressionsLog;
        private readonly ReactiveCollection<string> _expressionsLog = new();

        public CalculatorModel(ISaveSystemService saveSystemService)
        {
            _saveSystemService = saveSystemService;
        }

        public void Initialize()
        {
            Load();
        }

        private void Load()
        {
            if (!_saveSystemService.GetData(out CalculatorSaveData saveData)) 
                return;
            
            foreach (var expressionLog in saveData.ExpressionsLog) 
                _expressionsLog.Add(expressionLog);
        }

        public void AddExpressionLog(string log)
        {
            _expressionsLog.Add(log);
            Save();
        }


        private void Save()
        {
            var saveData = new CalculatorSaveData
            {
                ExpressionsLog = _expressionsLog.ToArray()
            };
            _saveSystemService.SaveData(saveData);
        }
    }
}