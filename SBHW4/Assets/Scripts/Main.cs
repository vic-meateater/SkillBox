using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private GameObject _calculator;
    [SerializeField] private GameObject _comparerer;
    [SerializeField] private Button _calculatorButton;
    [SerializeField] private Button _comparererButton;

    private GameObject _currentState;
    
    private void Start()
    {
        _calculator.SetActive(true);
        _currentState = _calculator;
        _calculatorButton.onClick.AddListener(()=>ChangeState(_calculator));
        _comparererButton.onClick.AddListener(()=>ChangeState(_comparerer));
    }

    public void ChangeState(GameObject state)
    {
        if (state != null)
        {
            _currentState.SetActive(false);
            state.SetActive(true);
            _currentState = state;
        }
    }
}
