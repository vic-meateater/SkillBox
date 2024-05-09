using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private EndGame _endGameScreen;
    [SerializeField] public float _maxTime;
    
    private float _startTime;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        float elapsedTime = Time.time - _startTime;
        UpdateTimerText(_maxTime - elapsedTime);

        if (elapsedTime >= _maxTime)
            ShowEndGameScreen();
    }

    private void ShowEndGameScreen()
    {
        _endGameScreen.ShowEndGameScreen(false); 
    }
    private void UpdateTimerText(float currentTime)
    {
        _timeText.text = Mathf.RoundToInt(currentTime).ToString();
    }

    public void StartTimer()
    {
        _startTime = Time.time;
        UpdateTimerText(_maxTime);
    }
}