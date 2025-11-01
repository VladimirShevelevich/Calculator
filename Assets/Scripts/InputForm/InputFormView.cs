using InputForm;
using TMPro;
using UnityEngine;

public class InputFormView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    
    private InputFormPresenter _presenter;

    public void Construct(InputFormPresenter presenter)
    {
        _presenter = presenter;
    }

    public void SetText(string text) =>
        _inputField.text = text;

    private void Start()
    {
        _inputField.onEndEdit.AddListener(OnEndEdit);
    }

    private void OnEndEdit(string input) => 
        _presenter.OnEndEdit(input);
}
