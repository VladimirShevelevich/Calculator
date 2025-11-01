using Core;

namespace InputForm
{
    public class InputFormSaver
    {
        private readonly ISaveSystemService _saveSystemService;

        public InputFormSaver(ISaveSystemService saveSystemService)
        {
            _saveSystemService = saveSystemService;
        }

        public void HandleCurrentInputChanged(string input)
        {
            var saveData = new InputFormSaveData
            {
                CurrentInput = input
            };
            _saveSystemService.SaveData(saveData);
        }

        public bool LoadData(out InputFormSaveData saveData)
        {
            if (!_saveSystemService.GetData(out InputFormSaveData data))
            {
                saveData = default;
                return false;
            }

            saveData = data;
            return true;
        }
    }
}