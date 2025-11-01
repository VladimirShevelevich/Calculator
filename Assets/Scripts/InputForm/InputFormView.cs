using InputForm;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFormView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private GameObject _errorViewRoot;
    [SerializeField] private Button _errorOkBtn;
    [SerializeField] private Button _applyBtn;
    
    private InputFormPresenter _presenter;

    public void Construct(InputFormPresenter presenter)
    {
        _presenter = presenter;
    }

    private void Start()
    {
        _inputField.onValueChanged.AddListener(OnInputChanged);
        _errorOkBtn.onClick.AddListener(OnErrorOkButtonClicked);
        _applyBtn.onClick.AddListener(OnApplyButtonClicked);
    }

    public void SetInputText(string text) =>
        _inputField.text = text;

    public void Clear() =>
        _inputField.text = "";

    public void ShowErrorMessage(bool show) =>
        _errorViewRoot.SetActive(show);

    private void OnInputChanged(string input)
    {
        _presenter.OnInputChanged(input);
    }

    private void OnApplyButtonClicked() => 
        _presenter.OnApplyButtonClicked(_inputField.text);

    private void OnErrorOkButtonClicked()
    {
        _presenter.OnErrorOkButtonClicked();
    }
}
