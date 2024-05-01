using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour, IDisposable
{
    [SerializeField] private TMP_InputField _textFieldLeft;
    [SerializeField] private TMP_InputField _textFieldRight;
    [SerializeField] private TMP_InputField _textFieldAnswer;
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _subtractButton;
    [SerializeField] private Button _multiplyButton;
    [SerializeField] private Button _devideButton;

    private float _leftInputNumber;
    private float _rightInputNumber;

    private void Start()
    {
        _addButton.onClick.AddListener(() => EvaluateExpression("+"));
        _subtractButton.onClick.AddListener(() => EvaluateExpression("-"));
        _multiplyButton.onClick.AddListener(() => EvaluateExpression("*"));
        _devideButton.onClick.AddListener(() => EvaluateExpression("/"));
    }

    private void EvaluateExpression(string expression)
    {

        if (!float.TryParse(_textFieldLeft.text, out _leftInputNumber) || !float.TryParse(_textFieldRight.text, out _rightInputNumber))
            return;

        switch (expression)
        {
            case "+":
                _textFieldAnswer.text = (_leftInputNumber + _rightInputNumber).ToString();
                break;
            case "-":
                _textFieldAnswer.text = (_leftInputNumber - _rightInputNumber).ToString();
                break;
            case "*":
                _textFieldAnswer.text = (_leftInputNumber * _rightInputNumber).ToString();
                break;
            case "/":
                if (_rightInputNumber == 0)
                {
                    Debug.Log("деление на 0");
                    return;
                }
                _textFieldAnswer.text = (_leftInputNumber / _rightInputNumber).ToString();
                break;

        }
    }

    public void Dispose()
    {
        _addButton.onClick.RemoveListener(() => EvaluateExpression("+"));
        _subtractButton.onClick.RemoveListener(() => EvaluateExpression("-"));
        _multiplyButton.onClick.RemoveListener(() => EvaluateExpression("*"));
        _devideButton.onClick.RemoveListener(() => EvaluateExpression("/"));
    }
}
