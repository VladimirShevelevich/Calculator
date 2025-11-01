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
        }

        public void OnEndEdit(string input)
        {
            _calculatorService.ApplyInput(input);
            _view.Clear();
        }
    }
}