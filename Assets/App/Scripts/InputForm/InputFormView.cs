using System.Text;
using Core;
using InputForm;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

public class InputFormView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private GameObject _inputViewRoot;
    [SerializeField] private GameObject _errorViewRoot;
    [SerializeField] private Button _errorOkBtn;
    [SerializeField] private Button _applyBtn;
    [SerializeField] private TMP_Text _expressionsLogText;
    [SerializeField] private RectTransform _layoutGroup;
    
    private InputFormPresenter _presenter;
    private ICalculatorModel _calculatorModel;
    private readonly StringBuilder _expressionsLogBuilder = new();

    [Inject]
    public void Construct(InputFormPresenter presenter, ICalculatorModel calculatorModel)
    {
        _presenter = presenter;
        _calculatorModel = calculatorModel;
    }

    private void Start()
    {
        _inputField.onValueChanged.AddListener(OnInputChanged);
        _errorOkBtn.onClick.AddListener(OnErrorOkButtonClicked);
        _applyBtn.onClick.AddListener(OnApplyButtonClicked);
        
        SetInitialExpressionsLog();
        _calculatorModel.ExpressionsLog.ObserveAdd().Subscribe(HandleNewExpressionLog);
    }

    public void SetInputText(string text) =>
        _inputField.text = text;

    public void ClearInputText() =>
        _inputField.text = "";

    public void ShowErrorMessage(bool show)
    {
        _errorViewRoot.SetActive(show);
        _inputViewRoot.SetActive(!show);
    }

    private void OnInputChanged(string input) => 
        _presenter.OnInputChanged(input);

    private void OnApplyButtonClicked() => 
        _presenter.OnApplyButtonClicked(_inputField.text);

    private void OnErrorOkButtonClicked() => 
        _presenter.OnErrorOkButtonClicked();

    private void SetInitialExpressionsLog()
    {
        foreach (var expressionLog in _calculatorModel.ExpressionsLog) 
            _expressionsLogBuilder.Insert(0, expressionLog + "\n");

        _expressionsLogText.text = _expressionsLogBuilder.ToString();
    }

    private void HandleNewExpressionLog(CollectionAddEvent<string> addEvent)
    {
        _expressionsLogBuilder.Insert(0, addEvent.Value + "\n");
        _expressionsLogText.text = _expressionsLogBuilder.ToString();
        LayoutRebuilder.ForceRebuildLayoutImmediate(_layoutGroup);
    }
}
