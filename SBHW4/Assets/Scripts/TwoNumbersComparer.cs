using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : MonoBehaviour, IDisposable
{
    [SerializeField] private TMP_InputField _textFieldLeft;
    [SerializeField] private TMP_InputField _textFieldRight;
    [SerializeField] private TMP_InputField _textFieldAnswer;
    [SerializeField] private Button _compareButton;

    private void Start()
    {
        _compareButton.onClick.AddListener(CompareNumbers);
    }

    private void CompareNumbers()
    {
        if (!float.TryParse(_textFieldLeft.text, out var leftInputNumber) || !float.TryParse(_textFieldRight.text, out var rightInputNumber))
            return;

        if (leftInputNumber > rightInputNumber)
        {
            _textFieldAnswer.text = leftInputNumber.ToString();
        }
        else if (leftInputNumber < rightInputNumber)
        {
            _textFieldAnswer.text = rightInputNumber.ToString();
        }
        else
        {
            _textFieldAnswer.text = "Равны";
        }
    }

    public void Dispose()
    {
        _compareButton.onClick.RemoveListener(CompareNumbers);
    }
}
