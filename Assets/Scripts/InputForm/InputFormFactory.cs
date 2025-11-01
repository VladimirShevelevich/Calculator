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

        public InputFormFactory(InputFormContent inputFormContent, Canvas mainCanvas, IObjectResolver objectResolver)
        {
            _inputFormContent = inputFormContent;
            _mainCanvas = mainCanvas;
            _objectResolver = objectResolver;
        }

        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            var presenter = _objectResolver.Resolve<InputFormPresenter>();
            var view = Object.Instantiate(_inputFormContent.Prefab, _mainCanvas.transform);
            view.Construct(presenter);
            presenter.BindView(view);
        }
    }
}