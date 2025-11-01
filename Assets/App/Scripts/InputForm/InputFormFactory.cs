using Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InputForm
{
    public class InputFormFactory : IInitializable
    {
        private readonly InputFormContent _inputFormContent;
        private readonly Canvas _mainCanvas;
        private readonly ICalculatorService _calculatorService;
        private readonly InputFormPresenter _inputFormPresenter;

        public InputFormFactory(InputFormContent inputFormContent, Canvas mainCanvas, ICalculatorService calculatorService, InputFormPresenter inputFormPresenter)
        {
            _inputFormContent = inputFormContent;
            _mainCanvas = mainCanvas;
            _calculatorService = calculatorService;
            _inputFormPresenter = inputFormPresenter;
        }

        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            var view = Object.Instantiate(_inputFormContent.Prefab, _mainCanvas.transform);
            view.Construct(_inputFormPresenter, _calculatorService.CalculatorModel);
            _inputFormPresenter.BindView(view);
        }
    }
}