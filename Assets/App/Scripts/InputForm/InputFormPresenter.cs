using Core;

namespace InputForm
{
    public class InputFormPresenter
    {
        private readonly ICalculatorService _calculatorService;
        private readonly InputFormSaver _inputFormSaver;
        private InputFormView _view;

        public InputFormPresenter(ICalculatorService calculatorService, InputFormSaver inputFormSaver)
        {
            _calculatorService = calculatorService;
            _inputFormSaver = inputFormSaver;
        }

        public void BindView(InputFormView view)
        {
            _view = view;
            _view.ShowErrorMessage(false);
            RestoreData();
        }

        public void OnApplyButtonClicked(string input) => 
            HandleInputApply(input);

        public void OnErrorOkButtonClicked() => 
            _view.ShowErrorMessage(false);

        public void OnInputChanged(string input)
        {
            HandleInputChanged(input);
        }

        private void HandleInputChanged(string input)
        {
            _inputFormSaver.HandleCurrentInputChanged(input);
        }

        private void HandleInputApply(string input)
        {
            var success = _calculatorService.ApplyInput(input);
            if (success)
                _view.ClearInputText();
            else
                _view.ShowErrorMessage(true);
        }

        private void RestoreData()
        {
            if (_inputFormSaver.LoadData(out InputFormSaveData saveData)) 
                _view.SetInputText(saveData.CurrentInput);
        }
    }
}