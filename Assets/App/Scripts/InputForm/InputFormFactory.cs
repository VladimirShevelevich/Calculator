using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InputForm
{
    public class InputFormFactory : IInitializable
    {
        private readonly InputFormContent _inputFormContent;
        private readonly Canvas _mainCanvas;
        private readonly IObjectResolver _objectResolver;
        private readonly InputFormPresenter _inputFormPresenter;

        public InputFormFactory(InputFormContent inputFormContent, 
            Canvas mainCanvas, 
            InputFormPresenter inputFormPresenter, 
            IObjectResolver objectResolver)
        {
            _inputFormContent = inputFormContent;
            _mainCanvas = mainCanvas;
            _inputFormPresenter = inputFormPresenter;
            _objectResolver = objectResolver;
        }

        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            var view = Object.Instantiate(_inputFormContent.Prefab, _mainCanvas.transform);
            _objectResolver.Inject(view);
            _inputFormPresenter.BindView(view);
        }
    }
}