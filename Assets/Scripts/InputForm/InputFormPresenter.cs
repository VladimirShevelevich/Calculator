using Core;

namespace InputForm
{
    public class InputFormPresenter
    {
        private readonly ICalculatorService _calculatorService;
        private InputFormView _view;

        public InputFormPresenter(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        
        public void BindView(InputFormView view)
        {
            _view = view;
            _view.ShowErrorMessage(false);
        }

        public void OnInputEntered(string input) => 
            HandleInput(input);

        public void OnErrorOkButtonClicked() => 
            _view.ShowErrorMessage(false);

        private void HandleInput(string input)
        {
            var success = _calculatorService.ApplyInput(input);
            if (success)
                _view.Clear();
            else
                _view.ShowErrorMessage(true);
        }
    }
}