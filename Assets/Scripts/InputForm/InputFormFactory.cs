using UnityEngine;
using VContainer.Unity;

namespace InputForm
{
    public class InputFormFactory : IInitializable
    {
        private readonly InputFormContent _inputFormContent;
        private readonly Canvas _mainCanvas;

        public InputFormFactory(InputFormContent inputFormContent, Canvas mainCanvas)
        {
            _inputFormContent = inputFormContent;
            _mainCanvas = mainCanvas;
        }

        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            var presenter = new InputFormPresenter();
            var view = Object.Instantiate(_inputFormContent.Prefab, _mainCanvas.transform);
            view.Construct(presenter);
            presenter.BindView(view);
        }
    }
}