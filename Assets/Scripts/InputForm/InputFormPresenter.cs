namespace InputForm
{
    public class InputFormPresenter
    {
        private InputFormView _view;

        public void BindView(InputFormView view)
        {
            _view = view;
        }

        public void OnEndEdit(string input)
        {
            _view.Clear();
        }
    }
}