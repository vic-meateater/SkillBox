using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private TMP_Text _pinOneText;
    [SerializeField] private TMP_Text _pinTwoText;
    [SerializeField] private TMP_Text _pinThreeText;
    [SerializeField] private TMP_Text _levelCounterText;
    
    [SerializeField] private Button _drillButton;
    [SerializeField] private Button _hammerButton;
    [SerializeField] private Button _pickLockButton;

    [SerializeField] private EndGame _endGameScreen; 

    private int _pinOneValue;
    private int _pinTwoValue;
    private int _pinThreeValue;

    private int _levelCounter = 1;
    
    private void Start()
    {
        _drillButton.onClick.AddListener(() => TryToUnlock(1,-1,0));
        _hammerButton.onClick.AddListener(() => TryToUnlock(-1,2,-1));
        _pickLockButton.onClick.AddListener(() => TryToUnlock(-1,1,1));
        
        StartNewGame();
    }

    private void TryToUnlock(int pinOne, int pinTwo, int pinThree)
    {
        _pinOneValue = CheckValueLimits(_pinOneValue + pinOne);;
        _pinTwoValue = CheckValueLimits(_pinTwoValue + pinTwo);
        _pinThreeValue = CheckValueLimits(_pinThreeValue + pinThree);
        
        UpdatePinText(_pinOneValue, _pinTwoValue, _pinThreeValue);
        
        if (_pinOneValue == 5 && _pinTwoValue == 5 && _pinThreeValue == 5)
        {
            ShowEndGameScreen();
            _levelCounter++;
        }
    }

    private void ShowEndGameScreen()
    {
        _endGameScreen.ShowEndGameScreen(true);
    }

    private int CheckValueLimits(int pinValue)
    {
        pinValue = pinValue > 10 ? 10 : pinValue;
        pinValue = pinValue < 0 ? 0 : pinValue;
        return pinValue;
    }

    private void UpdatePinText(int pinOne, int pinTwo, int pinThree)
    {
        _pinOneText.text = pinOne.ToString();
        _pinTwoText.text = pinTwo.ToString();
        _pinThreeText.text = pinThree.ToString();
    }

    private void SetRandomPinValues()
    {
        _pinOneValue = Random.Range(1, 9);
        _pinTwoValue = Random.Range(1, 9);
        _pinThreeValue = Random.Range(1, 9);
        
        UpdatePinText(_pinOneValue, _pinTwoValue, _pinThreeValue);
    }

    private void SetPinValues(int pinOneValue, int pinTwoValue, int pinThreeValue)
    {
        _pinOneValue = pinOneValue;
        _pinTwoValue = pinTwoValue;
        _pinThreeValue = pinThreeValue;
        
        UpdatePinText(_pinOneValue, _pinTwoValue, _pinThreeValue);
    }
    public void StartNewGame()
    {
        _levelCounterText.text = _levelCounter.ToString();
        switch (_levelCounter)
        {
            case 1: SetPinValues(6,3,6);
                break;
            case 2: SetPinValues(7,2,5);
                break;
            case 3: SetPinValues(6,3,5);
                break;
            default: SetRandomPinValues();
                break;
        }
    }

    public void ResetWinCounter()
    {
        _levelCounter = 1;
        _levelCounterText.text = _levelCounter.ToString();
    }
}