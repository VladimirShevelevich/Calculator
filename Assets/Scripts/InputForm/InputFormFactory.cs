using VContainer.Unity;

namespace InputForm
{
    public class InputFormFactory : IInitializable
    {
        private readonly InputFormContent _inputFormContent;

        public InputFormFactory(InputFormContent inputFormContent)
        {
            _inputFormContent = inputFormContent;
        }

        public void Initialize()
        {
            Create();
        }

        private void Create()
        {
            
        }
    }
}